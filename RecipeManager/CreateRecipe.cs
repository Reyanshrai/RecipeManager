using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace RecipeManager
{
    public partial class CreateRecipe : Form
    {
        public CreateRecipe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string recipeName = textBox1.Text;
            string ingredients = richTextBox1.Text;
            string steps = richTextBox2.Text;
            string category = comboBox1.Text;
            string cuisine = comboBox2.Text;
            Image recipeImage = pictureBox1.Image;

            AddRecipeToDatabase(recipeName, ingredients, steps,category,cuisine, recipeImage);
            MessageBox.Show("Recipe added to the database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Dashboard MainForm = new Dashboard();
            MainForm.Show();
        }

        private void AddRecipeToDatabase(string name, string ingredients, string steps, string category, string cuisine, Image image)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(richTextBox1.Text) ||
                string.IsNullOrEmpty(richTextBox2.Text) ||
                string.IsNullOrEmpty(comboBox1.Text) ||
                string.IsNullOrEmpty(comboBox2.Text) ||
                pictureBox1.Image == null)
            {
                MessageBox.Show("All fields are required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes = ConvertImageToBinary(image);

            using (var connections = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=RecipeManage;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;"))
            {

                connections.Open();
                string query = "INSERT INTO [Recipe] (Name, Ingredients, Steps,Category,Cuisine, Image) " +
                               "VALUES (@Name, @Ingredients, @Steps,@Category,@Cuisine, @Image)";
                using (var command = new SqlCommand(query, connections))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Ingredients", ingredients);
                    command.Parameters.AddWithValue("@Steps", steps);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Cuisine", cuisine);
                    command.Parameters.AddWithValue("@Image", imageBytes);
                    command.ExecuteNonQuery();
                }
            }
        }

        private byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (image != null){
                    image.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                return null;
                
            }
        }

        private Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            // Prevent division by zero in case of 0 width or height
            if (img.Width == 0 || img.Height == 0)
                throw new ArgumentException("Image has invalid dimensions.");

            // Determine the ratio to resize the image
            float ratio = Math.Min((float)maxWidth / img.Width, (float)maxHeight / img.Height);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            // Create a new bitmap with the new dimensions
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Dispose of any existing image to avoid memory leak
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                        }

                        // Load and resize image to prevent OutOfMemoryException
                        using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            stream.Position = 0;
                            Image originalImage = Image.FromStream(stream);
                            pictureBox1.Image = ResizeImage(originalImage, pictureBox1.Width, pictureBox1.Height);
                        }

                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (ArgumentException argEx)
                    {
                        MessageBox.Show("The selected file is not a valid image format.", "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("The image is too large to load. Please try a smaller image.", "Out of Memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not load the image. " + ex.Message);
                    }
                }
            }
        }
    }
}

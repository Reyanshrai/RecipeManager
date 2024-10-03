using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class ViewAllRecipe : Form
    {
        string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=RecipeManage;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;";

        public ViewAllRecipe()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void ViewAllRecipe_Load(object sender, EventArgs e)
        {
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            DataTable recipes = GetAllRecipesFromDatabase();

            // Clear existing columns (in case of reload)
            dataGridView1.Columns.Clear();

            // Check if there are any recipes
            if (recipes.Rows.Count > 0)
            {
                dataGridView1.DataSource = recipes;

                // Add delete and print buttons
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Text = "Delete",
                    Name = "Delete", // Give it a name to easily find later
                    UseColumnTextForButtonValue = true
                };

                DataGridViewButtonColumn printButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Print",
                    Text = "Print",
                    Name = "Print", // Give it a name to easily find later
                    UseColumnTextForButtonValue = true
                };

                // Insert the buttons at the end
                dataGridView1.Columns.Add(deleteButtonColumn);
                dataGridView1.Columns.Add(printButtonColumn);
            }
            else
            {
                MessageBox.Show("No recipes available.");
                dataGridView1.DataSource = null; // Clear DataGridView if no recipes
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the row is valid (not the header row and within the row bounds)
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count) return;

            // Ensure the column index is within bounds
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridView1.Columns.Count) return;

            // Check if the Delete button is clicked
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                try
                {
                    // Ensure the "Id" cell is not null and convert it to int
                    var cellValue = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    if (cellValue != null)
                    {
                        int recipeId = Convert.ToInt32(cellValue);

                        // Show a confirmation dialog before deleting
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            DeleteRecipeFromDatabase(recipeId); // Delete recipe from the database
                            LoadRecipes(); // Refresh the DataGridView after deletion
                            MessageBox.Show("Recipe successfully deleted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Recipe ID is missing.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Recipe ID format.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting recipe: {ex.Message}");
                }
            }
            // Check if the Print button is clicked
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Print")
            {
                try
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];
                    if (selectedRow != null)
                    {
                        PrintRecipe(selectedRow); // Print the selected recipe
                    }
                    else
                    {
                        MessageBox.Show("The selected row is invalid.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error printing recipe: {ex.Message}");
                }
            }
        }




        private void DeleteRecipeFromDatabase(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM [Recipe] WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    //MessageBox.Show("Succesfully Deleted Recipe from Database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing database: {ex.Message}");
            }
        }

        private void PrintRecipe(DataGridViewRow selectedRow)
        {
            string recipeName = selectedRow.Cells["Name"].Value.ToString();
            string ingredients = selectedRow.Cells["Ingredients"].Value.ToString();
            string steps = selectedRow.Cells["Steps"].Value.ToString();
            string category = selectedRow.Cells["Category"].Value.ToString();
            string cuisine = selectedRow.Cells["Cuisine"].Value.ToString();

            int recipeId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            Image recipeImage = GetRecipeImage(recipeId);

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, e) =>
            {
                e.Graphics.DrawString($"Recipe Name: {recipeName}", new Font("Arial", 16), Brushes.Black, new PointF(100, 100));
                e.Graphics.DrawString($"Ingredients: {ingredients}", new Font("Arial", 12), Brushes.Black, new PointF(100, 150));
                e.Graphics.DrawString($"Steps: {steps}", new Font("Arial", 12), Brushes.Black, new PointF(100, 200));
                e.Graphics.DrawString($"Category: {category}", new Font("Arial", 12), Brushes.Black, new PointF(100, 250));
                e.Graphics.DrawString($"Cuisine: {cuisine}", new Font("Arial", 12), Brushes.Black, new PointF(100, 300));

                if (recipeImage != null)
                {
                    e.Graphics.DrawImage(recipeImage, new Point(100, 350)); // Adjust position as needed
                }
            };

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private Image GetRecipeImage(int Id)
        {
            byte[] imageBytes = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Image FROM [Recipe] WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Get the image as a byte array
                            imageBytes = reader["Image"] as byte[];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing database: {ex.Message}");
            }

            // Convert byte array to Image
            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }

            return null; // Return null if no image is found
        }

        private DataTable GetAllRecipesFromDatabase()
        {
            DataTable recipes = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Recipe]", conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(recipes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing database: {ex.Message}");
            }

            return recipes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard MainForm = new Dashboard();
            MainForm.ShowDialog();
            this.Hide();
        }
    }
}

namespace RecipeManager
{
    partial class CreateRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(486, 19);
            label1.Name = "label1";
            label1.Size = new Size(254, 54);
            label1.TabIndex = 0;
            label1.Text = "Add Recipes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(383, 143);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 1;
            label2.Text = "Recipe Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(383, 228);
            label3.Name = "label3";
            label3.Size = new Size(119, 28);
            label3.TabIndex = 2;
            label3.Text = "Ingredients";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(383, 339);
            label4.Name = "label4";
            label4.Size = new Size(180, 28);
            label4.TabIndex = 3;
            label4.Text = "Preparation Steps";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(383, 450);
            label6.Name = "label6";
            label6.Size = new Size(98, 28);
            label6.TabIndex = 5;
            label6.Text = "Category";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(383, 511);
            label7.Name = "label7";
            label7.Size = new Size(131, 28);
            label7.TabIndex = 6;
            label7.Text = "Cuisine Type";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(564, 576);
            button1.Name = "button1";
            button1.Size = new Size(163, 52);
            button1.TabIndex = 7;
            button1.Text = "Add Recipe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1016, 148);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(1042, 107);
            label5.Name = "label5";
            label5.Size = new Size(139, 28);
            label5.TabIndex = 9;
            label5.Text = "Recipe Image";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(654, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 34);
            textBox1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(654, 181);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(199, 116);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox2.Location = new Point(655, 313);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(198, 108);
            richTextBox2.TabIndex = 12;
            richTextBox2.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Appetizers", "Main Course", "Desserts", "Beverages", "Salads", "Soups", "Snacks", "Breakfast", "Lunch", "Dinner" });
            comboBox1.Location = new Point(656, 445);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 36);
            comboBox1.TabIndex = 13;
            comboBox1.Text = "Select Category";
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Italian", "Indian", "Chinese", "Mexican", "American", "French", "Thai", "Japanese", "Mediterranean", "Greek" });
            comboBox2.Location = new Point(657, 503);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(196, 36);
            comboBox2.TabIndex = 14;
            comboBox2.Text = "Select Cuisine";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1042, 377);
            button2.Name = "button2";
            button2.Size = new Size(154, 44);
            button2.TabIndex = 15;
            button2.Text = "Select Image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CreateRecipe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgreci;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1251, 640);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateRecipe";
            Text = "CreateRecipe";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label5;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button2;
    }
}
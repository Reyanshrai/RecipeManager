namespace RecipeManager
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAllRecipe AllRecipe = new ViewAllRecipe();
            AllRecipe.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRecipe recipe = new CreateRecipe();
            recipe.Show();
            this.Hide();
        }
    }
}

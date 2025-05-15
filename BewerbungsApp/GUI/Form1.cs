namespace BewerbungsAppGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Program.StartListener();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

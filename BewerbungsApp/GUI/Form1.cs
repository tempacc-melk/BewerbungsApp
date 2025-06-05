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

        internal void ChangeLabel (Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(delegate { label.Text = text; }));
            } 
            else
            {
                label.Text = text;
            }
        }
    }
}

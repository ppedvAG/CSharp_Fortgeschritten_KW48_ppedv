namespace EventEventHandlerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    progressBar1.Value = i;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Klasse Windows.Forms.Form signalisiert intern heraus, dass er jetzt weitere \n Dinge laden kann");
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hey ich habe dich beim Minimieren erwischt");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Hey ich habe mitbekommen, wie meine width and heigh-Values sich ändern");
        }
    }
}
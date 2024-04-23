namespace PressureConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void buttonLaske_Click(object sender, EventArgs e)
        {
            string pressureKpa = textBoxkPa.Text;

            double kiloPascals = Convert.ToDouble(pressureKpa);

            double bars = Math.Round(kiloPascals * 0.01d, 2);
            double psi = Math.Round(kiloPascals * 0.145d, 2);
            textBoxBar.Text = Convert.ToString(bars);
            textBoxPsi.Text = Convert.ToString(psi);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxkPa.Text = string.Empty;
            textBoxkPa.Focus();

            textBoxPsi.Text = string.Empty;
            textBoxBar.Text = string.Empty;

            buttonLaske.Enabled = false;
        }

        private void textBoxkPa_TextChanged(object sender, EventArgs e)
        {
            buttonLaske.Enabled = true;
            buttonClear.Enabled = true;
        }

        private void textBoxkPa_Leave(object sender, EventArgs e)
        {
            double kpa;
            bool numericValue = double.TryParse(textBoxkPa.Text, out kpa);
            if (kpa <= 10)
            {
                string message = "Virheellinen painetieto, paine ei saa olla alle 10.";
            }
        }
    }
}
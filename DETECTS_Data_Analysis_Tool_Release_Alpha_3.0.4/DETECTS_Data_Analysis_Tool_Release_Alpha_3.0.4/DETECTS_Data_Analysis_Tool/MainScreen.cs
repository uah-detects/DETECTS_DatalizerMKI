using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DETECTS_Data_Analysis_Tool
{
    public partial class MainScreen : Form
    {
        GraphPage graphPage;
        InstructionsPage insPage;
        AscentRateCalculatorPage ascPage;
        public MainScreen()
        {
            InitializeComponent();
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.full_logo_Sized;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void graphButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            graphPage = new GraphPage();
            graphPage.graphFormClosedEvent += new GraphPage.graphFormClosed(graphPage_graphFormClosedEvent);
            graphPage.ShowDialog();
        }
        private void graphPage_graphFormClosedEvent(Object sender)
        {

            this.Show();

        }

        private void instructionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            insPage = new InstructionsPage();
            insPage.instructionPageClosedEvent += new InstructionsPage.instructionPageClosed(insPage_instructionPageClosedEvent);
            insPage.ShowDialog();
        }
        private void insPage_instructionPageClosedEvent(Object sender)
        {

            this.Show();

        }

        private void ascButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ascPage = new AscentRateCalculatorPage();
            ascPage.ascentRateCalcPageClosedEvent += new AscentRateCalculatorPage.ascentRateCalcPageClosed(ascPage_ascentRateCalcPageClosedEvent);
            ascPage.ShowDialog();
        }
        private void ascPage_ascentRateCalcPageClosedEvent(Object sender)
        {

            this.Show();

        }

    }
}

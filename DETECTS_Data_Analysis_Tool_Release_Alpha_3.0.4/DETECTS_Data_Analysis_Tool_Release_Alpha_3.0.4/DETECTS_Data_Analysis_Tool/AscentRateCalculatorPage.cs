using System;
using System.IO;
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
    public partial class AscentRateCalculatorPage : Form
    {
        public string filePath = null;
        public AscentRateCalculatorPage()
        {
            InitializeComponent();
        }

        // Assuming you need a custom signature for your event. If not, use an existing standard event delegate
        public delegate void ascentRateCalcPageClosed(object sender);

        // Expose the event off your component
        public event ascentRateCalcPageClosed ascentRateCalcPageClosedEvent;

        private void AscentRateCalcPage_FormClosed(Object sender, FormClosedEventArgs e)
        {

            // And to raise it
            var eventSubscribers = ascentRateCalcPageClosedEvent;
            if (eventSubscribers != null)
            {
                eventSubscribers(this);
            }



        }
        private void AltitudeCalculatorPage_Load(object sender, EventArgs e)
        {
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
            richTextBox1.AllowDrop = true;
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            object filename = e.Data.GetData("FileDrop");
            if (filename != null)
            {
                var list = filename as string[];

                if (list != null && !string.IsNullOrWhiteSpace(list[0]))
                {
                    filePath = list[0];
                    richTextBox1.Clear();
                    string ext = Path.GetExtension(filePath);
                    if (ext != ".csv")
                    {
                        MessageBox.Show("Error: File is not a CSV.");
                        xComboBox.Items.Clear();
                        xComboBox.Text = "";
                        yComboBox.Items.Clear();
                        yComboBox.Text = "";
                        return;
                    }
                    if (Directory.Exists(list[0]))
                    {
                        foreach (string file in Directory.EnumerateFiles(list[0], "*.csv"))
                        {

                            string contents = File.ReadAllText(file);
                            try
                            {
                                richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
                            }
                            catch
                            {
                                MessageBox.Show("Error: Directory is open. Please close the directory and try again.");
                                return;
                            }

                        }
                    }
                    else if (File.Exists(list[0]))
                    {
                        try
                        {
                            richTextBox1.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                        }
                        catch
                        {
                            MessageBox.Show("Error: File is open. Please close the file and try again.");
                            return;
                        }
                    }

                }
                //
                xComboBox.Items.Clear();
                xComboBox.Text = "";
                yComboBox.Items.Clear();
                yComboBox.Text = "";
                List<string> header = new List<string>();
                fileManipulation fM = new fileManipulation();
                header = fM.readHeaderInput(filePath);
                foreach (string item in header)
                {
                    xComboBox.Items.Add(item);
                    yComboBox.Items.Add(item);
                }
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            AscentRateCalculator calc = new AscentRateCalculator();

            int selectedIndexX = xComboBox.SelectedIndex;
            int selectedIndexY = yComboBox.SelectedIndex;

            calc.runAscentRateCalc(filePath, selectedIndexX, selectedIndexY);
        }

        private void clearTextboxButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            xComboBox.Items.Clear();
            xComboBox.Text = "";
            yComboBox.Items.Clear();
            yComboBox.Text = "";
            filePath = null;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

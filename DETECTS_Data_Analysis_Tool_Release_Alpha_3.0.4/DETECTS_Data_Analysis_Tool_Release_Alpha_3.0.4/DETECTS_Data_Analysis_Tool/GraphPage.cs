using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DETECTS_Data_Analysis_Tool
{
    public struct dataPointsRaw
    {
        public string xData;
        public string yData;
        public dataPointsRaw(string x, string y)
        {
            xData = x;
            yData = y;
        }
    }
    public struct dataPointsAscentRateXD
    {
        public DateTime xData;
        public double yData;
        public dataPointsAscentRateXD(DateTime x, double y)
        {
            xData = x;
            yData = y;
        }
    }
    public struct dataPointsAscentRateYD
    {
        public double xData;
        public DateTime yData;
        public dataPointsAscentRateYD(double x, DateTime y)
        {
            xData = x;
            yData = y;
        }
    }
    public struct pointIsDate
    {
        public bool xData;
        public bool yData;
        public pointIsDate(bool x, bool y)
        {
            xData = x;
            yData = y;
        }
    }

    public partial class GraphPage : Form
    {
        public string filePath = null;
        public GraphPage()
        {
            InitializeComponent();
        }

        // Assuming you need a custom signature for your event. If not, use an existing standard event delegate
        public delegate void graphFormClosed(object sender);

        // Expose the event off your component
        public event graphFormClosed graphFormClosedEvent;

        private void GraphPage_FormClosed(Object sender, FormClosedEventArgs e)
        {

            // And to raise it
            var eventSubscribers = graphFormClosedEvent;
            if (eventSubscribers != null)
            {
                eventSubscribers(this);
            }

            

        }

        private void GraphPage_Load(object sender, EventArgs e)
        {
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
            richTextBox1.AllowDrop = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
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

        private void graphButton_Click(object sender, EventArgs e)
        {
            clearGraph();
            fileManipulation fM = new fileManipulation();
            AscentRateCalculator calc = new AscentRateCalculator();
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<dataPointsRaw> rawData = new List<dataPointsRaw>();
            dataPointsRaw header;
            pointIsDate list;
            List<string> headerList = new List<string>();



            int selectedIndexX = xComboBox.SelectedIndex;
            int selectedIndexY = yComboBox.SelectedIndex;


            rawData = fM.readInput(filePath, selectedIndexX, selectedIndexY);               // reading the data in from the input file

            if (rawData == null)
            {
                MessageBox.Show("Error: No data recieved");
            }
            else
            {
                header = new dataPointsRaw("X Data", "Y Data");   // setting the filler header data

                if (fM.isHeaderExist(rawData))               //getting and stripping the header from the list
                {
                    header = rawData.First();
                    headerList = fM.readHeaderInput(filePath);
                    rawData.RemoveAt(0);
                    list = calc.isPointDateTime(rawData);            //testing if any columns are a DateTime

                    if(!list.xData)
                    {
                        if(!list.yData)
                        {
                            try
                            {
                                x.Add(Convert.ToDouble(rawData.First().xData));
                                y.Add(Convert.ToDouble(rawData.First().yData));
                            }
                            catch
                            {
                                MessageBox.Show("Error: Header included in data set.");
                                return;
                            }

                        }
                    }

                    if (list.xData && list.yData)                // testing which column the DateTime is
                    {
                        MessageBox.Show("Error: You are trying to plot a graph with dates in both the x and y columns. Please try again.");
                    }
                    else if (list.xData)
                    {
                        plotXDTGraph(rawData, header);
                    }
                    else if (list.yData)
                    {
                        plotYDTGraph(rawData, header);
                    }
                    else
                    {
                        plotNoDTGraph(rawData, header);
                    }
                }
                else
                {
                    MessageBox.Show("Error: Header Missing.");
                    return;
                }

            }
        }

        //graphs data that does not have a DateTime
        public void plotNoDTGraph(List<dataPointsRaw> list, dataPointsRaw header)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            dataPointsRaw dataSet;
            bool flag = false;
            while (flag == false)
            {
                dataSet = list.First();
                try
                {
                    x.Add(Convert.ToDouble(dataSet.xData));
                    y.Add(Convert.ToDouble(dataSet.yData));
                }
                    catch
                {
                    MessageBox.Show("Error: Data invalid");
                    return;
                }
            list.RemoveAt(0);
                if (list.Count == 0)
                {
                    flag = true;
                }
            }
            flag = false;

            double[] xs1 = x.ToArray();
            double[] ys1 = y.ToArray();

            double maxXValue = xs1.Max();
            double maxYValue = ys1.Max();

            double minXValue = xs1.Min();
            double minYValue = ys1.Min();

            // create a series for each line
            Series series1 = new Series("Group A");
            series1.Points.DataBindXY(xs1, ys1);
            series1.ChartType = SeriesChartType.Line;
            series1.MarkerStyle = MarkerStyle.Circle;


            // add each series to the chart
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisY.Maximum = maxYValue; // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisY.Minimum = minYValue; // sets the Minimum to NaN
            chart1.ChartAreas[0].AxisX.Maximum = maxXValue; // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisX.Minimum = minXValue; // sets the Minimum to NaN
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.Series.Add(series1);





            // additional styling
            chart1.ResetAutoValues();
            chart1.Titles.Clear();
            chart1.Titles.Add(header.yData + " vs " + header.xData);
            chart1.ChartAreas[0].AxisX.Title = header.xData;
            chart1.ChartAreas[0].AxisY.Title = header.yData;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        }

        public void plotXDTGraph(List<dataPointsRaw> list, dataPointsRaw header)
        {
            List<DateTime> x = new List<DateTime>();
            List<double> y = new List<double>();
            dataPointsRaw dataSet;
            bool flag = false;
            while (flag == false)
            {
                dataSet = list.First();
                try
                {
                    x.Add(DateTime.Parse(dataSet.xData));
                    y.Add(Convert.ToDouble(dataSet.yData));
                }
                catch
                {
                    MessageBox.Show("Error: Data invalid");
                    return;
                }
                list.RemoveAt(0);
                if (list.Count == 0)
                {
                    flag = true;
                }
            }
            flag = false;

            DateTime[] xs1 = x.ToArray();
            double[] ys1 = y.ToArray();

            DateTime maxXValue = xs1.Max();
            double maxYValue = ys1.Max();

            DateTime minXValue = xs1.Min();
            double minYValue = ys1.Min();


            // create a series for each line
            Series series1 = new Series("Group A");
            series1.Points.DataBindXY(xs1, ys1);
            series1.ChartType = SeriesChartType.Line;
            series1.MarkerStyle = MarkerStyle.Circle;

            // add each series to the chart
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisY.Maximum = maxYValue; // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisY.Minimum = minYValue; // sets the Minimum to NaN
            chart1.ChartAreas[0].AxisX.Maximum = maxXValue.ToOADate(); // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisX.Minimum = minXValue.ToOADate(); // sets the Minimum to NaN
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.Series.Add(series1);

            // additional styling
            chart1.ResetAutoValues();
            chart1.Titles.Clear();
            chart1.Titles.Add(header.yData + " vs " + header.xData);//$"Scatter Plot");
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
            chart1.ChartAreas[0].AxisX.Title = header.xData;
            chart1.ChartAreas[0].AxisY.Title = header.yData;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        }

        public void plotYDTGraph(List<dataPointsRaw> list, dataPointsRaw header)
        {
            List<double> x = new List<double>();
            List<DateTime> y = new List<DateTime>();
            dataPointsRaw dataSet;
            bool flag = false;
            while (flag == false)
            {
                dataSet = list.First();
                try
                {
                    x.Add(Convert.ToDouble(dataSet.xData));
                    y.Add(DateTime.Parse(dataSet.yData));
                }
                catch
                {
                    MessageBox.Show("Error: Data invalid");
                    return;
                }
                list.RemoveAt(0);
                if (list.Count == 0)
                {
                    flag = true;
                }
            }
            flag = false;

            double[] xs1 = x.ToArray();
            DateTime[] ys1 = y.ToArray();

            double maxXValue = xs1.Max();
            DateTime maxYValue = ys1.Max();

            double minXValue = xs1.Min();
            DateTime minYValue = ys1.Min();

            // create a series for each line
            Series series1 = new Series("Group A");
            series1.Points.DataBindXY(xs1, ys1);
            series1.ChartType = SeriesChartType.Line;
            series1.MarkerStyle = MarkerStyle.Circle;

            // add each series to the chart
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisY.Maximum = maxYValue.ToOADate(); // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisY.Minimum = minYValue.ToOADate(); // sets the Minimum to NaN
            chart1.ChartAreas[0].AxisX.Maximum = maxXValue; // sets the Maximum to NaN
            chart1.ChartAreas[0].AxisX.Minimum = minXValue; // sets the Minimum to NaN
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.Series.Add(series1);

            // additional styling
            chart1.ResetAutoValues();
            chart1.Titles.Clear();
            chart1.Titles.Add(header.yData + " vs " + header.xData);
            chart1.Series[0].YValueType = ChartValueType.DateTime;
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
            chart1.ChartAreas[0].AxisX.Title = header.xData;
            chart1.ChartAreas[0].AxisY.Title = header.yData;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            xComboBox.Items.Clear();
            xComboBox.Text = "";
            yComboBox.Items.Clear();
            yComboBox.Text = "";
            filePath = null;
        }

        private void clearGraphButton_Click(object sender, EventArgs e)
        {
            clearGraph();
        }

        public void clearGraph()
        {
            chart1.Series.Clear();
            chart1.ResetAutoValues();
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = null;
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = null;
            chart1.Titles.Clear();
        }

        private void screenShotButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.Title = "Save Images";
            saveImage.CheckFileExists = false;
            saveImage.CheckPathExists = false;
            saveImage.CreatePrompt = true;
            saveImage.DefaultExt = "jpg";
            saveImage.Filter = "JPG Files (*.jpg)|*.jpg | PNG Files (*.png)| *.png |All files (*.*)|*.*";
            saveImage.FilterIndex = 1;
            saveImage.RestoreDirectory = true;
            if (saveImage.ShowDialog() == DialogResult.OK)
            {
                WindowScreenshot(Path.GetDirectoryName(saveImage.FileName), Path.GetFileName(saveImage.FileName), ImageFormat.Jpeg);
            }
        }

        private void WindowScreenshot(String filepath, String filename, ImageFormat format)
        {
            ScreenCapture sc = new ScreenCapture();

            string fullpath = filepath + "\\" + filename;

            sc.CaptureWindowToFile(this.Handle, fullpath, format);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

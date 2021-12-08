using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETECTS_Data_Analysis_Tool
{
    class fileManipulation
    {

        public List<string> readHeaderInput(string filePath)
        {
            List<string> data = new List<string>();

            if (filePath != null)
            {
                try
                {
                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(filePath))
                    {

                        string s;
                        s = sr.ReadLine();
                        string[] values = s.Split(',');                               // parsing the data
                        for (int i = 0; i < values.Length; i++)
                        {
                            data.Add(values[i]);
                        }
                        sr.Close();

                    }
                    
                }
                catch
                {
                    MessageBox.Show("Error: Path denied. Please pull the file out of the directory.");
                    return null;
                }

            }
            else
            {
                data = null;
            }

            return data;
        }

        // function reads in a file and outputs the data as a list of type dataPointsRaw
        public List<dataPointsRaw> readInput(string filePath, int xIndex, int yIndex)
        {
            List<dataPointsRaw> data = new List<dataPointsRaw>();

            if (filePath != null)
            {
                try
                {
                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)                               // looping through the data file until the end
                        {
                            string[] values = s.Split(',');                               // parsing the data
                            dataPointsRaw d = new dataPointsRaw(values[xIndex], values[yIndex]);
                            data.Add(d);                                                  // adding the data to the list

                        }
                        sr.Close();

                    }
                }
                catch
                {
                    MessageBox.Show("Error: Path denied. Please pull the file out of the directory.");
                    return null;
                }

            }
            else
            {
                data = null;
            }

            return data;
        }

        public bool isHeaderExist(List <dataPointsRaw> data)
        {
            AscentRateCalculator calc = new AscentRateCalculator();
            dataPointsRaw headerLine;
            pointIsDate list;
            double i;
            headerLine = data.First();

            list = calc.isPointDateTime(data);            //testing if any columns are a DateTime

            if(!list.xData && !list.yData)               // testing if DateTime
            {
                if (!double.TryParse(headerLine.xData, out i) && !double.TryParse(headerLine.xData, out i))      //testing if number
                {
                    return true;
                }
            }

            return false;
        }

        public void addColumnToCSVFile(string header, List<double> dataList, string originalFilePath)
        {
            if (originalFilePath != null)
            {
                SaveFileDialog saveCSV = new SaveFileDialog();
                saveCSV.Title = "Save text Files";
                saveCSV.CheckFileExists = false;
                saveCSV.CheckPathExists = false;
                saveCSV.CreatePrompt = true;
                saveCSV.DefaultExt = "csv";
                saveCSV.Filter = "CSV Files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveCSV.FilterIndex = 1;
                saveCSV.RestoreDirectory = true;
                if (saveCSV.ShowDialog() == DialogResult.OK)
                {
                    using (Stream st = File.Open(saveCSV.FileName, FileMode.CreateNew))
                    {
                        StreamWriter sw = new System.IO.StreamWriter(st);
                        try
                        {
                            // Open the file to read from.
                            using (StreamReader sr = File.OpenText(originalFilePath))
                            {
                                bool first = true;
                                string s;
                                while ((s = sr.ReadLine()) != null)                               // looping through the data file until the end
                                {
                                    if(first)
                                    {
                                        s = s + "," + header + "\n";
                                        sw.Write(s);
                                        first = false;
                                    }
                                    else
                                    {

                                        s = s + "," + dataList.First() + "\n";
                                        dataList.RemoveAt(0);
                                        sw.Write(s);
                                        sw.Flush();                                                  //Cleaning the stream buffer
                                    }

                                }
                                first = true;
                                sr.Close();

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error: Path denied. Please pull the file out of the directory.");
                            return;
                        }

                        st.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: File Not Found.");
                return;
            }
        }

    }
}

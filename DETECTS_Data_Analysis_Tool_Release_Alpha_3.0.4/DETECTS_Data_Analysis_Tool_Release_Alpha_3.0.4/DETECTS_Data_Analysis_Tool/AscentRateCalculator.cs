using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETECTS_Data_Analysis_Tool
{
    class AscentRateCalculator
    {

        public void runAscentRateCalc(string filePath, int xIndex, int yIndex)
        {
            List<dataPointsRaw> rawXYData = new List<dataPointsRaw>();
            List<double> ascentRateList = new List<double>();
            pointIsDate list;

            fileManipulation fM = new fileManipulation();

            rawXYData = fM.readInput(filePath, xIndex, yIndex);               // reading the data in from the input file

            if (rawXYData == null)
            {
                MessageBox.Show("Error: No data recieved");
            }
            else
            {
                if(fM.isHeaderExist(rawXYData))
                {
                    rawXYData.RemoveAt(0);

                    list = isPointDateTime(rawXYData);            //testing if any columns are a DateTime

                    if (list.xData && list.yData)                // testing which column the DateTime is
                    {
                        MessageBox.Show("Error: You are trying to calculate and plot an ascent rate graph with dates in both the x and y columns. Please try again.");
                        return;
                    }

                    ascentRateList = generateAscentRateList(list, rawXYData);
                    if(ascentRateList == null)
                    {
                        return;
                    }

                    fM.addColumnToCSVFile("Ascent Rate (M/Sec)", ascentRateList, filePath);

                }
                else
                {
                    MessageBox.Show("Error: Please insert a header.");
                    return;
                }
            }

        }

        public List<double> generateAscentRateList(pointIsDate list, List<dataPointsRaw> data)
        {
            List<double> solList = new List<double>();
            DateTime prevDate = new DateTime();
            double prevAltitude = 0;
            bool first = true;
            double ascentRate = 0;


            if (list.xData)
            {
                if(!list.yData)
                {
                    foreach (var items in data)
                    {
                        if (first)
                        {
                            try
                            {
                                prevDate = DateTime.Parse(items.xData);
                                prevAltitude = Convert.ToDouble(items.yData);
                            }
                            catch
                            {
                                MessageBox.Show("Error: Data invalid");
                                return null;
                            }
                            solList.Add(ascentRate);
                            first = false;
                        }
                        else
                        {
                            try
                            {
                                TimeSpan timediff = DateTime.Parse(items.xData) - prevDate;
                                double timeDoub = Convert.ToDouble(timediff.Minutes);

                                if (timeDoub == 0)
                                {
                                    prevDate = DateTime.Parse(items.xData);
                                    prevAltitude = Convert.ToDouble(items.yData);
                                    solList.Add(ascentRate);
                                }
                                else
                                {

                                    ascentRate = calcAscentRate(altitudeDifference(prevAltitude, Convert.ToDouble(items.yData)), timediff);
                                    prevDate = DateTime.Parse(items.xData);
                                    prevAltitude = Convert.ToDouble(items.yData);
                                    solList.Add(ascentRate);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Error: Data invalid");
                                return null;
                            }
                        }

                    }
                    first = true;
                }
            }
            else if(list.yData)
            {
                if(!list.xData)
                {
                    foreach (var items in data)
                    {
                        if (first)
                        {
                            try
                            {
                                prevDate = DateTime.Parse(items.yData);
                                prevAltitude = Convert.ToDouble(items.xData);
                            }
                            catch
                            {
                                MessageBox.Show("Error: Data invalid");
                                return null;
                            }
                            solList.Add(ascentRate);
                            first = false;
                        }
                        else
                        {
                            try
                            {
                                TimeSpan timediff = DateTime.Parse(items.yData) - prevDate;
                                double timeDoub = Convert.ToDouble(timediff.Minutes);

                                if (timeDoub == 0)
                                {
                                    prevDate = DateTime.Parse(items.yData);
                                    prevAltitude = Convert.ToDouble(items.xData);
                                    solList.Add(ascentRate);
                                }
                                else
                                {
                                    ascentRate = calcAscentRate(altitudeDifference(prevAltitude, Convert.ToDouble(items.xData)), timediff);
                                    prevDate = DateTime.Parse(items.yData);
                                    prevAltitude = Convert.ToDouble(items.xData);
                                    solList.Add(ascentRate);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Error: Data invalid");
                                return null;
                            }
                        }

                    }
                    first = true;
                }
            }
            else
            {
                MessageBox.Show("Error: Both Columns have dates.");
                return null;
            }

            return solList;
        }

        // testing if any of the sub items of dataPointsRaw is a DateTime
        public pointIsDate isPointDateTime(List<dataPointsRaw> list)
        {
            pointIsDate data = new pointIsDate();
            dataPointsRaw pointList = new dataPointsRaw();
            pointList = list.First();

            if (IsDateTime(pointList.xData))
            {
                data.xData = true;

            }

            else
            {
                data.xData = false;
            }

            if (IsDateTime(pointList.yData))
            {
                data.yData = true;
            }

            else
            {
                data.yData = false;
            }

            return data;
        }

        //tests if a string is a DateTime
        public bool IsDateTime(string text)
        {
            DateTime dateTime;
            bool isDateTime = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var isValidDouble = double.TryParse(text, out double result);
            if(isValidDouble == false)                                               //Testing to make sure that the value is not a DateTime
            {
                isDateTime = DateTime.TryParse(text, out dateTime);
            }


            return isDateTime;
        }

        public double calcAscentRate(double altitude, TimeSpan time)
        {
            double timeDoub = Convert.ToDouble(time.Minutes);
            return altitude / (timeDoub * 60);
        }
        public double altitudeDifference(double y1, double y2)
        {
            double total = y2 - y1;
            return total;
        }
    }
}

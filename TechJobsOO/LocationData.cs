using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TechJobsOO
{
    public class LocationData
    {
        static Dictionary<string, double[]> AllZips = new Dictionary<string, double[]>();
        static bool IsDataLoaded = false;

        public static Dictionary<string, double[]> DataCopy(Dictionary<string, double[]> input)
        {
            Dictionary<string, double[]> zipCopy = new Dictionary<string, double[]>();
            foreach (KeyValuePair<string, double[]> zip in input)
            {
                zipCopy.Add(zip.Key, zip.Value);
            }
            return zipCopy;
        }

        //Load data, duplicate, then lookup zipcode
        public static double[] ZipLookup(string zipCode)
        {
            LoadData();
            Dictionary<string, double[]> zipCopy = DataCopy(AllZips);
            double[] latLong = zipCopy[zipCode];
            
            return latLong;
        }


        /*
         * Load and parse data from job_data.csv
         */
        private static void LoadData()
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("zipGeocodeData.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            //    Parse each row array into a more friendly Dictionary
            foreach (string[] row in rows)
            {
                AllZips.Add(row[0], new double[] { Double.Parse(row[3]), Double.Parse(row[4]) });

            }

            IsDataLoaded = true;
        }

        /*
         * Parse a single line of a CSV file into a string array
         */

        static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}

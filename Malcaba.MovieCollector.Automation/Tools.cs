using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malcaba.MovieCollector.Automation
{
    public static class Tools
    {
        public static List<string> ReadFile(string fileToRead)
        {
            int counter = 0;
            string line;

            List<string> movieList = new List<string>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(fileToRead);
            while ((line = file.ReadLine()) != null)
            {
                movieList.Add(line);
                counter++;
            }

            file.Close();

            return movieList;
        }
    }

}

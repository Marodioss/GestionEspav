using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEspav
{
    internal class Verification
    {
        public int verifyFile(String fileName)
        {
            if (File.Exists(fileName))
            {
                DateTime fileDateCreated = File.GetCreationTime(fileName);
                DateTime now = DateTime.Now;
                TimeSpan span = now - fileDateCreated;
                int totalDays = (int)span.TotalDays;
                return totalDays;
            }
            else
            {
              using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                    fs.Write(author, 0, author.Length);
                }
                return 0;
            }
        }

    }
}

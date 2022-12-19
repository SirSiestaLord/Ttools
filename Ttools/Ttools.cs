using System;
using System.Diagnostics;
using
System.Threading;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Ttools
{
    public class ObjectFuncs{
        public int i,i2;
        public string s,s2;
        public float f,f2;
        
        public ObjectFuncs(int i)
        {
            this.i = i;
        }
        public ObjectFuncs(float f)
        {
            this.f= f;
        }
        public ObjectFuncs(string s)
        {
            this.s = s;
        }

        public ObjectFuncs(string s,string s2)
        {
            this.s = s;
            this.s2 = s2;
        }
        public ObjectFuncs(int i,int i2)
        {
            this.i = i;
            this.i2 = i2;
        }
        public ObjectFuncs(float f, float f2)
        {
            this.f = f;
            this.f2 = f2;
        }

    }

    public class MainFuncs
    {
        public void WriteLine(String a)
        {
            Console.WriteLine(a);
        }
        public String ReadLine(String a)
        {
            a = Console.ReadLine();
            return a;
        }
        public void IpAdress(bool printresults)
        {

            var host = Dns.GetHostEntry(Dns.GetHostName());
            Console.WriteLine("Host Adresses");
            List<String> adresses = new List<String>();
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                adresses.Add(host.AddressList[i].ToString());
            }
            if (printresults)
            {
                foreach (var ip in host.AddressList)
                {

                    Console.WriteLine(ip.ToString());

                }
            }


        }

        public void FileTypeChanger(String Pathx, String extention)
        {
            if (extention == null || extention == " ")
            {
                Console.WriteLine("Extention Type(like .png):");
                extention = Console.ReadLine();
            }

            string extension = Path.GetExtension(Pathx);
            Path.ChangeExtension(extension, extention);
        }
        public void FilePathChanger(String oldpath, String newpath)
        {
            System.IO.File.Move(@oldpath, newpath);


        }
        public void Write(String a)
        {
            Console.Write(a);
        }
        public void OpenLink()
        {
            Console.WriteLine("Link:");
            string link = Console.ReadLine();
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "chrome";
            process.StartInfo.Arguments = link;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
        public void AutomaticRepeatedLinkOpener()
        {
            string[] links = new string[100];
            float[] times = new float[100];
            int i = 0, workcounter;
            for (int x = 0; x < 1; x = x)
            {
                Console.WriteLine("\n1-)Add Link\n2-)Start the Process\n");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        {
                            Console.WriteLine("Link:");
                            links[i] = Console.ReadLine();

                            Console.WriteLine("End Time(as second):");
                            times[i] = float.Parse(Console.ReadLine());
                            i++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("How many times should repeat ?:");
                            workcounter = int.Parse(Console.ReadLine());
                            for (int y = 0; y < i; y++)
                            {


                                for (int k = 0; k < workcounter; k++)
                                {
                                    Process process = new Process();
                                    process.StartInfo.UseShellExecute = true;
                                    process.StartInfo.FileName = "chrome";
                                    process.StartInfo.Arguments = links[y];
                                    process.StartInfo.CreateNoWindow = true;
                                    process.Start();
                                    int a = (int)times[y] * 1000;
                                    Thread.Sleep(a);
                                    process.Kill();

                                }
                            }
                            break;
                        }
                    default: { Console.WriteLine("Please choose from menu variables.\n"); break; }
                }
            }

        }
        public void GetTextFromWebsite()
        {
            string webURL = "http://www.koeri.boun.edu.tr/scripts/lasteq.asp";

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/earthquakes.txt";

            Console.WriteLine("Enter Output Text Directory:");
            filepath = Console.ReadLine();
            Console.WriteLine("Enter Link:");
            webURL
                = Console.ReadLine();
            string line; int i = 0;
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Only a Header!");
            byte[] rawByteArray = wc.DownloadData(webURL);
            string webContent = Encoding.ASCII.GetString(rawByteArray);
            var result = Regex.Replace(webContent, "<.*?>", String.Empty);
            string[] lines = new string[result.Length];

            using (StringReader reader = new StringReader(result))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    StreamWriter writer = new StreamWriter(filepath);
                    writer.Write(result);
                    writer.Close();
                }

            }
            int nullcounter = 0, sayar = 0;
            StreamReader streamReader = new StreamReader(filepath);
            for (int x = 0; x < result.Length; x++)
            {
                lines[x] = streamReader.ReadLine(); sayar++;
                if (lines[x] == null || (lines[x] == " "))
                {
                    nullcounter++;
                }
                if (nullcounter == 5) { break; }
                else if (615 > sayar && sayar > 100) { Console.WriteLine(lines[x]); }
            }
            Console.WriteLine("\n\nSave Succesfull");
        }

        public void Write_To_File(String a)
        {

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/earthquakes.txt";

            Console.WriteLine("Enter Output Text Directory:");
            filepath = Console.ReadLine();
            StreamWriter writer = new StreamWriter(filepath);
            writer.Write(a);
            writer.Close();
        }

        public String Read_From_File(String a)
        {
            a = "";

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/earthquakes.txt";

            Console.WriteLine("Enter Output Text Directory:");
            filepath = Console.ReadLine();
            StreamReader reader = new StreamReader(filepath);
            a += reader.ReadToEnd();
            reader.Close();
            return a;
        }


    }

    public class BasicMath
    {
        public int Addition(int a, int b)
        {
            return a + b;
        }
        public float AdditionF(float ca, float cb)
        {
            return ca + cb;

        }
        public int Subtraction(int a, int b)
        {
            return a - b;

        }
        public float SubtractionF(float ca, float cb)
        {
            return ca - cb;

        }
        public int Multiplication(int a, int b)
        {
            return a * b;

        }
        public float MultiplicationF(float ca, float cb)
        {
            return ca * cb;

        }
        public int Division(int a, int b)
        {
            return a / b;

        }
        public float DivisionF(float ca, float cb)
        {
            return ca / cb;

        }
        public int Percentage(int a, int b)
        {
            return a % b;

        }
        public float PercentageF(float ca, float cb)
        {
            return ca % cb;

        }
    }

}
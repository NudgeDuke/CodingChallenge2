using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodingChallenge2
{
  class Program
  {

    static void Main(string[] args)
    {

      System.Console.WriteLine("TLS counter" +
                               "Enter frequency to find:");
      var frequency = int.Parse(Console.ReadLine());
      var text = "";

      try
      {
        using (var sr = new StreamReader(@"E:\Challenges\tls.txt"))
        {
          text = sr.ReadToEnd();
        }
      }
      catch (Exception e)
      {
        System.Console.WriteLine("The file could not be read.");
      }

      var counter = new Counter(frequency, text);
      counter.CountTls();

      // Keep console window open in debug mode 
      System.Console.WriteLine("Any key to exit.");
      System.Console.ReadKey();
    }
  }
}

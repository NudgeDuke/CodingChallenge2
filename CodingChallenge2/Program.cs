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

    public static Dictionary<string, int> dictionary;
    public static int frequency;

    static void Main(string[] args)
    {
      dictionary = new Dictionary<string, int>();

      System.Console.WriteLine("TLS counter" +
                               "Enter frequency to find:");
      frequency = int.Parse(Console.ReadLine());

      try
      {
        using (StreamReader sr = new StreamReader(@"E:\Challenges\tls.txt"))
        {
          String text = sr.ReadToEnd();
          CountTls(text);
        }
      }
      catch (Exception e)
      {
        System.Console.WriteLine("The file could not be read.");
      }

      // Keep console window open in debug mode 
      System.Console.WriteLine("Any key to exit.");
      System.Console.ReadKey();
    }

    public static void CountTls(String text)
    {
      String tlsPattern = "(?=[a-z]{3})";
      Regex regex = new Regex(tlsPattern, RegexOptions.IgnoreCase);

      Match m = regex.Match(text);
      while (m.Success)
      {
        String tls = text.Substring(m.Index,3);
        if (dictionary.ContainsKey(tls))
        {
          dictionary[tls] = dictionary[tls] + 1;
        }
        else
        {
          dictionary.Add(tls, 1);
        }
        m = m.NextMatch();
      }

      foreach (KeyValuePair<string, int> entry in dictionary)
      {
        if (entry.Value == frequency)
        {
          System.Console.WriteLine(entry.Key + " " + frequency + " times");
        }
      }

    }
  }
}

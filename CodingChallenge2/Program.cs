namespace CodingChallenge2
{
  using System;
  using System.IO;

  internal class Program
  {
    private static void Main(string[] args)
    {
      var oneLine = new OneLineSolution();

      Console.WriteLine("TLS counter\n" +
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
        Console.WriteLine("The file could not be read.");
      }

      // Original solution
      // var counter = new Counter(frequency, text);
      // counter.CountTls();

      // One line of LINQ
      oneLine.SearchTlsFrequency(text, frequency);

      // Keep console window open in debug mode
      Console.WriteLine("Any key to exit.");
      Console.ReadKey();
    }
  }
}
namespace CodingChallenge2
{
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;

  internal class OneLineSolution
  {
    public void SearchTlsFrequency(String text, int frequency)
    {
      var inOneLine = Regex.Matches(text, @"(?=[a-z]{3})", RegexOptions.IgnoreCase).Cast<Match>().GroupBy(m => text.Substring(m.Index, 3).ToLower()).Where(g => g.Count() == frequency).Select(tls => tls.Key);
      foreach (var tls in inOneLine)
      {
        Console.WriteLine(tls + " " + frequency + " times");
      }
    }
  }
}
namespace CodingChallenge2
{
  using System;
  using System.Collections.Generic;
  using System.Text.RegularExpressions;

  internal class Counter
  {
    private readonly Dictionary<String, int> dictionary;
    private Regex regex;
    private readonly int frequency;
    private readonly string text;

    public Counter(int frequency, string text)
    {
      this.frequency = frequency;
      this.text = text;
      dictionary = new Dictionary<string, int>();
      DefineRegex();
    }

    public void CountTls()
    {
      FillDictionary();
      OutputToConsole();
    }

    private void DefineRegex()
    {
      const String tlsPattern = "(?=[a-z]{3})";
      regex = new Regex(tlsPattern, RegexOptions.IgnoreCase);
    }

    private void FillDictionary()
    {
      var match = regex.Match(text);
      while (match.Success)
      {
        var tls = text.Substring(match.Index, 3).ToLower();
        if (dictionary.ContainsKey(tls))
        {
          dictionary[tls] = dictionary[tls] + 1;
        }
        else
        {
          dictionary.Add(tls, 1);
        }
        match = match.NextMatch();
      }
    }

    private void OutputToConsole()
    {
      foreach (var entry in dictionary)
      {
        if (entry.Value == frequency)
        {
          Console.WriteLine(entry.Key + " " + frequency + " times");
        }
      }
    }
  }
}
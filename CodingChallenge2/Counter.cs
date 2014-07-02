using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodingChallenge2
{
  internal class Counter
  {
    private readonly Dictionary<String, int> dictionary;


    public Counter(int frequency, string text)
    {
      this.frequency = frequency;
      this.text = text;
      dictionary = new Dictionary<string, int>();
      DefineRegex();
    }

    private Regex regex { get; set; }
    private String tlsPattern { get; set; }
    private int frequency { get; set; }
    private string text { get; set; }

    public void CountTls()
    {
      FillDictionary();
      OutputToConsole();
    }

    private void DefineRegex()
    {
      tlsPattern = "(?=[a-z]{3})";
      regex = new Regex(tlsPattern, RegexOptions.IgnoreCase);
    }

    private void FillDictionary()
    {
      Match m = regex.Match(text);
      while (m.Success)
      {
        String tls = text.Substring(m.Index, 3);
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
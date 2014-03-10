using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class RelevanceIndex
{
    static void Main()
    {
        // Load data from local HDD if program is run in VS
        //bool debugPrint = false;
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Input.txt"));
            //debugPrint = true;
        }

        string search = Console.ReadLine();
        int paragraphs = int.Parse(Console.ReadLine());

        string[] texts = new string[paragraphs];
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i] = Console.ReadLine().Trim();
        }

        List<MatchCollection> numberOfSearch = new List<MatchCollection>();
        for (int i = 0; i < texts.Length; i++)
        {
            string pattern = "\\b" + search + "\\b";
            MatchCollection temp = Regex.Matches(texts[i], pattern, RegexOptions.IgnoreCase);
            numberOfSearch.Add(temp);
        }

        List<char> punktuations = new List<char>() { ',', '.', '(', ')', ';', '-', '!', '?' };

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < texts.Length; i++)
        {
            int start = result.Length;
            int index = GetMaxIndex(numberOfSearch);
            result.Append(texts[index]);
            MatchCollection currentMatch = numberOfSearch[index];
            numberOfSearch[index] = null;

            for (int j = 0; j < currentMatch.Count; j++)
            {
                int currentStart = start + currentMatch[j].Index;
                for (int k = currentStart; k < currentStart + search.Length; k++)
                {
                    result[k] = char.ToUpper(result[k]);
                }
            }

            for (int num = 0; num < punktuations.Count; num++)
            {
                result.Replace(punktuations[num], ' ', start, result.Length - start);
            }
            result.AppendLine();
        }

        string resulText = result.ToString();
        resulText = Regex.Replace(resulText, @"[ ]+", " ");
        Console.WriteLine(resulText);
    }

    static int GetMaxIndex(List<MatchCollection> matches)
    {
        int maxValue = int.MinValue;
        int index = -1; ;
        for (int i = 0; i < matches.Count; i++)
        {

            if (matches[i] != null && matches[i].Count > maxValue)
            {
                maxValue = matches[i].Count;
                index = i;
            }
        }
        return index;
    }
}


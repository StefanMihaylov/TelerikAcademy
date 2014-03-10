using System;
using System.Collections.Generic;
using System.Text;

class ExtractEmails
{
    //Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails

    static readonly List<char> symbols = new List<char>() { '_', '.', '-' };
    static readonly List<char> punctuation = new List<char>() { '.', ',', '!', '?', ':', ';' };

    const int minLength = 3;  // minimal length for username and domain name    

    static void CheckUserName(string currentEmail, int j, ref int userNameLength, ref int errorLetters)
    {
        if (j == 0)
        {
            if (char.IsLetter(currentEmail[j])) // first letter should be letter only
            {
                userNameLength++;
            }
            else
            {
                errorLetters++;
            }
        }
        else
        {
            if (char.IsLetterOrDigit(currentEmail[j]) || symbols.Contains(currentEmail[j]))
            {
                userNameLength++;
            }
            else
            {
                errorLetters++;
            }
        }
    }

    static List<string> ExtractEmailsFromText(string text)
    {
        List<string> emails = new List<string>();

        int index = text.IndexOf('@');
        while (index >= 0)
        {
            int start = text.LastIndexOf(' ', index);
            int end = text.IndexOf(' ', index);
            if (start >= 0 && end >= 0)
            {
                if (punctuation.Contains(text[end - 1]))
                {
                    emails.Add(text.Substring(start + 1, end - start - 2));
                }
                else
                {
                    emails.Add(text.Substring(start + 1, end - start - 1));
                }
            }
            index = text.IndexOf('@', index + 1);
        }

        return emails;
    }

    static void Main()
    {
        string text =
            @"Please contact us by phone (+359 222 222 222) or by email at example@gmail.com or at text.user@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";

        List<string> emails = ExtractEmailsFromText(text);
        bool[] remove = new bool[emails.Count];

        for (int i = 0; i < emails.Count; i++)
        {
            bool userName = false;
            bool domainName = false;
            bool domain = false;

            int userNameLength = 0;
            int domainNameLength = 0;
            int domain1Length = 0;
            int domain2Length = 0;
            int errorLetters = 0;

            string currentEmail = emails[i];
            for (int j = 0; j < currentEmail.Length; j++)
            {
                if (!userName)
                {
                    if (currentEmail[j] == '@')
                    {
                        userName = true;
                    }
                    else
                    {
                        CheckUserName(currentEmail, j, ref userNameLength, ref errorLetters);
                    }
                }
                else if (!domainName)
                {
                    if (currentEmail[j] == '.') // end of domain name
                    {
                        domainName = true;
                    }
                    else
                    {
                        if (char.IsLetterOrDigit(currentEmail[j]) || currentEmail[j] == '-')
                        {
                            domainNameLength++;
                        }
                        else
                        {
                            errorLetters++;
                        }
                    }
                }
                else if (!domain)
                {
                    if (currentEmail[j] == '.') // end of first part of domain (if exist)
                    {
                        domain = true;
                    }
                    else
                    {
                        if (char.IsLetter(currentEmail[j]))
                        {
                            domain1Length++;
                        }
                        else
                        {
                            errorLetters++;
                        }
                    }
                }
                else
                {
                    if (char.IsLetter(currentEmail[j]))
                    {
                        domain2Length++;
                    }
                    else
                    {
                        errorLetters++;
                    }
                }
            }

            bool isDomainCorrect = ((domain1Length == 3 || domain1Length == 4) && domain2Length == 0) ||
                (domain1Length == 2 && domain2Length == 2);

            if (errorLetters > 0 || userNameLength < minLength || domainNameLength < minLength || !isDomainCorrect)
            {
                remove[i] = true;
            }
        }

        for (int i = 0; i < emails.Count; i++) // remove and print. 
        {
            if (remove[i])
            {
                emails.RemoveAt(i);
            }
            else
            {
                Console.WriteLine(emails[i]);
            }
        }
    }
}


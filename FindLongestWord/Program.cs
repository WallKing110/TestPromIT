﻿using System.Text;

class Program
{
    static private string filename = "text.txt";
    static private Encoding encoding = Encoding.Default;
    static bool CheckExistanceAndCreateFile()
    {
        if (!File.Exists(filename))
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                string fillText = "Fill this file with your line.";
                byte[] fillBuffer = Encoding.Default.GetBytes(fillText);
                fs.Write(fillBuffer, 0, fillBuffer.Length);
                Console.WriteLine("Required file didn't exist. We created 'text.txt' for program.");
                fs.Close();
                return false;
            }
        }
        return true;
    }
    static string ReadStringFromFile()
    {
        FileStream fstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StringBuilder sb = new StringBuilder();
        byte[] buffer = new byte[1024];
        int bytesRead = 0;
        using (StreamReader sr = new StreamReader(fstream, encoding))
        {
            while ((bytesRead = fstream.Read(buffer, 0, buffer.Length)) > 0)
            {
                char[] chars = encoding.GetChars(buffer, 0, bytesRead);
                sb.Append(chars, 0, chars.Length);
            }
        }
        fstream.Close();
        string text = sb.ToString();
        return text;
    }
    static private bool checkString(string s)
    {
        Func<char, bool> checkChar = c =>
        {
            return (!char.IsLetter(c) && !char.IsSymbol(' ')) || char.IsDigit(c);
        };
        if (s.Any(c => checkChar(c)))
            return true;
        else
            return false;
    }
    static string GetAnswer(string text)
    {
        string[] arr = text.Split(' ');
        string maxStr = "";
        for (int i = 0; i < arr.Length; ++i)
        {
            if (checkString(arr[i]))
            {
                Console.WriteLine("String \"" + arr[i] + "\" contains unallowed character.");
                continue;
            }
            if (arr[i].Length > maxStr.Length)
            {
                maxStr = arr[i];
            }
        }

        return maxStr;
    }
    static public void Main()
    {
        if (!CheckExistanceAndCreateFile())
        {
            return;
        }

        string text = ReadStringFromFile();

        if (text.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        string answer = GetAnswer(text);

        if (answer.Length == 0)
        {
            Console.WriteLine("Text doesn't have valid words.");
        }
        else
        {
            Console.WriteLine(answer);
        }
    }
}
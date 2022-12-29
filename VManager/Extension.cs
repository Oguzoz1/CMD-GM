using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public static class Extension
    {
        public static string RemoveWhite(this string x)
        {
            string y = "";
            foreach(char i in x)
            {
                if (char.IsWhiteSpace(i))
                {
                     y = x.Remove(Array.IndexOf(x.ToCharArray(), i), 1);
                    return y;
                }
            }
            return x;
        }
        public static bool IsOnlyDigits(this string x)
        {
            foreach (char c in x)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        public static object GetInstance(this string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            if (t == null) throw new Exception("Type couldn't be found");
            else return Activator.CreateInstance(t);
        }
        public static int CountWord(string word, string str)
        {
            int count = 0;
            int track = 0;
            int prevTrack = 0;
            for (int i = 0; i < str.Length; i++)
            {
                prevTrack++;
                for (int j = 0; j < word.Length; j++)
                {
                    if (str[i] == word[j])
                    {
                        track++;
                        if (track % word.Length == 0) count++;
                        break;
                    }

                }
                if (prevTrack != track)
                {
                    prevTrack = 0;
                    track = 0;
                }
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMZI_2k19
{
    public class SimpleReplacementCipher
    {
        private readonly Dictionary<string, double> _multigramFrequency;
        private readonly int _n;

        public SimpleReplacementCipher(Dictionary<string, double> multigramFrequency, int n)
        {
            _multigramFrequency = multigramFrequency;
            _n = n;
        }

        public static string Encrypt(string message, string key)
        {
            var cipherText = new StringBuilder();

            foreach (var c in message)
                cipherText.Append(key[c - 'a']);

            return cipherText.ToString();
        }

        public static string Decrypt(string cipherText, string key)
        {
            key = GetDecryptKey(key);
            return Encrypt(cipherText, key);
        }

        private static string GetDecryptKey(string key)
        {
            var res = new StringBuilder();
            res.AppendLine(key);
            for (var c = 0; c < 26; c++)
                if(key[c]!='0')
                res[key[c] - 'a'] = Convert.ToChar(c + 'a');

            return res.ToString();
        }

        public void Hack(string cipherText)
        {
            var curMultigramrequency = GetMultigramFrequency(cipherText, _n);
            var firstKey = GetFirstKey(curMultigramrequency);

            Console.WriteLine("First key {0}", firstKey);
            Console.WriteLine("{0}", Decrypt(cipherText, firstKey));
            var step = 1;
            var curDev = Deviation(curMultigramrequency, firstKey);
            while (step < 26)
            {
                for (var i = 0; i + step < firstKey.Length; i++)
                {
                    var newKey = firstKey;
                    char a = newKey[i], b = newKey[i + step];
                    newKey = newKey.Replace(a, '0');
                    newKey = newKey.Replace(b, a);
                    newKey = newKey.Replace('0', b);

                    var newDev = Deviation(curMultigramrequency, newKey);
                    if (newDev < curDev)
                    {
                        curDev = newDev;
                        firstKey = newKey;
                        step = 0;
                        break;
                    }
                }

                step++;
            }

            Console.WriteLine("Key {0}", firstKey);
            Console.WriteLine("{0}", Decrypt(cipherText, firstKey));
        }

        private double Deviation(Dictionary<string, double> multigramFrequency, string key)
        {
            var res = 0.0;
            foreach (var p in _multigramFrequency)
            {
                if (p.Key.Length == 1)
                    continue;
                var s = Encrypt(p.Key, key);

                var d = p.Value;
                if (multigramFrequency.ContainsKey(s))
                    d -= multigramFrequency[s];
                res += Math.Abs(d);
            }

            return res;
        }

        private static Dictionary<string, double> GetMultigramFrequency(string text, int n)
        {
            var res = new Dictionary<string, double>();

            for (var len = 1; len <= n; len++)
            {
                var M = 100.0 / (text.Length - len + 1);
                for (var i = 0; i <= text.Length - len; i++)
                {
                    var gram = text.Substring(i, len);
                    if (res.ContainsKey(gram))
                        res[gram]+= M;
                    else
                        res.Add(gram, M);
                }
            }

            return res;
        }

        private string GetFirstKey(Dictionary<string, double> multigramFrequency)
        {
            var symbolsFrequency = _multigramFrequency.Where(x => x.Key.Length == 1).OrderBy(x => x.Value)
                .Select(x => x.Key[0] - 'a').ToList();
            var curSymbolsFrequency = multigramFrequency.Where(x => x.Key.Length == 1).OrderBy(x => x.Value)
                .Select(x => x.Key[0]).ToList();
            curSymbolsFrequency.Reverse();
            for (char c = 'a'; c<='z'; c++)
            {
                if(!curSymbolsFrequency.Contains(c))
                    curSymbolsFrequency.Add(c);
            }

            curSymbolsFrequency.Reverse();

            var key = new StringBuilder(new string('\0', 26));
            for (var i = 0; i < curSymbolsFrequency.Count; i++)
                key[symbolsFrequency[i]] = curSymbolsFrequency[i];

            return key.ToString();
        }
    }
}
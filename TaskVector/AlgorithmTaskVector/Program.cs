using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AlgorithmTaskVector
{
    class Program
    {
        private static string CipherEncoding(string inputText, int rails)
        {
            //check for input
            if (inputText == "")
                return "";
            else 
                if (rails >= 2)
                { 
                    inputText = inputText.ToUpper(); 
                    inputText = Regex.Replace(inputText, @"[^A-Z0-9]", string.Empty); 

                    var lines = new List<StringBuilder>();

                    for(int i = 0; i < rails; i++ )
                    {
                        lines.Add(new StringBuilder());
                    }

                    int currentLine = 0;
                    int direction = 1;

                    for(int i = 0; i < inputText.Length; i++)
                    {
                        lines[currentLine].Append(inputText[i]);

                        if (currentLine == 0)
                            direction = 1;
                        else if (currentLine == rails - 1)
                            direction = -1;

                        currentLine += direction;
                    }

                    StringBuilder result = new StringBuilder();

                    for(int i = 0; i < rails; i++)
                    {
                        result.Append(lines[i].ToString());
                    }

                    return result.ToString();
                }
                else
                {
                    return inputText;
                }
        }

        public static string CipherDecoding(string encryptText, int rails)
        {
            //check for input
            if (encryptText == "")
            { return ""; }
            else
            if (rails >= 2)
            {
                encryptText = encryptText.ToUpper(); //change for upper case
                encryptText = Regex.Replace(encryptText, @"[^A-Z0-9]", string.Empty);

                var lines = new List<StringBuilder>();

                for (int i = 0; i < rails; i++)
                    lines.Add(new StringBuilder());

                int[] linesLength = Enumerable.Repeat(0, rails).ToArray();

                int currentLine = 0;
                int direction = 1;

                for (int i = 0; i < encryptText.Length; i++)
                {
                    linesLength[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                int currentChar = 0;

                for (int line = 0; line < rails; line++)
                {
                    for (int j = 0; j < linesLength[line]; j++)
                    {
                        lines[line].Append(encryptText[currentChar]);
                        currentChar++;
                    }
                }

                StringBuilder result = new StringBuilder();

                currentLine = 0;
                direction = 1;

                int[] currentReadLine = Enumerable.Repeat(0, rails).ToArray();

                for (int i = 0; i < encryptText.Length; i++)
                {
                    result.Append(lines[currentLine][currentReadLine[currentLine]]);
                    currentReadLine[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                return result.ToString();
            }
            else
            {
                return encryptText;
            }
        }

        static void Main(string[] args)
        {
            int variant = 0;
            Console.WriteLine("Chose method of input:\n1 ready string \n2 input string ");
            variant = Convert.ToInt32(Console.ReadLine());
            if (variant==1)
            {
                string inputText = "WEare DiSCOVERED FLEEATONCE";
                Console.WriteLine("Input string : {0}", inputText);
                string res = CipherEncoding(inputText, 3);

                Console.WriteLine("Encoded string : {0}",res);

                string decryptText = CipherDecoding(res, 3);
                Console.WriteLine("Decoded string : {0}",decryptText);
            }
            else if (variant == 2)
            {
                Console.WriteLine("Please input you string to encrypt and decrypt");
                string inputText = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Please input number of rails (>2)");
                int rails = Convert.ToInt32(Console.ReadLine());

                string res = CipherEncoding(inputText,rails);
                Console.WriteLine("Encoded string : {0}", res);

                string decryptText = CipherDecoding(res,3);
                Console.WriteLine("Decoded string : {0}", decryptText);
            }
            else
            {
                Console.WriteLine("Wrong number, please run progrma again");
            }
        }
    }
}

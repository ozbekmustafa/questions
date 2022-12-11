using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question1
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1- Generate Code");
                Console.WriteLine("2- Check Code");
                Console.WriteLine("3- Exit");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        GenerateCodes(5);
                        break;
                    case "2":
                        string code = Console.ReadLine();
                        Console.WriteLine(CheckCode(code));
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("1- Generate Code");
                        Console.WriteLine("2- Check Code");
                        break;
                }
            }

            Console.ReadLine();
        }
        public static void GenerateCodes(int codeCount)
        {
            try
            {
                int generatedKeyCounter = 0;
                int keyLength = 8;
                const string charSet = "ACDEFGHKLMNPRTXYZ234579";
                const string staticKey = "KAIZEN1";
                Int64 staticKeyProduct = 1;

                byte[] asciiBytesOfKey = Encoding.ASCII.GetBytes(staticKey);
                foreach (var asciiCode in asciiBytesOfKey)
                {
                    staticKeyProduct *= Convert.ToInt32(asciiCode);
                }
                while (generatedKeyCounter != codeCount)
                {
                    Int64 generatedCodeProduct = 1;
                    string code = new string(Enumerable.Repeat(charSet, keyLength).Select(s => s[random.Next(s.Length)]).ToArray());
                    byte[] asciiBytesOfCode = Encoding.ASCII.GetBytes(code);
                    int distinctElementCount = asciiBytesOfCode.Distinct().Count();
                    if (distinctElementCount > 4 && distinctElementCount < 7)
                    {
                        foreach (var asciiCode in asciiBytesOfCode)
                        {
                            generatedCodeProduct *= Convert.ToInt32(asciiCode);
                        }

                        if (generatedCodeProduct / staticKeyProduct < 10)
                        {
                            Console.WriteLine(code);
                            generatedKeyCounter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static bool CheckCode(string code)
        {
            try
            {
                byte[] asciiBytesOfCode = Encoding.ASCII.GetBytes(code);
                int distinctElementCount = asciiBytesOfCode.Distinct().Count();
                if (distinctElementCount > 4 && distinctElementCount < 7 && !code.Any(char.IsLower) && code.Length == 8)
                {
                    Int64 staticKeyProduct = 1;
                    const string staticKey = "KAIZEN1";
                    byte[] asciiBytesOfStaticKey = Encoding.ASCII.GetBytes(staticKey);

                    foreach (var asciiCode in asciiBytesOfStaticKey)
                    {
                        staticKeyProduct *= Convert.ToInt32(asciiCode);
                    }

                    Int64 codeProduct = 1;
                    foreach (var asciiCode in asciiBytesOfCode)
                    {
                        codeProduct *= Convert.ToInt32(asciiCode);
                    }

                    if (codeProduct / staticKeyProduct < 10)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace Factorization
{
    class Program
    {
        public static List<int> GetPrimes(int n)
        {
            List<int> factors = new List<int>();
            //divide by 2 until not even or 0
            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }
            //get the rest of the factors
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }
            //ensure that the last prime value is added
            if (n > 2)
            {
                factors.Add(n);
            }
            return factors;
        }
        public static void Factorize(List<int> f, int n)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < f.Count; i++)
            {
                //ensure that the last value in the list is added properly
                if (i + 1 == f.Count || i == f.Count)
                {
                    output.Append(f[i]);
                }
                else
                {
                    output.Append(f[i]);
                    //if the value is repeated, raise the value to a power rather than multiply it repeatedly
                    if (!(f[i + 1] == f[i]))
                    {
                        output.Append(" x ");
                    }
                    else
                    {
                        int repeated = 2;

                        output.Append("^");
                        for (int j = i + 1; j < f.Count; j++)
                        {
                            if (f[j + 1] == f[j])
                            {
                                repeated++;
                            }
                            else
                            {
                                i = j;

                                break;
                            }
                        }
                        output.Append(repeated);
                        output.Append(" x ");
                    }
                }
            }
            Console.WriteLine("Factorized: " + output);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer");
            string entry = Console.ReadLine();
            int number = int.Parse(entry);

            List<int> f = GetPrimes(number);
            Factorize(f, number);
        }
    }
}

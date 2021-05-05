using System;

namespace CodeWars
{
    public static class CountMultiples
    {
        // n Number Of Primes, All Factors Of Primes Under mxval
        public static long CountSpecMult(long n, long mxval)
        {
            //Console.WriteLine($"N: {n}");
            //Console.WriteLine($"Max Value: {mxval}");

            // Stores First n Primes
            long[] primes = new long[n];
            long count = 0;

            // Gets n Number of Primes
            bool isValid;

            long i, j;

            for (i = 2; count < n; i++)
            {
                isValid = true;

                // Checks If Current Number Is Not Prime
                for (j = i-1; j-1 > 0; j--)
                {
                    if (i % j == 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                // Adds Prime Number to the primes List
                if (isValid)
                {
                    primes[count] = i;
                    count++;
                }
            }

            count = 0;
            // Checks All Natural Numbers Under mxval for Multiples of all Primes
            for (i=mxval-1; i-1 > 0; i--)
            {
                isValid = true;

                // Makes Sure i Is A Multiple Of Every Given Prime
                for (j = n-1; j+1 > 0; j--)
                {
                    if (i % primes[j] != 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid) count++;
            }            

            return count;
        }
    }
}


namespace CodeWars
{
    public class CountMultiples
    {
        // n Number Of Primes, All Factors Of Primes Under mxval
        public static long CountSpecMult(long n, long mxval)
        {
            // Stores First n Primes
            long[] primes = new long[n];
            long count = 0;

            // Gets n Number of Primes
            bool isValid = true;

            for (long i = 2; count < n; i++)
            {
                isValid = true;

                // Checks If Current Number Is Not Prime
                //for (long j = 2; j < i; j++)
                for (long j = i-1; j > 1; j--)
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
            //for (long i=2; i < mxval; i++)
            for (long i=mxval-1; i > 1; i--)
            {
                isValid = true;

                // Makes Sure i Is A Multiple Of Every Given Prime
                //foreach (long prime in primes)
                //for (long j = 0; j < n; j++)
                for (long j = n-1; j > -1; j--)
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

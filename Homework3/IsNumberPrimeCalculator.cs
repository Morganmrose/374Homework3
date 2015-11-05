using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework3 {
    internal class IsNumberPrimeCalculator {
        
      
        //private readonly Queue<long> _numbersToCheck;
        private BoundBuffer<long> BoundBuff;

        public IsNumberPrimeCalculator(List<long> primeNumbers, Queue<long> _queue) {
            //set as BoundBuffers
            BoundBuff = new BoundBuffer<long>();
            BoundBuff.SetList(primeNumbers);
            BoundBuff.SetQueue(_queue);

        }

        public void CheckIfNumbersArePrime()
        {
            while (true)
            {
                lock (BoundBuff.GetQueue())
                {
                    if (BoundBuff.GetQueue().Count != 0)
                    {
                        var numberToCheck = BoundBuff.GetQueue().Dequeue();

                        if (IsNumberPrime(numberToCheck))
                        {
                            BoundBuff.GetList().Add(numberToCheck);

                        }
                    }
                }
            }
        }

        private bool IsNumberPrime(long numberWeAreChecking) {
            const long firstNumberToCheck = 3;

            if (numberWeAreChecking % 2 == 0) {
                return false;
            }
            var lastNumberToCheck = Math.Sqrt(numberWeAreChecking);
            for (var currentDivisor = firstNumberToCheck; currentDivisor < lastNumberToCheck; currentDivisor += 2) {
                if (numberWeAreChecking % currentDivisor == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
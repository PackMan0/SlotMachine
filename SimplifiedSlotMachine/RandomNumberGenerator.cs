using System;

namespace SimplifiedSlotMachine
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GetRandomPercentage()
        {
            var rand = new Random();
            return rand.Next(1, 101);
        }
    }
}

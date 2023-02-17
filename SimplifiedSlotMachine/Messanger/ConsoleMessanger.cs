using System;
using SimplifiedSlotMachine.Interfaces;

namespace SimplifiedSlotMachine.Messanger
{
    public class ConsoleMessanger : IMessanger
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public double ReceiveMessage()
        {
            double input = Constants.ZERO_DOUBLE_VALUE;

            double.TryParse(Console.ReadLine(), out input);

            return input;
        }
    }
}

using System;
using System.Threading;
using Pi.IO.GeneralPurpose;
using Pi.IO;

namespace BlinkLED
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new GpioConnectionDriver();
            var ledPin = driver.Out(ConnectorPin.P1Pin23);

            bool ledState = false;
            while (true)
            {
                ledPin.Write(ledState);
                Thread.Sleep(500);
                ledState = ledState ? false : true;
            }
        }
    }
}

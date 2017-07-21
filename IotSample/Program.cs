using System;
using System.Threading;
using Pi.IO.Components.Converters.Mcp3008;
using Pi.IO.GeneralPurpose;
using Pi.IO;

namespace IotSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bmp280 = new BMP280();
            bmp280.Initialize();

            const ConnectorPin adcClock = ConnectorPin.P1Pin23;
            const ConnectorPin adcMiso = ConnectorPin.P1Pin21;
            const ConnectorPin adcMosi = ConnectorPin.P1Pin19;
            const ConnectorPin adcCs = ConnectorPin.P1Pin24;

            const ConnectorPin pir = ConnectorPin.P1Pin31;
            const ConnectorPin led = ConnectorPin.P1Pin29;

            var driver = new GpioConnectionDriver();

            var adcConnection = new Mcp3008SpiConnection(
                driver.Out(adcClock),
                driver.Out(adcCs),
                driver.In(adcMiso),
                driver.Out(adcMosi));

            var pirPin = driver.In(pir);
            var ledPin = driver.Out(led);

            bool ledState = false;
            ledPin.Write(ledState);

            while (true)
            {
                Thread.Sleep(500);

                // Read the temperature and pressure
                float p = bmp280.ReadPreasure().Result;
                float t = bmp280.ReadTemperature().Result;

                float tempF = (t * 9 / 5 + 32);
                float pressureInHg = p * .295357F / 1000;

                Console.WriteLine("Pressure: " + pressureInHg + " inHg");
                Console.WriteLine("Temperature: " + tempF + " F");
                
                // Read the analog inputs
                AnalogValue a0 = adcConnection.Read(Mcp3008Channel.Channel0);
                AnalogValue a1 = adcConnection.Read(Mcp3008Channel.Channel1);
                AnalogValue a2 = adcConnection.Read(Mcp3008Channel.Channel2);

                Console.WriteLine("Value 1: " + a0.Value);
                Console.WriteLine("Value 2: " + a1.Value);
                Console.WriteLine("Value 3: " + a2.Value);

                // Read the pir sensor
                var pirState = pirPin.Read();
                Console.WriteLine("Pir Pin Value: " + pirState.ToString());
                if (pirState && !ledState)
                {
                    ledState = true;
                    ledPin.Write(ledState);
                }
                else if (!pirState && ledState)
                {
                    ledState = false;
                    ledPin.Write(ledState);
                }
            }
        }
    }
}

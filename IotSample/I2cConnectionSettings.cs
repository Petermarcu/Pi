using System;
using System.Collections.Generic;
using System.Text;

namespace IotSample
{
    public class I2cConnectionSettings
    {
        private byte baseAddress;
        public I2cConnectionSettings(byte baseAddress)
        {
            this.baseAddress = baseAddress;
        }
    }
}

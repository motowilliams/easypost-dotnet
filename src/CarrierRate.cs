using System;

namespace Easypost
{
    public class CarrierRate
    {
        public string Carrier { get; set; }
        public string Service { get; set; }
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return string.Format("Carrier: {0}, Service: {1}, Rate: {2}", Carrier, Service, Rate);
        }
    }
}
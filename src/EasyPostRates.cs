using System;

namespace Easypost
{
    public class EasyPostRates : ReponseBase
    {
        public CarrierRate[] Rates { get; set; }
    }
}
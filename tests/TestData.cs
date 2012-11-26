using System;
using Easypost;

namespace tests
{
    public static class TestData
    {
        public static Address _inputAddress = new Address { Street1 = "388 Townsend St", Street2 = "Apt 20", City = "San Francisco", State = "CA", Zip = "94107" };
        public static Parcel customParcel = new Parcel { Height = 8.0m, Length = 10.0m, Width = 5.0m, Weight = 10.0m };
        public static Parcel predefinedParcel = new Parcel { PredefinedPackage = UspsParcelType.MediumFlatRateBox, Weight = 10m };

        public static PostagePurchase predefinedPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = predefinedParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };

        public static PostagePurchase customPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = customParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };
    }
}
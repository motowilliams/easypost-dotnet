using System;
using Easypost;

namespace tests
{
    public static class TestData
    {
        public static Address InputAddress = new Address { Street1 = "388 Townsend St", Street2 = "Apt 20", City = "San Francisco", State = "CA", Zip = "94107" };
        public static Address OutputAddress = new Address { Street1 = "388 Townsend St Apt 20", Street2 = null, City = "San Francisco", State = "CA", Zip = "94107" };
        public static Parcel CustomParcel = new Parcel { Height = 8.0m, Length = 10.0m, Width = 5.0m, Weight = 10.0m };
        public static Parcel PredefinedParcel = new Parcel { PredefinedPackage = UspsParcelType.MediumFlatRateBox, Weight = 10m };

        public static PostagePurchase PredefinedPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = PredefinedParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };

        public static PostagePurchase CustomPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = CustomParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };
    }
}
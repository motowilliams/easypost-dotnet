using System;

namespace Easypost
{
    /// <summary>
    /// USPS predefined packages 
    /// </summary>
    public enum UspsParcelType
    {
        Unknown,
        Card,
        Letter,
        Flat,
        Parcel,
        LargeParcel,
        IrregularParcel,
        FlatRateEnvelope,
        FlatRateLegalEnvelope,
        FlatRatePaddedEnvelope,
        FlatRateGiftCardEnvelope,
        FlatRateWindowEnvelope,
        FlatRateCardboardEnvelope,
        SmallFlatRateEnvelope,
        SmallFlatRateBox,
        MediumFlatRateBox,
        LargeFlatRateBox,
        RegionalRateBoxA,
        RegionalRateBoxB,
        RegionalRateBoxC,
        LargeFlatRateBoardGameBox
    }
}
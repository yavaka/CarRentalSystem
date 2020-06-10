using CarRentalSystem.Domain.Common;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class TransmissionType : Enumeration
    {
        public static readonly TransmissionType Manual = new TransmissionType(1, nameof(Manual));

        public static readonly TransmissionType Automatic = new TransmissionType(1, nameof(Automatic));

        public TransmissionType(int value, string name)
            : base(value, name) { }
    }
}
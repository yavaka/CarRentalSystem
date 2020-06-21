using CarRentalSystem.Domain.Common;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class TransmissionType : Enumeration
    {
        public static readonly TransmissionType Manual = new TransmissionType(0, nameof(Manual));

        public static readonly TransmissionType Automatic = new TransmissionType(1, nameof(Automatic));

        public TransmissionType(int value, string name)
            : base(value, name) { }

        //DDD rule: entities cannot be created with an invalid state.
        //EF Core wants constructors that bind non-navigational props.
        private TransmissionType(int value)
            : base(value, default!) { }
    }
}
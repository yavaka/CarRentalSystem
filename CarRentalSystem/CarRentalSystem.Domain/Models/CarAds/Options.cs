using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using static CarRentalSystem.Domain.Models.ValidationConstants.Options;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class Options : ValueObject
    {
        //DDD rule: only aggregate root entities` constructors should be public
        //DDD rule: the constructor should validate object/s
        internal Options(bool hasClimateControl, int seats, TransmissionType transmissionType) 
        {
            this.Validate(seats);

            this.HasClimateControl = hasClimateControl;
            this.Seats = seats;
            this.TransmissionType = transmissionType;
        }

        //DDD rule: entities cannot be created with an invalid state.
        //EF Core wants constructors that bind non-navigational props.
        private Options(bool hasClimateControl, int seats)
        {
            this.HasClimateControl = hasClimateControl;
            this.Seats = seats;
            this.TransmissionType = default!;
        }


        public bool HasClimateControl { get; }

        public int Seats { get; }
        
        public TransmissionType TransmissionType{ get; }


        private void Validate(int seats)
        {
            Guard.AgainstOutOfRange<InvalidOptionsException>(
                seats,
                MinNumberOfSeats,
                MaxNumberOfSeats,
                nameof(this.Seats));
        }
    }
}
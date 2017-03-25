using GalaSoft.MvvmLight;

namespace EaglesNestMobileApp.Core.Model
{
    public class Student : ObservableObject
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PreferredName { get; set; }
        public string StudentEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string CellPhone { get; set; }
        public string Dorm { get; set; }
        public string RoomNumber { get; set; }
        public string DegreeName { get; set; }
        public string MajorName { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string CollegianName { get; set; }
        public string CollegianMascot { get; set; }
        public string CollegianLocation { get; set; }
        public string BoxNumber { get; set; }
        public string BoxCombination { get; set; }
        public string Section { get; set; }
        public string Row { get; set; }
        public string SeatNumber { get; set; }
        public string DoorNumber { get; set; }
        public string Classification { get; set; } //NOT IN AZURE DB FOR SOME REASON

        /* These strings return the concatenated/ formatted version of data                 */
        public string FormattedName => $"{LastName}, {FirstName} {MiddleName} ({PreferredName})";
        public string FormattedChapelSeat => $"{Section}, {Row}, {SeatNumber}";
        public string FormattedAddress => $"{AddressLineOne}\n{City}, {State} {Zip}\n{Country}";
        public string FormattedCollegian => $"{CollegianName} {CollegianMascot} ({CollegianLocation})";
    }
}

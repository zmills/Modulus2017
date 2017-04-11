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
        public string MinorName { get; set; }
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
        public string Floor { get; set; }
        public string Row { get; set; }
        public string SeatNumber { get; set; }
        public string DoorNumber { get; set; }
        public string Classification { get; set; } //NOT IN AZURE DB FOR SOME REASON

        public string FullName
        {
            get
            {
                string _fullName = LastName;

                /* If first name exist, determine how to append to full name.  */
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(_fullName))
                        _fullName += ", ";

                    _fullName += FirstName;
                }

                /* If middle name exist, determine how to append to full name. */
                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    if (!string.IsNullOrWhiteSpace(_fullName))
                    {
                        if (string.IsNullOrWhiteSpace(FirstName))
                            _fullName += ", ";
                        else
                            _fullName += " ";
                    }
                    _fullName += MiddleName;
                }
                return _fullName;
            }
        }

        /* These strings return the concatenated/ formatted version of data                 */
        public string FormattedName => $"{FullName} ({PreferredName})";
        public string FormattedRoom => $"{Dorm} {RoomNumber}-1";
        public string FormattedRoomPhone => $"17-{RoomNumber}-1";
        public string FormattedCellPhone => $"C: {CellPhone}";
        public string FormattedStudentAddress => $"{FirstName} {LastName}\n" +
            $"PCC Box {BoxNumber}\n250 Brent Lane\nPensacola, FL  32503-2287";
        public string FormattedChapelRow => $"Row {Row}, Seat {SeatNumber}";
        public string FormattedChapelSection {
            get
            {
                if (Floor == "Main Floor")
                    return $"{Floor} {Section}";
                else
                    return $"{Floor} Section {Section}";

            }
        }
        public string FormattedAddress => $"{FirstName} {LastName}\n{AddressLineOne}\n" +
                                          $"{City}, {State} {Zip}\n{Country}";
        public string FormattedCollegian => $"{CollegianName} {CollegianMascot}";
    }
}

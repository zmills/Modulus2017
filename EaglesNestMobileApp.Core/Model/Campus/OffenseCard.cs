using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Campus
{
    public class OffenseCard
    {
        public string TotalDemerits { get; set; } = "0";
        public string TotalResidenceHallInfractions { get; set; } = "0";
        public string TotalUnexcusedAbsences { get; set; } = "0";
        public string TotalLateOutIntoInfractions { get; set; } = "0";
        public string StudentCourtStatus { get; set; } = "0";
        public ObservableCollection<Offense> Offenses { get; set; } =
            new ObservableCollection<Offense>();


        public OffenseCard() { }

        public OffenseCard(List<Offense> offenses, List<OffenseCategory> infractions, string unexcusedAbsences)
        {
            TotalUnexcusedAbsences = unexcusedAbsences;

            float demerits = 0;

            foreach (var item in offenses)
            {
                Offenses.Add(item);
                demerits += item.Demerits;
            }

            TotalDemerits = demerits.ToString();

            if (Offenses.Count == 0)
                StudentCourtStatus = App.StudentCourtStatus.Green;
            else
            {
                StudentCourtStatus = App.StudentCourtStatus.Gray;

                if (infractions.Count == 0)
                {
                    TotalLateOutIntoInfractions = "0";
                    TotalResidenceHallInfractions = "0";
                }
                else
                {
                    foreach (var item in infractions)
                    {
                        if (item.Category == App.InfractionCategory.ResidenceHallInfraction)
                            TotalResidenceHallInfractions = item.TotalCategoryCount;
                        else if (item.Category == App.InfractionCategory.LateOutIntoInfraction)
                            TotalLateOutIntoInfractions = item.TotalCategoryCount;
                        else
                            StudentCourtStatus = App.StudentCourtStatus.Red;
                    }
                }

            }
        }
    }
}

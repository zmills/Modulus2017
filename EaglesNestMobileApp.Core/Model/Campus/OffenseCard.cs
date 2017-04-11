using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Campus
{
    public class OffenseCard
    {
        public string TotalDemerits { get; set; }
        public string TotalResidenceHallInfractions { get; set; }
        public string TotalUnexcusedAbsences { get; set; }
        public string TotalLateOutIntoInfractions { get; set; }
        public string StudentCourtStatus { get; set; }
        public ObservableCollection<Offense> Offenses { get; set; } =
            new ObservableCollection<Offense>();


        public OffenseCard(List<Offense> offenses, List<OffenseCategory> infractions, string unexcusedAbsences)
        {
            TotalUnexcusedAbsences = unexcusedAbsences;

            foreach (var item in offenses)
            {
                Offenses.Add(item);
            }

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

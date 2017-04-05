using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model.Personal;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class ScheduleFragmentViewModel : ViewModelBase
    {
        private List<ScheduleEvent> Events = new List<ScheduleEvent>();

        public ObservableCollection<ObservableCollection<ScheduleEvent>> Schedule
            = new ObservableCollection<ObservableCollection<ScheduleEvent>>
            {
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
                new ObservableCollection<ScheduleEvent>(),
            };

        readonly IAzureService Database;

        public ScheduleFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public void InitializeStatic()
        {
            for (int count = 0; count < 7; count++)
            {
                var studentEvent = new ScheduleEvent
                {
                    Title = $"My Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House"
                };
            }

            SortEvents();
        }

        private void SortEvents()
        {
            foreach (var current in Events)
            {
                switch (current.Day)
                {
                    case "Sunday":
                        Schedule[0].Add(current);
                        break;
                    case "Monday":
                        Schedule[1].Add(current);
                        break;
                    case "Tuesday":
                        Schedule[2].Add(current);
                        break;
                    case "Wednesday":
                        Schedule[3].Add(current);
                        break;
                    case "Thursday":
                        Schedule[4].Add(current);
                        break;
                    case "Friday":
                        Schedule[5].Add(current);
                        break;
                    case "Saturday":
                        Schedule[6].Add(current);
                        break;
                }
            }
        }
    }
}

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

        /* This list starts on SUNDAY                                          */
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
                    Title = $"My Sunday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Sunday"
                };
                Events.Add(studentEvent);

                var student2Event = new ScheduleEvent
                {
                    Title = $"My Monday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Monday"
                };
                Events.Add(student2Event);

                var student3Event = new ScheduleEvent
                {
                    Title = $"My Tuesday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Tuesday"
                };
                Events.Add(student3Event);

                var student4Event = new ScheduleEvent
                {
                    Title = $"My Wednesday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Wednesday"
                };
                Events.Add(student4Event);

                var student5Event = new ScheduleEvent
                {
                    Title = $"My Thursday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Thursday"
                };
                Events.Add(student5Event);

                var student6Event = new ScheduleEvent
                {
                    Title = $"My Friday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Friday"
                };
                Events.Add(student6Event);

                var student7Event = new ScheduleEvent
                {
                    Title = $"My Saturday Event {count}",
                    Time = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Saturday"
                };
                Events.Add(student7Event);
            }

            SortEvents();
        }

        private void SortEvents()
        {
            foreach (var current in Events)
            {
                switch (current.Day)
                {
                    case App.Days.Sunday:
                        Schedule[0].Add(current);
                        break;
                    case App.Days.Monday:
                        Schedule[1].Add(current);
                        break;
                    case App.Days.Tuesday:
                        Schedule[2].Add(current);
                        break;
                    case App.Days.Wednesday:
                        Schedule[3].Add(current);
                        break;
                    case App.Days.Thursday:
                        Schedule[4].Add(current);
                        break;
                    case App.Days.Friday:
                        Schedule[5].Add(current);
                        break;
                    case App.Days.Saturday:
                        Schedule[6].Add(current);
                        break;
                }
            }
        }
    }
}

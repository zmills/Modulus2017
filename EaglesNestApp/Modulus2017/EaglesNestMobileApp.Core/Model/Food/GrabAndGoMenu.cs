using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class GrabAndGoMenu : ObservableObject
    {
        public ObservableCollection<ObservableCollection<GrabAndGoItem>> LunchMenu
            = new ObservableCollection<ObservableCollection<GrabAndGoItem>>
            {
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>()
            };
        public ObservableCollection<ObservableCollection<GrabAndGoItem>> DinnerMenu
            = new ObservableCollection<ObservableCollection<GrabAndGoItem>>
            {
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>(),
                new ObservableCollection<GrabAndGoItem>()
            };

        public void AddItem(GrabAndGoItem item)
        {
            if (item.MealTime == App.MealTimes.Lunch)
                AddLunchItem(item);
            else
                AddDinnerItem(item);
        }

        private void AddLunchItem(GrabAndGoItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LunchMenu[0].Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LunchMenu[1].Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LunchMenu[2].Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LunchMenu[3].Add(item);
                    break;
            }
        }

        private void AddDinnerItem(GrabAndGoItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    DinnerMenu[0].Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    DinnerMenu[1].Add(item);
                    break;
                case App.LineKeys.LineThree:
                    DinnerMenu[2].Add(item);
                    break;
                case App.LineKeys.LineFour:
                    DinnerMenu[3].Add(item);
                    break;
            }
        }
    }
}
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class FourWindsMenu : ObservableObject
    {
        public ObservableCollection<ObservableCollection<FourWindsItem>> BreakfastMenu
            = new ObservableCollection<ObservableCollection<FourWindsItem>>
            {
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>()
            };
        public ObservableCollection<ObservableCollection<FourWindsItem>> LunchMenu
            = new ObservableCollection<ObservableCollection<FourWindsItem>>
            {
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>()
            };
        public ObservableCollection<ObservableCollection<FourWindsItem>> DinnerMenu
            = new ObservableCollection<ObservableCollection<FourWindsItem>>
            {
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>(),
                new ObservableCollection<FourWindsItem>()
            };


        // Move to app class
        public void AddItem(FourWindsItem item)
        {
            switch (item.MealTime)
            {
                case App.MealTimes.Breakfast:
                    AddBreakFastItem(item);
                    break;
                case App.MealTimes.Lunch:
                    AddLunchItem(item);
                    break;
                case App.MealTimes.Dinner:
                    AddDinnerItem(item);
                    break;
                default:
                    Debug.WriteLine(" Must be a stupid event like bible conference picnics or Christmas lights...go to taco bell.");
                    break;
            }
        }

        private void AddBreakFastItem(FourWindsItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    BreakfastMenu[0].Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    BreakfastMenu[1].Add(item);
                    break;
                case App.LineKeys.LineThree:
                    BreakfastMenu[2].Add(item);
                    break;
                case App.LineKeys.LineFour:
                    BreakfastMenu[3].Add(item);
                    break;
                case App.LineKeys.LineFive:
                    BreakfastMenu[4].Add(item);
                    break;
                case App.LineKeys.LineSix:
                    BreakfastMenu[5].Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    BreakfastMenu[6].Add(item);
                    break;
            }
        }

        private void AddLunchItem(FourWindsItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    { 
                        LunchMenu[0].Add(item);
                        DinnerMenu[0].Add(item);
                    }
                    break;
                case App.LineKeys.LineTwo:
                    {
                        LunchMenu[1].Add(item);
                        DinnerMenu[1].Add(item);
                    }
                    break;
                case App.LineKeys.LineThree:
                    {
                        LunchMenu[2].Add(item);
                        DinnerMenu[2].Add(item);
                    }
                    break;
                case App.LineKeys.LineFour:
                    {
                        LunchMenu[3].Add(item);
                        DinnerMenu[3].Add(item);
                    }
                    break;
                case App.LineKeys.LineFive:
                    {
                        LunchMenu[4].Add(item);
                        DinnerMenu[4].Add(item);
                    }
                    break;
                case App.LineKeys.LineSix:
                    {
                        LunchMenu[5].Add(item);
                        DinnerMenu[5].Add(item);
                    }
                    break;
                case App.LineKeys.LineSeven:
                    {
                        LunchMenu[6].Add(item);
                        DinnerMenu[6].Add(item);
                    }
                    break;
            }
        }

        private void AddDinnerItem(FourWindsItem item)
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
                case App.LineKeys.LineFive:
                    DinnerMenu[4].Add(item);
                    break;
                case App.LineKeys.LineSix:
                    DinnerMenu[5].Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    DinnerMenu[6].Add(item);
                    break;
            }
        }
    }
}

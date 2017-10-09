using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class VarsityMenu : ObservableObject
    {
        public ObservableCollection<ObservableCollection<VarsityItem>> BreakfastMenu
            = new ObservableCollection<ObservableCollection<VarsityItem>>
            {
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>()
            };
        public ObservableCollection<ObservableCollection<VarsityItem>> LunchMenu
            = new ObservableCollection<ObservableCollection<VarsityItem>>
            {
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>()
            };
        public ObservableCollection<ObservableCollection<VarsityItem>> DinnerMenu
            = new ObservableCollection<ObservableCollection<VarsityItem>>
            {
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>(),
                new ObservableCollection<VarsityItem>()
            };

        public VarsityMenu()
        {
            //GetMealTime(App.MealTimes.Breakfast);
        }

        public void AddItem(VarsityItem item)
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

        private void AddBreakFastItem(VarsityItem item)
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
            }
        }

        private void AddLunchItem(VarsityItem item)
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
                case App.LineKeys.LineFive:
                    LunchMenu[4].Add(item);
                    break;

            }
        }

        private void AddDinnerItem(VarsityItem item)
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
            }
        }
    }
}

using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class FourWindsMenu : ObservableObject
    {
        private ObservableCollection<FourWindsItem> LineOneBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineTwoBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineThreeBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFourBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFiveBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSixBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSevenBreakfast = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineOneLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineTwoLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineThreeLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFourLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFiveLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSixLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSevenLunch = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineOneDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineTwoDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineThreeDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFourDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineFiveDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSixDinner = new ObservableCollection<FourWindsItem>();
        private ObservableCollection<FourWindsItem> LineSevenDinner = new ObservableCollection<FourWindsItem>();

        public ObservableCollection<FourWindsItem> LineOne { get; set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineTwo { get; private set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineThree { get; private set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineFour { get; private set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineFive { get; private set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineSix { get; private set; } = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> LineSeven { get; private set; } = new ObservableCollection<FourWindsItem>();

        public FourWindsMenu()
        {
            GetMealTime(App.MealTimes.Breakfast);
        }


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
                    LineOneBreakfast.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoBreakfast.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeBreakfast.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourBreakfast.Add(item);
                    break;
                case App.LineKeys.LineFive:
                    LineFiveBreakfast.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixBreakfast.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenBreakfast.Add(item);
                    break;
            }
        }

        private void AddLunchItem(FourWindsItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LineOneLunch.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoLunch.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeLunch.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourLunch.Add(item);
                    break;
                case App.LineKeys.LineFive:
                    LineFiveLunch.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixLunch.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenLunch.Add(item);
                    break;
            }
        }

        private void AddDinnerItem(FourWindsItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LineOneDinner.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoDinner.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeDinner.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourDinner.Add(item);
                    break;
                case App.LineKeys.LineFive:
                    LineFiveDinner.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixDinner.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenDinner.Add(item);
                    break;
            }
        }

        public void GetMealTime(string mealTime)
        {
            switch (mealTime)
            {
                case App.MealTimes.Breakfast:
                    {
                        LineOne = LineOneBreakfast;
                        LineTwo = LineTwoBreakfast;
                        LineThree = LineThreeBreakfast;
                        LineFour = LineFourBreakfast;
                        LineFive = LineFiveBreakfast;
                        LineSix = LineSixBreakfast;
                        LineSeven = LineSevenBreakfast;
                    }
                    break;
                case App.MealTimes.Lunch:
                    {
                        LineOne = LineOneLunch;
                        LineTwo = LineTwoLunch;
                        LineThree = LineThreeLunch;
                        LineFour = LineFourLunch;
                        LineFive = LineFiveLunch;
                        LineSix = LineSixLunch;
                        LineSeven = LineSevenLunch;
                    }
                    break;
                case App.MealTimes.Dinner:
                    {
                        LineOne = LineOneDinner;
                        LineTwo = LineTwoDinner;
                        LineThree = LineThreeDinner;
                        LineFour = LineFourDinner;
                        LineFive = LineFiveDinner;
                        LineSix = LineSixDinner;
                        LineSeven = LineSevenDinner;
                    }
                    break;
                default:
                    Debug.WriteLine("An incorrenct meal time was passed to the FourWindsMenu Class");
                    break;
            }
        }

        public void ClearLines()
        {
            LineOne.Clear();
            LineTwo.Clear();
            LineThree.Clear();
            LineFour.Clear();
            LineFive.Clear();
            LineSix.Clear();
            LineSeven.Clear();
        }
    }
}

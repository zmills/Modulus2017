using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class VarsityMenu : ObservableObject
    {
        private ObservableCollection<VarsityItem> LineOneBreakfast =   new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineTwoBreakfast =   new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineThreeBreakfast = new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFourBreakfast =  new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFiveBreakfast =  new ObservableCollection<VarsityItem>();                                             
        private ObservableCollection<VarsityItem> LineOneLunch =       new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineTwoLunch =       new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineThreeLunch =     new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFourLunch =      new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFiveLunch =      new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineOneDinner =      new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineTwoDinner =      new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineThreeDinner =    new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFourDinner =     new ObservableCollection<VarsityItem>();
        private ObservableCollection<VarsityItem> LineFiveDinner =     new ObservableCollection<VarsityItem>();

        public ObservableCollection<VarsityItem> LineOne { get; set; } = new ObservableCollection<VarsityItem>();
        public ObservableCollection<VarsityItem> LineTwo { get; private set; } = new ObservableCollection<VarsityItem>();
        public ObservableCollection<VarsityItem> LineThree { get; private set; } = new ObservableCollection<VarsityItem>();
        public ObservableCollection<VarsityItem> LineFour { get; private set; } = new ObservableCollection<VarsityItem>();
        public ObservableCollection<VarsityItem> LineFive { get; private set; } = new ObservableCollection<VarsityItem>();

        public VarsityMenu()
        {
            GetMealTime(App.MealTimes.Breakfast);
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
            }
        }

        private void AddLunchItem(VarsityItem item)
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

            }
        }

        private void AddDinnerItem(VarsityItem item)
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
                    }
                    break;
                case App.MealTimes.Lunch:
                    {
                        LineOne = LineOneLunch;
                        LineTwo = LineTwoLunch;
                        LineThree = LineThreeLunch;
                        LineFour = LineFourLunch;
                        LineFive = LineFiveLunch;
                    }
                    break;
                case App.MealTimes.Dinner:
                    {
                        LineOne = LineOneDinner;
                        LineTwo = LineTwoDinner;
                        LineThree = LineThreeDinner;
                        LineFour = LineFourDinner;
                        LineFive = LineFiveDinner;
                    }
                    break;
                default:
                    Debug.WriteLine("An incorrenct meal time was passed to the FourWindsMenu Class");
                    break;
            }
        }
    }
}

using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class GrabAndGoMenu : ObservableObject
    {
        // MUST BE MADE PRIVATE
        private ObservableCollection<GrabAndGoItem> LineOneLunch = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineTwoLunch = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineThreeLunch = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineFourLunch = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineOneDinner = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineTwoDinner = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineThreeDinner = new ObservableCollection<GrabAndGoItem>();
        private ObservableCollection<GrabAndGoItem> LineFourDinner = new ObservableCollection<GrabAndGoItem>();
        
        public ObservableCollection<GrabAndGoItem> LineOne { get; set; } = new ObservableCollection<GrabAndGoItem>();
        public ObservableCollection<GrabAndGoItem> LineTwo { get; private set; } = new ObservableCollection<GrabAndGoItem>();
        public ObservableCollection<GrabAndGoItem> LineThree { get; private set; } = new ObservableCollection<GrabAndGoItem>();
        public ObservableCollection<GrabAndGoItem> LineFour { get; private set; } = new ObservableCollection<GrabAndGoItem>();

        public GrabAndGoMenu()
        {
            GetMealTime(App.MealTimes.Lunch);
        }


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
            }
        }

        private void AddDinnerItem(GrabAndGoItem item)
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
            }
        }

        public void GetMealTime(string mealTime)
        {
            switch (mealTime)
            {
                case App.MealTimes.Lunch:
                    {
                        LineOne = LineOneLunch;
                        LineTwo = LineTwoLunch;
                        LineThree = LineThreeLunch;
                        LineFour = LineFourLunch;
                    }
                    break;
                case App.MealTimes.Dinner:
                    {
                        LineOne = LineOneDinner;
                        LineTwo = LineTwoDinner;
                        LineThree = LineThreeDinner;
                        LineFour = LineFourDinner;
                    }
                    break;
                default:
                    Debug.WriteLine("An incorrenct meal time was passed to the FourWindsMenu Class");
                    break;
            }
        }
    }
}
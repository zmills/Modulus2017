using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Cards
{
    public class Card
    { 
        public Card(string title, int image)
        {
            Title = title;
            Image = image;
        }

        public string Title { get; set; }

        public int Image { get; set; }
    }
}
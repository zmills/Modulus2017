using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model
{
    public class Card
    {
        public string Title { get; set; }
        public int Image { get; set; }

        public Card(string title, int image)
        {
            Title = title;
            Image = image;
        }

        public Card(string title)
        {
            Title = title;
        }
    }
}

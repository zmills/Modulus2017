using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model
{
    public class Card
    {
        public int Image { get; set; }

        public Card(int image)
        {
            Image = image;
        }
    }
}

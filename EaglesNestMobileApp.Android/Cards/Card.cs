namespace EaglesNestMobileApp.Android.Cards
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
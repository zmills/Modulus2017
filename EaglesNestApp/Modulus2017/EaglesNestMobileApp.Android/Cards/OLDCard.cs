namespace EaglesNestMobileApp.Android.Cards
{
    public class OLDCard
    {
        public string Title { get; set; }
        public int Image { get; set; }

        public OLDCard(string title, int image)
        {
            Title = title;
            Image = image;
        }

        public OLDCard(string title)
        {
            Title = title;
        }
    }
}
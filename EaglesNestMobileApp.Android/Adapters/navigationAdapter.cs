using Java.Lang;
using Android.Support.V4.App;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class navigationAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] fragments;

        private readonly ICharSequence[] titles;

        public navigationAdapter(FragmentManager manager, Fragment[] fragments, ICharSequence[] titles) : base(manager)
        {
            this.fragments = fragments;
            this.titles = titles;
        }

        public override int Count
        {
            get
            {
                return fragments.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return titles[position];
        }
    }
}
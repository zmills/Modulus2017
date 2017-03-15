/*****************************************************************************/
/*                             navigationAdapter                             */
/*                                                                           */
/*****************************************************************************/
using Java.Lang;
using Android.Support.V4.App;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class navigationAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] Fragments;

        private readonly ICharSequence[] Titles;

        public navigationAdapter(FragmentManager manager, Fragment[] fragments, 
            ICharSequence[] titles) : base(manager)
        {
            Fragments = fragments;
            Titles = titles;
        }

        public override int Count => Fragments.Length;

        public override Fragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return Titles[position];
        }
    }
}
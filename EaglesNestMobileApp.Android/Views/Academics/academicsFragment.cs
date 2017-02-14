using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.App;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class academicsFragment : Fragment
    {
        TabLayout tabLayout;

        Fragment[] academicsFragments =
        {
            new gradesFragment(),
            new gradeReportFragment(),
            new examScheduleFragment()
        };

        ICharSequence[] titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Class Grades",
            "Grade Reports",
            "Exam Schedules"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View currentView = inflater.Inflate(Resource.Layout.Home, container, false);

           ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.homeViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, academicsFragments, titles);

            tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.home_tabs);

            tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}
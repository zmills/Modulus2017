/*****************************************************************************/
/*                              gradesViewHolder                             */
/*                                                                           */
/*****************************************************************************/
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesViewHolder : RecyclerView.ViewHolder
    {
        /* Public accessors                                                  */
        /* Instantiate a viewholder TextView to be set with a class name     */
        public TextView GradesClassName { get; set; }
        public LinearLayout ExpandCard { get; set; }
        public Button ShowGradesButton { get; set; }
        public Button TeacherInfoButton { get; set; }
        public ImageView ShowGradesArrow { get; set; }

        public gradesViewHolder(View view) : base(view)
        {
            /* Set the GradesClassName TextView to the GradesCardClassName   */
            /* textview in the layout                                        */
            GradesClassName = 
                view.FindViewById<TextView>(Resource.Id.GradesCardClassName);

            ShowGradesButton =
                view.FindViewById<Button>(Resource.Id.ShowGradesButton);

            ExpandCard = 
                view.FindViewById<LinearLayout>(Resource.Id.llExpandArea);

            TeacherInfoButton =
                view.FindViewById<Button>(Resource.Id.TeacherInfoButton);

            ShowGradesArrow =
                view.FindViewById<ImageView>(Resource.Id.ShowGradesArrowIcon);
        }

        /* Take in a gradesCard and assign its data to the viewholder's views */
        public void GetGradesCard(Card gradesCard)
        {
            GradesClassName.Text = gradesCard.Title;
        }
    }
}
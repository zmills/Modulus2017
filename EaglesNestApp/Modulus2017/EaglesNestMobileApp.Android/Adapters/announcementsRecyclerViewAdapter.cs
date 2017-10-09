using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using EaglesNestMobileApp.Core.Model;
using Android.Widget;
using Android.Graphics;
using EaglesNestMobileApp.Android.Helpers;
using EaglesNestMobileApp.Android.Views;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class announcementsRecyclerViewAdapter : RecyclerView.Adapter
    {
        /* List of annoucements to be displayed as cards                     */
        public mainActivity _context;
        public List<Card> Announcements { get; set; }
        public announcementViewHolder CurrentHolder { get; set; }

        /*********************************************************************/
        /* Constructor                                                       */
        /*********************************************************************/
        public announcementsRecyclerViewAdapter(mainActivity context,
            List<Card> announcements)
        {
            /* Set the context                                               */
            _context = context;

            /* Set the local announcements list to the list passed in from   */
            /* the fragment                                                  */
            Announcements = announcements;
        }

        /*********************************************************************/
        /* Return the number of cards in the list for adapter use            */
        /*********************************************************************/
        public override int ItemCount => Announcements.Count;

        /*********************************************************************/
        /* Return the current viewholder card for adapter use                */
        /*********************************************************************/
        public int ViewPosition => CurrentHolder.AdapterPosition;

        /*********************************************************************/
        /*                                                                   */
        /*********************************************************************/
        public override long GetItemId(int position)
        {
            return base.GetItemId(position);
        }

        /*********************************************************************/
        /* Create the viewholder                                             */
        /*********************************************************************/
        public override RecyclerView.ViewHolder OnCreateViewHolder(
            ViewGroup parent, int viewType)
        {
            /* Inflate the cardview                                          */
            View view = LayoutInflater.From(parent.Context).Inflate(
                Resource.Layout.AnnouncementCardLayout, parent, false);

            /* Create a viewholder to hold view references inside the        */
            /* cardview                                                      */
            RecyclerView.ViewHolder _viewHolder = new announcementViewHolder(view);

            /* Get the current ViewHolder                                    */
            #region NOTE
            // NOTE: keep this as a local variable
            #endregion
            announcementViewHolder _currentHolder =
                _viewHolder as announcementViewHolder;


            /* Expand the touchable area of all views with the specified     */
            /* tag name                                                      */
            #region NOTE
            // NOTE: Eventually ExpandTouchableByTagName() will not have to take the
            // direct parent layout as a parameter. Recursion can be used to loop
            // through the views and find them by tag name. Once this is implemented,
            // the ROOT VIEW can be used as the parameter
            // NOTE: THREADING DOES NOT WORK HERE
            #endregion
            //ExpandTouchableByTagName(_currentHolder.ParentLayout, "ExpandTouchable");
            
            return _viewHolder;
        }

        /*********************************************************************/
        /* Bind the layout views to the viewholder                           */
        /*********************************************************************/
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder,
                                                                  int position)
        {
            /* Find the current card based off of its position in the        */
            /* recyclerview and set its title and image                      */
            Card card = Announcements[position];
            CurrentHolder = holder as announcementViewHolder;
            _context.RunOnUiThread(()=>CurrentHolder.BindCard(card));
        }

        ///*********************************************************************/
        ///* Find all views with the specified tag name and expand their       */
        ///* touchable area                                                    */
        ///*********************************************************************/
        //public static void ExpandTouchableByTagName(ViewGroup parentLayout,
        //                                        string tagName)
        //{
            
        //    /* List of views                                                 */
        //    List<View> _viewArray = new List<View>();

        //    ///* The parent layout containing the views to be traversed        */
        //    //ViewGroup _parentLayout = parentLayout;

        //    ///* Get the number of child views                                 */
        //    //int _childViewCount = _parentLayout.ChildCount;

        //    ///* Loop getting each child view in the parent layout             */
        //    //for (int _childViewIndex = 0;
        //    //         _childViewIndex < _childViewCount; _childViewIndex++)
        //    //{
        //    //    /* Get the current child view                                */
        //    //    View _currentView = _parentLayout.GetChildAt(_childViewIndex);

        //    //    /* See if current view is a Button and matches the tag       */
        //    //    /* specification                                             */
        //    //    #region
        //    //    // NOTE:  AppCompatButton is used for this situation because the
        //    //    // buttons in this layout come from a V7 AppCompat CardView.
        //    //    // Other situations would use, for example, typeof(Button)
        //    //    #endregion
        //    //    if ((_currentView.GetType() == typeof(AppCompatButton)) &&
        //    //        (_currentView.Tag != null) &&
        //    //        (_currentView.Tag.ToString() == tagName))
        //    //    {
        //    //        // Cast the current view to a Button
        //    //        Button _currentButton = ((Button)_currentView);

        //    //        // Get the parent view of this Button
        //    //        _parentLayout = (ViewGroup)_currentButton.Parent;

        //    //        #region
        //    //        // NOTE:  THREADING HERE DOES NOT WORK.
        //    //        #endregion

        //    //        /* Add the current Button to the view array              */
        //    //        _viewArray.Add(_currentButton);
        //    //    }

        //    //    /* Set parent layout back to the parent that was passed in   */
        //    //    _parentLayout = parentLayout;
        //    //}

        //    ///* Run Post() on the parent to expand the Button's touchable     */
        //    ///* area after the parent lays out its children                   */
        //    //_parentLayout.Post(() => ExpandTouchable(_parentLayout, _viewArray));
        //    /*DEBUG:*/Button sharebutton;
        //    /*DEBUG:*/Button signupbutton;
        //    /*DEBUG:_viewArray.Add(sharebutton = (Button)parentLayout.FindViewById<View>(Resource.Id.ShareButton));
        //    /*DEBUG:_viewArray.Add(signupbutton = (Button)parentLayout.FindViewById<View>(Resource.Id.SignUpButton));
        //    /*DEBUG:parentLayout.Post(() => ExpandTouchable(parentLayout, _viewArray));*/
        //}

        ///*********************************************************************/
        ///* Expand the touchable area of an array of views                    */
        ///*********************************************************************/
        //public static void ExpandTouchable(View parentLayout, List<View> viewArray)
        //{
        //    /*BEGIN DEBUG*/
        //    // THE PROBLEM IS THAT SOMETIMES THE BUTTON DOES NOT GET LAID OUT
        //    // WHEN THE POST() IS CALLED. WHY? NOT SURE. BUT THIS RESULTS IN
        //    // A ZERO WIDTH AND ZERO HEIGHT. THE TEMPORARY SOLUTION FOR NOW
        //    // IS CHECKING FOR THIS AND CALLING THE EXPAND METHOD AGAIN.
        //    Button sharebutton = (Button)viewArray[0];
        //    Button signupbutton = (Button)viewArray[1];
        //    System.Diagnostics.Debug.Write("sharebuttonWidth: " + sharebutton.Width +
        //                                   "sharebuttonHeight: " + sharebutton.Height);
        //    System.Diagnostics.Debug.Write("signupbuttonWidth: " + signupbutton.Width +
        //                                   "signupbuttonHeight: " + signupbutton.Height);
        //    if (sharebutton.Width == 0)
        //    {
        //        System.Diagnostics.Debug.Write("CALL EXPAND AGAIN - BUTTON W/H ZERO :("); 
        //        parentLayout.Post(() => ExpandTouchable(parentLayout, viewArray));
        //    }
        //    /*END DEBUG*/

        //    /* A view used only for the TouchDelegateComposite constructor   */
        //    View constructorView = viewArray[0];

        //    /* A helper class that holds multiple touch delegates            */
        //    TouchDelegateComposite _touchDelegateComposite =
        //        new TouchDelegateComposite(constructorView);

        //    /* Loop getting each view to be expanded                         */
        //    foreach (View expandingView in viewArray)
        //    { 
        //        /* Create a delegate for the expanding view's touchable area */
        //        Rect delegateArea = new Rect();

        //        /* Get the touchable area of the view and set it to the      */
        //        /* delegate                                                  */
        //        expandingView.GetHitRect(delegateArea);

        //        /*DEBUG:*/System.Diagnostics.Debug.Write("BEFORE Width: " + delegateArea.Width() + "Height: " + delegateArea.Height());
        //        /* Expand the delegate                                       */
        //        delegateArea.Top = (delegateArea.Top - 50);
        //        delegateArea.Bottom = (delegateArea.Bottom + 50);
        //        delegateArea.Left = (delegateArea.Left - 50);
        //        delegateArea.Right = (delegateArea.Right + 50);
        //        /*DEBUG:*/System.Diagnostics.Debug.Write("AFTER Width: " + delegateArea.Width() + "Height: " + delegateArea.Height());

        //        /* Adapted from:                                             */
        //        /* https://gist.github.com/nikosk/3854f2effe65438cfa40       */
        //        #region
        //        // NOTE: OLD BUT USEFUL CODE
        //        //if (/*typeof(View)*/parentLayout.GetType().IsAssignableFrom(expandingView.Parent.GetType()))
        //        //{
        //        // Create a new TouchDelegate by setting the delegate's area to
        //        // the expanding view
        //        /*TouchDelegate _touchDelegate =
        //            new TouchDelegate(delegateArea, expandingView);*/

        //        //TEST CODE*****************************************
        //        /*parentLayout = (View)(expandingView.Parent);
        //        parentLayout.TouchDelegate = _touchDelegate;
        //        TouchDelegate _parentTouchDelegate = parentLayout.TouchDelegate;*/
        //        //if (_parentTouchDelegate != null)
        //        //{
        //        //    ((TouchDelegateComposite)_parentTouchDelegate).addTouchDelegate(_touchDelegate);
        //        //    _touchDelegate = _parentTouchDelegate;
        //        //    System.Diagnostics.Debug.Write("NOT NULL: " + _parentTouchDelegate.getChildCount());
        //        //}
        //        //else
        //        //{
        //        //TouchDelegateComposite _touchDelegateComposite = new TouchDelegateComposite(expandingView);
        //        //_touchDelegateComposite.addTouchDelegate(_parentTouchDelegate);
        //        //_touchDelegateComposite.addTouchDelegate(_touchDelegate);
        //        //_touchDelegate = _touchDelegateComposite;
        //        //}
        //        //TEST CODE*****************************************

        //        // Get the TouchDelegate of the parent
        //        //parentLayout = (View)(expandingView.Parent);
        //        //TouchDelegate _parentTouchDelegate = parentLayout.TouchDelegate;

        //        //// Check if the parentTouchDelegate is null
        //        //if (_parentTouchDelegate != null)
        //        //{
        //        //    //TouchDelegateComposite dummyCompo = new TouchDelegateComposite(expandingView);
        //        //    if (typeof(TouchDelegateComposite).IsAssignableFrom(_parentTouchDelegate.GetType()))
        //        //    {
        //        //        System.Diagnostics.Debug.Write("parentTouchDelegate <<IS>> INSTANCE OF TOUCHDELEGATECOMPOSITE!!!!!!!!");
        //        //        ((TouchDelegateComposite)_parentTouchDelegate).addTouchDelegate(_touchDelegate);
        //        //        _touchDelegate = _parentTouchDelegate;
        //        //    }
        //        //    else
        //        //    {
        //        //        System.Diagnostics.Debug.Write("parentTouchDelegate IS <<NOT>> AN INSTANCE OF TOUCHDELEGATECOMPOSITE!!!!!!!!");
        //        //        TouchDelegateComposite touchDelegateComposite = new TouchDelegateComposite(expandingView);
        //        //        touchDelegateComposite.addTouchDelegate(_parentTouchDelegate);
        //        //        touchDelegateComposite.addTouchDelegate(_touchDelegate);
        //        //        _touchDelegate = touchDelegateComposite;
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    System.Diagnostics.Debug.Write("parentTouchDelegate IS NULL!!!!!!!!");
        //        //}
        //        #endregion

        //        /* Create a new touch delegate using the delegate area and   */
        //        /* expanding view and add it to touch delegate composite     */
        //        _touchDelegateComposite.addTouchDelegate(
        //            new TouchDelegate(delegateArea, expandingView));

        //        /* Set the composite touch delegate to the expanding view's  */
        //        /* parent once all views in the array have been traversed so */
        //        /* that the parent can direct touch events to its children   */
        //        if (viewArray.IndexOf(expandingView) == (viewArray.Count - 1))
        //        {
        //            /*DEBUG:*/System.Diagnostics.Debug.Write("REACHED END OF ARRAY - INDEX:  "+ viewArray.IndexOf(expandingView));
        //            parentLayout = (View)(expandingView.Parent);
        //            parentLayout.TouchDelegate = _touchDelegateComposite;
        //        }
        //    }
        //}
    }
}
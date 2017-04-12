//*************************************************************************/
//*                              AndroidApp                               */
//* This static class contains a reference to MVVMLight's viewmodel       */
//* locator IoC container. Android specific services can be registered in */
//* in here (DialogService or Toast). The Locator accessor in this class  */
//* must be called as soon as the application starts up since it is in    */
//* charge of configuring the navigation between ACTIVITIES.              */
//*                                                                       */
//*************************************************************************/


namespace EaglesNestMobileApp.Android
{
    public static partial class AndroidApp
    {
        public static class FacilityCategory
        {
            public const string Academics = "Academic";
            public const string Church = "Church";
            public const string Dining = "Dining";
            public const string Dorm = "Residence Halls";
            public const string Recreation = "Recreation";
            public const string Service = "Service";
        }
    }
}
 
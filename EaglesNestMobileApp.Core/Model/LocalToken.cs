//*************************************************************************/
//*                               LocalToken                              */
//* This is the model corresponding to the local database table and is    */
//* for authentication and verification of whether a user is logged in.   */
//*                                                                       */
//*************************************************************************/

namespace EaglesNestMobileApp.Core.Model
{
    public class LocalToken
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
    }
}

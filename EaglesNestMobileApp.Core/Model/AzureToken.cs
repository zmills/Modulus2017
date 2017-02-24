//*************************************************************************/
//*                               AzureToken                              */
//* This is the model corresponding to the view in the Azure SQL database */
//* It is used for authenctication purposes.                              */
//*                                                                       */
//*************************************************************************/

using System;

namespace EaglesNestMobileApp.Core.Model
{
   public class AzureToken
   {
      public string Id { get; set; }

      public string Salt { get; set; }
      public string Passwordhash { get; set; }
      public DateTimeOffset CreatedAt { get; set; }
      public DateTimeOffset UpdatedAt { get; set; }
      public string Version { get; set; }
      public bool Deleted { get; set; }

   }
}

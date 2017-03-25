using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Helpers
{
    public class SyncHandler : IMobileServiceSyncHandler
    {
        private readonly IMobileServiceClient _client = App.Client;

        /* This holds a list of all local-only tables                         */
        private readonly HashSet<string> _excludedTables = new HashSet<string>();

        public void Exclude<T>()
        {
            _excludedTables.Add(_client.SerializerSettings.ContractResolver.ResolveTableName(typeof(T)));
        }

        public Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            return Task.FromResult(0);
        }

        public Task<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            if (_excludedTables.Contains(operation.Table.TableName))
            {
                return Task.FromResult((JObject)null);
            }
            return operation.ExecuteAsync();
        }
    }
}

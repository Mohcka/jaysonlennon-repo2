using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AptMgmtPortal.Util.Auth
{
    public class InMemoryApiStore : IGetApiKey
    {
        private ILogger<InMemoryApiStore> _logger;
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryApiStore(ILogger<InMemoryApiStore> logger)
        {
            this._logger = logger;

            _logger.LogInformation("auth thing ok");

            var existingApiKeys = new List<ApiKey>
            {
                new ApiKey(1, "tenant 1", "key1", new DateTime(2019, 01, 01),
                    new List<string>
                    {
                        Role.Tenant,
                    }),
                new ApiKey(2, "tenant 2", "key2", new DateTime(2019, 01, 01),
                    new List<string>
                    {
                        Role.Tenant,
                    }),
                new ApiKey(3, "tenant 3", "key3", new DateTime(2019, 01, 01),
                    new List<string>
                    {
                        Role.Tenant,
                    }),
                new ApiKey(4, "management 1", "key4", new DateTime(2019, 06, 01),
                    new List<string>
                    {
                        Role.Manager,
                    })
            };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> GetApiKey(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
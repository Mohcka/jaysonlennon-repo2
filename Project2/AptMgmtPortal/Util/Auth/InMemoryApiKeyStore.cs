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
                new ApiKey("tenant 1", "key1", new List<string> { Role.Tenant, }, 1),
                new ApiKey("tenant 2", "key2", new List<string> { Role.Tenant, }, 2),
                new ApiKey("tenant 3", "key3", new List<string> { Role.Tenant, }, 3),
                new ApiKey("management 1", "key4", new List<string> { Role.Manager, }, 4)
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
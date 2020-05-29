using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Util.Auth
{
    public interface IGetApiKey
    {
        Task<ApiKey> GetApiKey(string providedApiKey);
    }
}
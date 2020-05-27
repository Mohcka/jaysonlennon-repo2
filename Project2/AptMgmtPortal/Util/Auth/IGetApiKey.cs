using System.Threading.Tasks;

namespace AptMgmtPortal.Util.Auth
{
    public interface IGetApiKey
    {
        Task<ApiKey> GetApiKey(string providedApiKey);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Types
{
    // This should mirror Resource.ts in the client app.
    public enum ResourceType
    {
        Power = 0,
        Water = 1,
        Internet = 2,
        Trash = 3,
        Rent = 4,
    }
}

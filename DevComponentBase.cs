//DevComponentBase.cs
using Microsoft.AspNetCore.Components;

namespace Whozzplaying.SystemFileHelpers
{
    public class DevComponentBase : ComponentBase
    {
        protected string DevComponentName =>
#if DEBUG
            GetType().Name;
#else
            string.Empty;
#endif
    }
}

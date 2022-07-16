using System.Collections.Generic;
using System.Dynamic;

namespace Sample.Core.Framework
{
    public static partial class Helpers
    {
        public static bool DoesPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            var test = settings.GetType();
            return test.GetProperty(name) != null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimblySDK
{
    public class QueryParams : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            this.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}

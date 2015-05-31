using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneCommonLib.Armazenamento
{
    public class CacheableList<T> where T : class
    {
        public DateTime ExpirationDateTime { get; set; }

        public IList<T> ListData { get; set; }

        public bool IsExpiredData
        {
            get
            {
                return (DateTime.UtcNow > this.ExpirationDateTime);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thcp2.Common
{
    public class Pagination<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotaslRecords { get; set; }
        public int TotalPage { get; set; }
        public string Search { get; set; }
        public IEnumerable<T> Result { get; set; }
        
    }
}

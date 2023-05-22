using MS_Models.FilterModel;
using MS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Common
{
    public class Response<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public DateTime? Expiredate { get; set; }
        public T? Data { get; set; }
        public List<T>? List { get; set; }
        public int? TotalRecords { get; set; }
        public int? TotalPagesCount { get; set; }
    }
}

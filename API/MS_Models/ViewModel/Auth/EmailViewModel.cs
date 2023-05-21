using MS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel.Auth
{
    public class EmailViewModel
    {
        public string? Subject { get; set; }
        public List<string>? To { get; set; }
        public List<string>? Cc { get; set; }
        public List<string>? Bcc { get; set; }
    }


    public static class EmailExtensions
    {
        //public static List<string> ToEmailMapper(this ToEmail data)
        //{
        //    List<string> to = new List<string>();
        //    foreach (var item in data)
        //    {
        //        string res = new string();
        //        res = ;
        //        to.Add(res);
        //    }
        //    return to;
        //}

        //public static List<ToEmail> ToEmailMapper(this List<string> data)
        //{
        //    List<ToEmail> to = new List<ToEmail>();
        //    foreach (var item in data)
        //    {
        //        ToEmail res = new ToEmail();
        //        res.To = item;
        //        to.Add(res);
        //    }
        //    return to;
        //}

        //public static List<CC> CCEmailMapper(this List<TblMailModuleList> data)
        //{
        //    List<CC> cc = new List<CC>();
        //    foreach (var item in data)
        //    {
        //        CC res = new CC();
        //        res.Cc = item.Email;
        //        cc.Add(res);
        //    }
        //    return cc;
        //}

        //public static List<BCC> BCCEmailMapper(this List<TblMailModuleList> data)
        //{
        //    List<BCC> bcc = new List<BCC>();
        //    foreach (var item in data)
        //    {
        //        BCC res = new BCC();
        //        res.Bcc = item.Email;
        //        bcc.Add(res);
        //    }
        //    return bcc;
        //}
    }


}

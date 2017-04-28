using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreMate.Mvc.Model
{
    public class SyndicationItem
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public SyndicationItem(string title, string body)
        {
            this.Title = title;
            this.Body = body;
        }
    }
}

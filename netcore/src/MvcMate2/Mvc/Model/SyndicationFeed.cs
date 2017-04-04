using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMate2.Mvc.Model
{
    public class SyndicationFeed
    {
        public DateTime LastUpdatedTime { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }

        public IEnumerable<SyndicationItem> Items { get; set; }

        public SyndicationFeed(string title)
        {
            this.Title = title;
        }
    }
}

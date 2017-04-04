using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Nsk.Web.Mvc
{
    /// <summary>
    /// Defines a presentation model for web pages
    /// </summary>
    public class HtmlPageViewModel
    {
        /// <summary>
        /// Gets or sets the title of the page
        /// </summary>
        [ScaffoldColumn(false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the keyword of the page
        /// </summary>
        [ScaffoldColumn(false)]
        public string KeyWords { get; set; }

        /// <summary>
        /// Gets or sets the Description of the page
        /// </summary>
        [ScaffoldColumn(false)]
        public string Description { get; set; }
    }
}

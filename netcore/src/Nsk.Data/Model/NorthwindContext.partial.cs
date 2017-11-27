using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nsk.Data.Model
{
    public partial class NorthwindContext
    {
		public NorthwindContext()
        {

        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }
    }
}

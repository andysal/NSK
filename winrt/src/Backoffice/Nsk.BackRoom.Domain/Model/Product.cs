using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsk.BackRoom.Domain.Model
{
    public class Product : AggregateRoot
    {
        private Guid _id;

        public override Guid Id
        {
            get { return _id; }
        }
    }
}

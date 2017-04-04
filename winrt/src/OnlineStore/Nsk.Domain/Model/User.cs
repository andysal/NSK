using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsk.Domain.Model
{
    public class User : IAggregateRoot
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }

        bool IAggregateRoot.CanBeSaved
        {
            get { return true; }
        }

        bool IAggregateRoot.CanBeDeleted
        {
            get { return true; }
        }
    }
}

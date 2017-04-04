using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsk.BackRoom.Domain
{
    public interface IServiceBus : ICommandSender, IEventPublisher
    {
    }
}

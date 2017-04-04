using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Web.OnlineStore.Smartphone.Models.Home;

namespace Nsk.Web.OnlineStore.Smartphone.WorkerServices.Home
{
    public interface IHomeControllerWorkerServices
    {
        IndexViewModel GetIndexViewModel();
        bool UserNameIsAlreadyUsed(string userName);
    }
}

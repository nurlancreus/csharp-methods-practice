using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Service.Services.Interfaces
{
    public interface IGroupService : IService
    {
        public Task GetGroupTeachersAsync();
    }
}

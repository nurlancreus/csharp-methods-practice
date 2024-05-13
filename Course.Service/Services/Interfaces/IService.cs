using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.App.Services.Interfaces
{
    internal interface IService
    {
        public void Create();
        public void Update();
        public void Delete();
        public void GetById(Guid id);
        public void GetByName(string name);
    }
}

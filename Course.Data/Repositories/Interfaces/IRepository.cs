using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.App.Repositories.Interfaces
{
    internal interface IRepository
    {
        public void Create();
        public void Update();
        public void Delete();
        public void GetById(Guid id);
        public void GetAll();
    }
}

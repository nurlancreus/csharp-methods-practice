using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
   internal interface IService
    {
        public void Add();
        public void Delete();
        public void Update();
        public void GetById();
        public void GetAll();
    }
}

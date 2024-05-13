using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services.Interfaces
{
    public interface IService
    {
        public void Add();
        public void GetById();
        public void Update();
        public void GetAll();
        public void Delete();
    }
}

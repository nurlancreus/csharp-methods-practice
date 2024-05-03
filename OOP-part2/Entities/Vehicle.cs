using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{

    public enum VehicleStatus
    {
        Working,
        Damaged,
        UnderRepair
    }

    abstract internal class Vehicle
    {
        private VehicleStatus _status;

        protected Vehicle(VehicleStatus status)
        {
            SetStatus(status);
        }

        public void SetStatus(VehicleStatus status)
        {
            if (!Enum.IsDefined(typeof(VehicleStatus), status))
            {
                throw new ArgumentException("Invalid vehicle status.");
            }

            _status = status;
        }

        public VehicleStatus GetStatus() => _status;
    }
}

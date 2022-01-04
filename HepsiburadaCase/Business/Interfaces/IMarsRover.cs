using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverBusiness.Interfaces
{
    public interface IMarsRover
    {
        public bool Move();
        public void Turn(string direction);
    }
}

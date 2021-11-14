using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Dto;

namespace Map.Location.BI.Interfaces
{
    public interface IFires
    {
        Task AddFire(Fire fire);

        List<Fire> GetFires();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Base;

namespace Map.Location.BI.Interfaces
{
    public interface IGeolocation
    {
        Task<int> GetObjectsNearby(Coordinates coordinates);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Repository
{
    public interface IRollOffRepository
    {
        Task<IEnumerable<RollOffTable>> GetAllDetailsAsync();

        Task<RollOffTable> GetByGGIDAsync(double ggid);

        Task<RollOffTable> GetByEmailAsync(string email);

        Task<RollOffTable> AddEmployeeAsync(RollOffTable rollOffEmployee);

        Task<RollOffTable> DeleteEmployeeAsync(RollOffTable employee);

        Task<RollOffTable> UpdateEmployeeAsync(double ggid, RollOffTable employee);
    }
}

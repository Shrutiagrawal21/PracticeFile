using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Repository
{
    public class RollOffRepository : IRollOffRepository
    {
        private readonly RollOffProjectContext context;

        public RollOffRepository(RollOffProjectContext context)
        {
            this.context = context;
        }

        #region AddEmployeeAsync
        public async Task<RollOffTable> AddEmployeeAsync(RollOffTable rollOffEmployee)
        {
           await context.AddAsync(rollOffEmployee);
           await context.SaveChangesAsync();
            return rollOffEmployee;
        }
        #endregion

        #region DeleteEmployeeAsyn
        public async Task<RollOffTable> DeleteEmployeeAsync(RollOffTable employee)
        {
            /*var employee = await context.RollOffTables.FirstOrDefaultAsync(x=>x.GlobalGroupId==ggid);

            if (employee == null)
            {
                return null;
            }*/

            context.RollOffTables.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        #endregion

        public async Task<IEnumerable<RollOffTable>> GetAllDetailsAsync()
        {
            return await context.RollOffTables.ToListAsync();
        }

        public async Task<RollOffTable> GetByEmailAsync(string email)
        {
            return await context.RollOffTables.FirstOrDefaultAsync(x=>x.Email==email);
        }

        public async Task<RollOffTable> GetByGGIDAsync(double ggid)
        {
            return await context.RollOffTables.FirstOrDefaultAsync(x=>x.GlobalGroupId==ggid);
        }

        public async Task<RollOffTable> UpdateEmployeeAsync(double ggid, RollOffTable employee)
        {
            var existingEmployee = await context.RollOffTables.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);

            if(existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Country = employee.Country;
            existingEmployee.Email = employee.Email;
            existingEmployee.EmployeeNo = employee.EmployeeNo;
            existingEmployee.JoiningDate = employee.JoiningDate;
            existingEmployee.Name = employee.Name;
            existingEmployee.LocalGrade = employee.LocalGrade;
            existingEmployee.MainClient = employee.MainClient;
            existingEmployee.ProjectCode = employee.ProjectCode;
            existingEmployee.ProjectName = employee.ProjectName;
            existingEmployee.ProjectStartDate = employee.ProjectStartDate;
            existingEmployee.ProjectEndDate = employee.ProjectEndDate;
            existingEmployee.PeopleManagerPerformanceReviewer = employee.PeopleManagerPerformanceReviewer;
            existingEmployee.Practice = employee.Practice;
            existingEmployee.PspName = employee.PspName;
            existingEmployee.NewGlobalPractice = employee.NewGlobalPractice;
            existingEmployee.OfficeCity = employee.OfficeCity;

            await context.SaveChangesAsync();
            return existingEmployee;

        }
    }
}

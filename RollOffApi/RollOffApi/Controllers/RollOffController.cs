using Microsoft.AspNetCore.Mvc;
using RollOffApi.DTO;

using RollOffApi.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using AutoMapper;
using System;

namespace RollOffApi.Controllers
{
    [ApiController]
    [Route("RollOff")]
    public class RollOffController : ControllerBase
    {
        private readonly IRollOffRepository rollOffRepository;
        private readonly IMapper mapper;

        public RollOffController(IRollOffRepository rollOffRepository, IMapper mapper)
        {
            this.rollOffRepository = rollOffRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRollOffEmployees()
        {
            var rollOffDetails = await rollOffRepository.GetAllDetailsAsync();

            //return DTO
            /* var rollOffDetailsDTO = new List<RollOffTable>();
             rollOffDetails.ToList().ForEach(rollOff =>
             {
                 var rollOffDetailDTO = new RollOffTable()
                 {
                     Country=rollOff.Country,
                     GlobalGroupId=rollOff.GlobalGroupId,
                     EmployeeNo=rollOff.EmployeeNo,
                     Email=rollOff.Email
                     *//*.
                       .
                       .  *//*
                 };
                 rollOffDetailsDTO.Add(rollOffDetailDTO);
             });*/
            var rollOffDetailsDTO = mapper.Map<List<RollOffTableDTO>>(rollOffDetails);

            return Ok(rollOffDetailsDTO);
        }

        [HttpGet]
        [Route("{ggid:double}")]
        public async Task<IActionResult> GetDetailByGGID(double ggid)
        {
            try {
                var rollOffEmployee = await rollOffRepository.GetByGGIDAsync(ggid);

                if (rollOffEmployee == null)
                {
                    return NotFound();
                }

                var rollOffEmployeeDTO = mapper.Map<RollOffTableDTO>(rollOffEmployee);

                return Ok(rollOffEmployeeDTO);
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong" + e);
            }
          }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetDetailByEmail(string email)
        {
            try {
                var rollOffEmployee = await rollOffRepository.GetByEmailAsync(email);

                if (rollOffEmployee == null)
                {
                    return NotFound();
                }

                var rollOffEmployeeDTO = mapper.Map<RollOffTableDTO>(rollOffEmployee);

                return Ok(rollOffEmployeeDTO);
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong" + e);
            }
}
        [HttpPost]
        public async Task<IActionResult> AddRollOffEmployee(RollOffTableDTO rollOffTableDTO)
        {
            try {
                //DTO to Model
                var rollOffEmployee = mapper.Map<RollOffTable>(rollOffTableDTO);

                //Pass Detail to Repository
                var response = await rollOffRepository.AddEmployeeAsync(rollOffEmployee);

                //Convert back to DTO
                var rollOffTableDTO2 = mapper.Map<RollOffTableDTO>(response);

                return Ok(rollOffTableDTO2);
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong" + e);
            }
}
        [HttpDelete]
        [Route("{ggid}")]
        public async Task<IActionResult> DeleteEmployeeByGGID(double ggid)
        {
            //Get Employee from Database
            var rollOffEmployee = await rollOffRepository.GetByGGIDAsync(ggid);

            //If null return not found
            if (rollOffEmployee == null)
            {
                return NotFound();
            }

            //Delete the employee
            var rollOffEmployee1 = await rollOffRepository.DeleteEmployeeAsync(rollOffEmployee);

            //Convert response back to DTO
            var rollOffTableDTO = mapper.Map<RollOffTableDTO>(rollOffEmployee1);

            //return Ok response
            return Ok(rollOffTableDTO);
        }

        [HttpPut]
        [Route("{ggid}")]
        public async Task<IActionResult> UpdateEmployeeByGGID(double ggid, UpdateEmployeeDTO updateEmployeeDTO)
        {
            //Convert DTO to model
            var emp = mapper.Map<RollOffTable>(updateEmployeeDTO);

            /*var emp = new RollOffTable()
            {
                Country = updateEmployeeDTO.Country,
                Email = updateEmployeeDTO.Email,
                EmployeeNo = updateEmployeeDTO.EmployeeNo,
                JoiningDate = updateEmployeeDTO.JoiningDate,
                Name = updateEmployeeDTO.Name,
                LocalGrade = updateEmployeeDTO.LocalGrade,
                MainClient = updateEmployeeDTO.MainClient,
                ProjectCode = updateEmployeeDTO.ProjectCode,
                ProjectName = updateEmployeeDTO.ProjectName,
                ProjectStartDate = updateEmployeeDTO.ProjectStartDate,
                ProjectEndDate = updateEmployeeDTO.ProjectEndDate,
                PeopleManagerPerformanceReviewer = updateEmployeeDTO.PeopleManagerPerformanceReviewer,
                Practice = updateEmployeeDTO.Practice,
                PspName = updateEmployeeDTO.PspName,
                NewGlobalPractice = updateEmployeeDTO.NewGlobalPractice,
                OfficeCity = updateEmployeeDTO.OfficeCity
             };*/

            //Update Employee using Repository
            var employee = await rollOffRepository.UpdateEmployeeAsync(ggid,emp);

            //If null return Not Found
            if(employee == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var employeeDTO = mapper.Map<RollOffTableDTO>(employee);

            //return Ok response
            return Ok(employeeDTO);
        }
    }
}

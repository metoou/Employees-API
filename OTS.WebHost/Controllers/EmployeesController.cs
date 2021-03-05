using Microsoft.AspNetCore.Mvc;
using OTS.Core.Abstractions.Repositories;
using OTS.Core.Domain.Entities;
using OTS.WebHost.Mappers;
using OTS.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController 
        : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        public EmployeesController(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x =>
                new EmployeeResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary,
                    DepartmentId = x.DepartmentId
                    
                }).ToList();

            return employeesModelList;
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Name = employee.Name,
                DepartmentId = employee.DepartmentId,
                Salary = employee.Salary
            };

            return employeeModel;
        }

        /// <summary>
        /// Получить данные сотрудников по Id отдела
        /// </summary>
        /// <returns></returns>
        [HttpGet("department/{id:guid}")]
        public async Task<List<EmployeeResponse>> GetEmployeesByDepartmentIdAsync(Guid id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            var employees = await GetEmployeesAsync();

            // var employee = await _employeeRepository.GetByIdAsync(employees.SingleOrDefault(x => x.DepartmentId == id).Id);
            var employeesModelList = employees.Where(o => o.DepartmentId == id)
                .Select(x =>
                new EmployeeResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary,
                    DepartmentId = x.DepartmentId
                })
                .ToList();


            return employeesModelList;
        }

        /// <summary>
        /// Создать сотрудника
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateOrEditEmployeeRequest model)
        {

            var employee = EmployeeStaticMapper.MapFromModel(model);

            try
            {
                await _employeeRepository.CreateAsync(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = employee.Id }, null);
        }

        /// <summary>
        /// Изменить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateEmployeeAsync(Guid id, CreateOrEditEmployeeRequest model)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return BadRequest();
            }

            employee = EmployeeStaticMapper.MapFromModel(model, employee);

            try
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Employee toDelete = await _employeeRepository.GetByIdAsync(id);

            if (toDelete == null)
            {
                return NotFound();
            }
            try
            {
                await _employeeRepository.DeleteAsync(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}

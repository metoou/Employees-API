using Microsoft.AspNetCore.Mvc;
using OTS.Core.Abstractions.Repositories;
using OTS.Core.Domain.Entities;
using OTS.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.WebHost.Controllers
{
    /// <summary>
    /// Отделы
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentsController 
        : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentsController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Получить данные всех отделов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<DepartmentItemResponse>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var departmentsModelList = departments.Select(x =>
                new DepartmentItemResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary
                }).ToList();

            return departmentsModelList;
        }

        /// <summary>
        /// Получить данные отдела по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DepartmentItemResponse>> GetDepartmentsByIdAsync(Guid id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            var departmentModel = new DepartmentItemResponse()
            {
                Id = department.Id,
                Name = department.Name,
                Salary = department.Salary
            };

            return departmentModel;
        }
    }
}

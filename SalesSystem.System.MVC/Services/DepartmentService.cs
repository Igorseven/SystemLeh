//using Microsoft.EntityFrameworkCore;
//using SalesSystem.System.MVC.Data.ORM;
//using SalesSystem.System.MVC.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SalesSystem.System.MVC.Services
//{
//    public class DepartmentService
//    {
//        private readonly SystemContext _systemContext;
//        public DepartmentService(SystemContext systemContext)
//        {
//            _systemContext = systemContext;
//        }

//        public async Task<List<Department>> FindAllDepAsync()
//        {
//            return await _systemContext.Departments.OrderBy(dep => dep.DepartmentName).ToListAsync();
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFCodeFirstApproach.Models;

namespace EFCodeFirstApproach.ViewModels
{
    public class NewEmpViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Manager> Managers { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Manager Manager { get; set; }

    }
}
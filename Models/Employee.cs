using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstApproach.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Emp Name is Mandatory")]
        [StringLength(30,ErrorMessage ="Name cannot be greater than 30 chars")]
        [MinLength(3,ErrorMessage="Name should contain at least 3 chars")]

        public string EmpName { get; set; }
        [Required]
        [Display(Name="Emp-Sal")]
        public double Salary { get; set; }
       public int DeptId { get; set; }
        public int ManagerId { get; set; }
        public  Department Department { get; set; }
        public  Manager Manager { get; set; }
    }
}
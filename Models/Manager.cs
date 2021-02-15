using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EFCodeFirstApproach.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        public string ManagerName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<ViewModels.EmployeeViewModel> Employees { get; set; }
        //public string userName { get; set; }

        public FooterViewModel FooterData { get; set; }

    }
}
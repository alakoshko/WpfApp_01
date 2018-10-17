using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;
using System.Data.SqlClient;

namespace WebApiServer.Controllers
{
    public class EmployesController : ApiController
    {
        public SQLProcessing sqlProcessing;

        private static ObservableCollection<Employee> _Employes = new ObservableCollection<Employee>();

        private EmployesController()
        {
            sqlProcessing = new SQLProcessing();
            ////Company
            //sqlProcessing.GetCompanies(Companies);

            ////Departaments
            //sqlProcessing.GetDepartments(Depts);
            //foreach (var v in Depts)
            //{
            //    if (v.CompanyID != null)
            //        v.Company = Companies.FirstOrDefault(p => p.ID == v.CompanyID);
            //}


            //Employes
            sqlProcessing.GetEmployees(_Employes);
            //foreach (var v in _Employes)
            //{
            //    if (v.DeptID != null)
            //        v.Dept = Depts.FirstOrDefault(p => p.ID == v.DeptID);
            //}
            //SelectedEmployer = null;
        }

        public IEnumerable<Employee> GetAllEmployes() => _Employes;

        public IHttpActionResult GetEmployer(Guid guid)
        {
            var employe = _Employes.First(p => p.ID == guid);
            if (employe is null) return NotFound();
            return Ok(employe);
        }
    }
}

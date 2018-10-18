using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;
using System.Collections.ObjectModel;
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

            //Employes
            _Employes = null;
            sqlProcessing.GetEmployees(_Employes);
            
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

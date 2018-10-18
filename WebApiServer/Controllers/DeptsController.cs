using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;
using System.Collections.ObjectModel;

namespace WebApiServer.Controllers
{
    public class DeptsController : ApiController
    {
        public SQLProcessing sqlProcessing;

        private static ObservableCollection<Department> _Depts = new ObservableCollection<Department>();

        private DeptsController()
        {
            sqlProcessing = new SQLProcessing();

            ////Departaments
            sqlProcessing.GetDepartments(_Depts);
        }

        public IEnumerable<Department> GetAllDepartaments() => _Depts;

        public IHttpActionResult GetEmployer(Guid guid)
        {
            var employe = _Depts.First(p => p.ID == guid);
            if (employe is null) return NotFound();
            return Ok(employe);
        }
    }
}

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
    public class CompaniesController : ApiController
    {
        public SQLProcessing sqlProcessing;

        private static ObservableCollection<Company> _Companies = new ObservableCollection<Company>();

        private CompaniesController()
        {
            sqlProcessing = new SQLProcessing();
            ////Company
            sqlProcessing.GetCompanies(_Companies);
        }

        public IEnumerable<Company> GetAllDepartaments() => _Companies;

        public IHttpActionResult GetEmployer(Guid guid)
        {
            var employe = _Companies.First(p => p.ID == guid);
            if (employe is null) return NotFound();
            return Ok(employe);
        }
    }
}


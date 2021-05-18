using Microsoft.AspNetCore.Mvc;
using Wetware.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DataTable(DataTablesParameters parameters)
        {
            var searchValue = parameters.Search?.Value;
            var people = GetFakePeople().AsEnumerable();

            var recordsTotal = people.Count();

            people = people.Where(u => searchValue is null ||
                                       u.FirstName == searchValue || 
                                       u.LastName == searchValue )
                           .Skip(parameters.Start)
                           .Take(parameters.Length);

            return Json(new DataTablesReturn<PersonDto>{
                Draw = parameters.Draw,
                Data = people,
                RecordsTotal = recordsTotal,
                RecordsFiltered = searchValue is not null ? people.Count() : recordsTotal
            });
        }

        private static List<PersonDto> _fakePeople;
        private static List<PersonDto> GetFakePeople()
        {
            if(_fakePeople is not null) return _fakePeople;

             var userFaker = new Faker<PersonDto>();
             userFaker.RuleFor(u => u.FirstName, m => m.Person.FirstName)
                      .RuleFor(u => u.LastName, f => f.Person.LastName)
                      .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth);

            return _fakePeople = userFaker.Generate(100);
        }

        private record PersonDto()
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public DateTime DateOfBirth { get; init; }
        }
    }
}

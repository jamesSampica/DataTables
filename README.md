# DataTables
.NET package for binding the JQuery Datatables library with an ASP.NET back-end.

# Usage

Simply use `DataTablesParameters` as a parameter in a controller action. ASP.NET will automatically bind what DataTables sends to server.

    [HttpPost]
    public IActionResult DataTable(DataTablesParameters parameters)
    {
        //Get some stuff from somewhere 

        return Json(new DataTablesReturn<PersonDto>{
            Draw = parameters.Draw,
            Data = new List<object>(), // The data to return goes here
            RecordsTotal = 0, // Fill this out
            RecordsFiltered = 0 //Fill this out
        });
    }

# Reference
For a complete reference on the JQuery Datatables API please use https://datatables.net/reference/api/
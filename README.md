# DataTables
.NET package for binding the jQuery Datatables library with an ASP.NET back-end.

This package contains nothing but the appropriate binding models, making it incredibly lean and efficient.

Package: https://www.nuget.org/packages/Wetware.DataTables

# Usage

Simply use `DataTablesParameters` as a parameter in a controller action. ASP.NET will automatically bind what DataTables sends to server.

    [HttpPost]
    public IActionResult DataTable(DataTablesParameters parameters)
    {
        //Get some stuff from somewhere 

        return Json(new DataTablesReturn<object>{
            Draw = parameters.Draw,
            Data = new List<object>(), // The data to return goes here
            RecordsTotal = 0, // Fill this out
            RecordsFiltered = 0 //Fill this out
        });
    }

I recommend using `[HttpPost]` instead of `[HttpGet]` since DataTables has a lot of options and depending on your table configuration can overflow the browsers max length for a url.

For a sample see the src/Samples/MvcSample project.

# Reference
For a complete reference on the jQuery Datatables API please use https://datatables.net/reference/api/

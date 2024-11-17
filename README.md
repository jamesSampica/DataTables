# DataTables
Dotnet package for binding [jQuery Datatables](https://datatables.net) with an ASP.NET back-end.

If you'd like to internalize this library into your project feel free to copy the csharp classes in [/src/Datatables](https://github.com/jamesSampica/DataTables/tree/main/src/DataTables) to your own projects.

Package: https://www.nuget.org/packages/Wetware.DataTables

# Usage

Simply use `DataTablesParameters` as a parameter in a controller action or page model. ASP.NET will automatically bind what DataTables sends to server.

Controller.cs

    [HttpPost]
    public IActionResult DataTable(DataTablesParameters parameters)
    {
        // Get some stuff from somewhere 

        return Json(new DataTablesReturn<object>{
            Draw = parameters.Draw,
            Data = new List<object>(), // The data to return goes here
            RecordsTotal = 0, // Fill this out
            RecordsFiltered = 0 // Fill this out
        });
    }

PageModel.cs

    public IActionResult OnPost(DataTablesParameters @params)
    {
        var hasSearch = !string.IsNullOrWhiteSpace(@params.Search.Value);

        var people = People
                        .Where(p => !hasSearch || p.Name.Contains(@params.Search.Value))
                        .Skip(@params.Start).Take(@params.Length).ToList();

        return new JsonResult(new DataTablesReturn()
        {
            Draw = @params.Draw,
            Data = people,
            RecordsTotal = People.Count,
            RecordsFiltered = hasSearch ? people.Count : People.Count
        });
    }

I recommend using `[HttpPost]` instead of `[HttpGet]` since DataTables has a lot of options and depending on your table configuration can overflow the max length for a url.

To see how to wire it up and see it in action see the `RazorPagesSample` project in the `Samples` folder.

# Reference
For a complete reference on the jQuery Datatables API please use https://datatables.net/reference/api/

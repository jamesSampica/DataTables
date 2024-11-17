using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wetware.DataTables;

namespace RazorPagesSample.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

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

    readonly static List<Person> People = [new("John", 42),
                                           new("Sarah", 36),
                                           new("Jim", 25),
                                           new("Ken", 28),
                                           new("Ben", 30),
                                           new("Kim", 46),
                                           new("Jen", 22),
                                           new("Jeff", 29),
                                           new("Jake", 55),
                                           new("Gale", 57),
                                           new("Mike", 31),
                                           new("Gus", 47)];

    sealed record Person(string Name, int Age);
}

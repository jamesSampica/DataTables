namespace Wetware.DataTables;

/// <summary>
/// Represents a column and it's order direction
/// </summary>
public sealed record DataTablesOrder
{
    /// <summary>
    /// Column to which ordering should be applied. This is an index reference to the 
    /// columns array of information that is also submitted to the server
    /// </summary>
    public int Column { get; init; }

    /// <summary>
    /// Ordering direction for this column. Values are either "asc" or "desc".
    /// </summary>
    public string Dir { get; init; }
}

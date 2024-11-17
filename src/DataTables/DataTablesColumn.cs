namespace Wetware.DataTables;

/// <summary>
/// Represents an individual column in the table
/// </summary>
public sealed record DataTablesColumn
{
    /// <summary>
    /// Column's data source
    /// </summary>
    public string Data { get; init; }

    /// <summary>
    /// Column's name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Indicates whether this column is orderable
    /// </summary>
    public bool Orderable { get; init; }

    /// <summary>
    /// Indicates whether this column is searchable
    /// </summary>
    public bool Searchable { get; init; }

    /// <summary>
    /// Search to apply to this specific column.
    /// </summary>
    public DataTablesSearch Search { get; init; }
}

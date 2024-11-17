using System.Collections.Generic;

namespace Wetware.DataTables;

/// <summary>
/// A serialization model containing the required fields DataTables needs a server side action to return. This model is optional
/// </summary>
public record DataTablesReturn
{
    /// <summary>
    /// Draw counter. This is used by DataTables to ensure that the Ajax returns from 
    /// server-side processing requests are drawn in sequence by DataTables .
    /// </summary>
    public int Draw { get; init; }

    /// <summary>
    /// The total amount of records in the dataset.
    /// </summary>
    public int RecordsTotal { get; init; }

    /// <summary>
    /// The total amount of records in the result set after filtering. 
    /// This should be set to less than or equal to <see cref="RecordsTotal"/>
    /// </summary>
    public int RecordsFiltered { get; init; }

    /// <summary>
    /// The row data that populates and displays in the table.
    /// </summary>
    public object Data { get; init; }
}

/// <inheritdoc cref="DataTablesReturn"/>
public record DataTablesReturn<TModel> : DataTablesReturn where TModel : class
{
    /// <inheritdoc cref="DataTablesReturn"/>
    public DataTablesReturn() { }

    /// <inheritdoc cref="DataTablesReturn"/>
    public DataTablesReturn(int draw, int recordsTotal, int recordsFiltered, IEnumerable<TModel> data) =>
        (Draw, RecordsTotal, RecordsFiltered, Data) = (draw, recordsTotal, recordsFiltered, data);

    /// <inheritdoc cref="DataTablesReturn.Data"/>
    public new IEnumerable<TModel> Data { get; init; }
}

using System.Collections.Generic;

namespace Wetware.DataTables
{
    /// <summary>
    /// Root model containing parameters sent by DataTables to an MVC Controller
    /// </summary>
    public sealed record DataTablesParameters
    {
        /// <summary>
        /// Draw counter. This is used by DataTables to ensure that the Ajax returns from 
        /// server-side processing requests are drawn in sequence by DataTables 
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// Paging first record indicator. This is the zero based index for the
        /// start point in the current data set
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw. It is expected
        /// that the number of records returned will be equal to this number, unless the 
        /// server has fewer records to return. Note that this can be -1 to indicate that 
        /// all records should be returned (although that negates any benefits of 
        /// server-side processing!)
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Global Search for the table
        /// </summary>
        public DataTablesSearch Search { get; set; }

        /// <summary>
        /// Collection of all column indexes and their sort directions
        /// </summary>
        public IEnumerable<DataTablesOrder> Order { get; set; }

        /// <summary>
        /// Collection of all columns in the table
        /// </summary>
        public IEnumerable<DataTablesColumn> Columns { get; set; }
    }
}

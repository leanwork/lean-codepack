using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leanwork.CodePack.DataTables
{
    public class jQueryDataTableResponseModel
    {
        /// <summary>
        /// Sets an unaltered copy of sEcho sent from the client side. This parameter will change with each 
        /// draw (it is basically a draw count) - so it is important that this is implemented. 
        /// Note that it strongly recommended for security reasons that you 'cast' this parameter to an 
        /// integer in order to prevent Cross Site Scripting (XSS) attacks.
        /// </summary>
        public int sEcho { get; set; }

        /// <summary>
        /// Sets the Total records, before filtering (i.e. the total number of records in the database)
        /// </summary>
        public int iTotalRecords { get; set; }

        /// <summary>
        /// Sets the Total records, after filtering 
        /// (i.e. the total number of records after filtering has been applied - 
        /// not just the number of records being returned in this result set)
        /// </summary>
        public int iTotalDisplayRecords { get; set; }

        /// <summary>
        /// Sets the data in a 2D array (Array of JSON objects). Note that you can change the name of this 
        /// parameter with sAjaxDataProp.
        /// </summary>
        public object aaData { get; set; }
    }
}
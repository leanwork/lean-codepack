using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack.DataTables
{
    public static class CollectionHelper
    {
        public static jQueryDataTableResponseModel DataTableResponse<TSource>(this IQueryable<TSource> source, jQueryDataTableRequestModel request)
        {
            int total = source.Count();
            source = source.Skip(request.iDisplayStart).Take(request.iDisplayLength);

            jQueryDataTableResponseModel response = new jQueryDataTableResponseModel();
            response.sEcho = request.sEcho;
            response.iTotalRecords = total;
            response.iTotalDisplayRecords = total;
            response.aaData = source.ToList();

            return response;
        }

        public static jQueryDataTableSorting<TSource> DataTableSorting<TSource>(this IQueryable<TSource> source, jQueryDataTableRequestModel request)
        {
            return new jQueryDataTableSorting<TSource>(source, request);
        }
    }
}

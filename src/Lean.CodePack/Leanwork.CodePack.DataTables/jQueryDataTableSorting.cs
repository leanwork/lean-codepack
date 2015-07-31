using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack.DataTables
{
    public class jQueryDataTableSorting<TSource>
    {
        private IQueryable<TSource> _source;
        private jQueryDataTableRequestModel _request;
        private Dictionary<string, Expression<Func<TSource, dynamic>>> _sortColumns;

        public jQueryDataTableSorting(IQueryable<TSource> source, jQueryDataTableRequestModel request)
        {
            this._source = source;
            this._request = request;
            _sortColumns = new Dictionary<string, Expression<Func<TSource, dynamic>>>();
        }

        public jQueryDataTableSorting<TSource> AddColumn(string columnName, Expression<Func<TSource, dynamic>> expression)
        {
            _sortColumns.Add(columnName, expression);
            return this;
        }

        public IQueryable<TSource> Execute()
        {
            foreach (var sort in _request.GetSortedColumns())
            {
                _source = SortColumn(_source, sort.Direction, _sortColumns[sort.PropertyName]);
            }
            return _source;
        }

        private IOrderedQueryable<TSource> SortColumn<TSource, TKey>(IQueryable<TSource> items, SortingDirection direction, Expression<Func<TSource, TKey>> keySelector)
        {
            if (direction == SortingDirection.Ascending)
            {
                return items.OrderBy(keySelector);
            }
            return items.OrderByDescending(keySelector);
        }

        private IOrderedQueryable<TSource> SortColumn<TSource, TKey>(IOrderedQueryable<TSource> items, SortingDirection direction, Expression<Func<TSource, TKey>> keySelector)
        {
            if (direction == SortingDirection.Ascending)
            {
                return items.ThenBy(keySelector);
            }
            return items.ThenByDescending(keySelector);
        }
    }
}

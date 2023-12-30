using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Extensions
{
    public static class DataManipulationExtensions
    {
        public static List<DataRow>? GetDistinctValues(this DataRow[] data, string idColumn)
        {
            var filteredData = data.GroupBy(item => item[idColumn])
               .Select(group => group.First())
               .ToList();

            return filteredData;
        }
    }
}

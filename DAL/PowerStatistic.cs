using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PowerStatistic
    {
        private static readonly CimArkDevEntities Ctx = new CimArkDevEntities();


        public static List<Powerplant> GetAllPowerProductionByYear(int beginYear, int endYear)
        {
            return GetPowerProductionByYear(beginYear, endYear, Ctx.PowerTypes);
        }

        private static List<Powerplant> GetPowerProductionByYear(int beginYear, int endYear,
            IQueryable<PowerType> requestedTypes)
        {
            if (beginYear > endYear)
            {
                throw new ArgumentException("beginYear must be smaller or equal to endYear");
            }

            var powerTypes = Ctx.PowerTypes.Any(type => requestedTypes.Any(powerType => powerType.Name.Equals(type.Name)));

            var result = new List<Powerplant>();

            for (int i = 0; i <= endYear - beginYear; i++)
            {

                var annualProduction = (from plant in Ctx.Powerplants
                                        join powerType in requestedTypes on plant.PowerTypeId equals powerType.Id
                                            into annualPowerSources
                                        from annualPowerSource in annualPowerSources.DefaultIfEmpty()
              
                                        select new
                                        {
                                            id = annualPowerSource.Id,
                                            PowerAvgYear = (annualPowerSource.Powerplants
                                                .Where(single => single.Launch.Year <= beginYear + i)
                                                .Sum(single => single.PowerAvgYear)) ,
                                            Year = beginYear + i
                                        }).ToList()
                    .Distinct()
                    .Select(val => new Powerplant
                    {
                        PowerTypeId = val.id,
                        PowerAvgYear = val.PowerAvgYear ?? 0,
                        Launch = new DateTime(val.Year, 1, 1)

                    });

                result.AddRange(annualProduction);
            }

            return result;
        }
    }
}

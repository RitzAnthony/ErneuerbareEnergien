using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataInitializer
    {

        public static void AddDefaultData()
        {
            AddPowerTypes();
            AddPowerPlants();
        }

        private static void AddPowerPlants()
        {
            var ctx = new CimArkDevEntities();

            var defaultPlants = new List<Powerplant>
            {
                new Powerplant()
                {
                    No_RPC = 3000,
                    PowerType = ctx.PowerTypes.First(type => type.Name == "Wasserkraft"),
                    Power = 30,
                    PowerAvgYear = 150000,
                    Launch = new DateTime(2010, 3, 12),
                    PostalCode = 3960,
                    City = "Sierre",
                    GPS_X = 120999,
                    GPS_Y = 630000
                },

                new Powerplant()
                {
                    No_RPC = 1000,
                    PowerType = ctx.PowerTypes.First(type => type.Name == "Photovoltaik"),
                    Power = (decimal?)31.5,
                    PowerAvgYear = 29000,
                    Launch = new DateTime(2012, 5, 22),
                    PostalCode = 3960,
                    City = "Sierre",
                    GPS_X = 100999,
                    GPS_Y = 600000
                },

                new Powerplant()
                {
                    No_RPC = 2000,
                    PowerType = ctx.PowerTypes.First(type => type.Name == "Biomasse"),
                    Power = 90,
                    PowerAvgYear = 290000,
                    Launch = new DateTime(2006, 1, 9),
                    PostalCode = 3960,
                    City = "Sierre",
                    GPS_X = 110999,
                    GPS_Y = 590000
                },

                new Powerplant()
                {
                    No_RPC = 5000,
                    PowerType = ctx.PowerTypes.First(type => type.Name == "Wind"),
                    Power = 3000,
                    PowerAvgYear = 6500000,
                    Launch = new DateTime(2012, 8, 13),
                    PostalCode = 1906,
                    City = "Charrat",
                    GPS_X = 108892,
                    GPS_Y = 577338
                },

                new Powerplant()
                {
                    No_RPC = 4000,
                    PowerType = ctx.PowerTypes.First(type => type.Name == "Wind"),
                    Power = 2000,
                    PowerAvgYear = 4300000,
                    Launch = new DateTime(2008, 5, 1),
                    PostalCode = 1920,
                    City = "Martigny",
                    GPS_X = 108581,
                    GPS_Y = 570085
                }
            };

            foreach (var defaultPlant in defaultPlants)
            {
                if (!ctx.Powerplants.ToList().Exists(plant => plant.No_RPC == defaultPlant.No_RPC))
                {
                    ctx.Powerplants.Add(defaultPlant);
                }
            }

            ctx.SaveChanges();
        }


        private static void AddPowerTypes()
        {
            var ctx = new CimArkDevEntities();

            var defaultTypes = new List<PowerType>
            {
                new PowerType()
                {
                    Name = "Wasserkraft"
                },

                new PowerType()
                {
                    Name = "Photovoltaik"
                },

                new PowerType()
                {
                    Name = "Biomasse"
                },

                new PowerType()
                {
                    Name = "Wind"
                }
            };

            foreach (var defaultType in defaultTypes)
            {
                if (!ctx.PowerTypes.ToList().Exists(type => type.Name == defaultType.Name))
                {
                    ctx.PowerTypes.Add(defaultType);
                }
            }

            ctx.SaveChanges();
        }
    }
}

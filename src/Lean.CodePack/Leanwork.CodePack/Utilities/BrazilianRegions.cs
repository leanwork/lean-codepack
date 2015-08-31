using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack.Utilities
{
    public static class BrazilianRegions
    {
        public struct Region
        {
            public string Name { get; set; }
        }

        static IList<Region> Regions
        {
            get
            {
                if (_regions == null)
                    Init();
                return _regions;
            }
            set { _regions = value; }
        }
        static IList<Region> _regions;

        private static IList<Region> Init()
        {
            _regions = new List<Region>
            {
                new Region { Name = "Norte" },
                new Region { Name = "Nordeste" },
                new Region { Name = "Centro-Oeste" },
                new Region { Name = "Sudeste"},
                new Region { Name = "Sul" }
            };

            return _regions;
        }

        public static IEnumerable<Region> Get()
        {
            return Regions;
        }
    }
}

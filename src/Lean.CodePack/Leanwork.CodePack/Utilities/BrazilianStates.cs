using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack
{
    public static class BrazilianStates
    {
        public struct State
        {
            public string UF { get; set; }
            public string Name { get; set; }
        }

        static IList<State> States
        {
            get
            {
                if (_states == null)
                    Init();
                return _states;
            }
            set { _states = value; }
        }
        static IList<State> _states;

        private static IList<State> Init()
        {
            _states = new List<State>
            {
                new State { UF = "AC", Name = "Acre" },
                new State { UF = "AL", Name = "Alagoas" },
                new State { UF = "AM", Name = "Amazonas" },
                new State { UF = "AP", Name = "Amapá"},
                new State { UF = "BA", Name = "Bahia" },
                new State { UF = "CE", Name = "Ceará" },
                new State { UF = "DF", Name = "Distrito Federal" },
                new State { UF = "ES", Name = "Espiríto Santo" },
                new State { UF = "GO", Name = "Goías" },
                new State { UF = "MA", Name = "Manaus" },
                new State { UF = "MG", Name = "Minas Gerais" },
                new State { UF = "MS", Name = "Mato Grosso do Sul" },
                new State { UF = "MT", Name = "Mato Grosso" },
                new State { UF = "PA", Name = "Pará" },
                new State { UF = "PB", Name = "Paraíba" },
                new State { UF = "PE", Name = "Pernambuco" },
                new State { UF = "PI", Name = "Piauí" },
                new State { UF = "PR", Name = "Paraná" },
                new State { UF = "RJ", Name = "Rio de Janeiro" },
                new State { UF = "RN", Name = "Rio Grande do Norte" },
                new State { UF = "RR", Name = "Roraíma" },
                new State { UF = "RO", Name = "Rondônia" },
                new State { UF = "RS", Name = "Rio Grande do Sul" },
                new State { UF = "SC", Name = "Santa Catarina" },
                new State { UF = "SE", Name = "Sergipe" },
                new State { UF = "SP", Name = "São Paulo" },
                new State { UF = "TO", Name = "Tocantins" }
            };

            return _states;
        }

        public static IEnumerable<State> Get()
        {
            return States.OrderBy(x => x.Name);
        }
    }
}

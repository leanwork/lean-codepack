using System;
using System.Collections.Generic;
using System.Linq;

namespace Leanwork.CodePack.Utilities
{
    public static class BrazilianTrackPostalCode
    {
        public class Track
        {
            public string UF { get; set; }

            public string State { get; set; }

            public int Initial { get; set; }

            public int Final { get; set; }

            public string Region { get; set; }

            public string Capital { get; set; }

            public string Country { get; set; }

            public Track()
            {
                State = String.Empty;
                UF = String.Empty;
            }
        }

        private static IEnumerable<Track> _tracks;
        private static IEnumerable<Track> Tracks
        {
            get
            {
                if (_tracks == null)
                    Initialize();
                return _tracks;
            }
            set { _tracks = value; }
        }

        private static IEnumerable<Track> Initialize()
        {
            _tracks = new HashSet<Track>
            {
                new Track { 
                    UF = "AC", State = "Acre", 
                    Initial = 69900000, Final = 69999999, 
                    Region = "Norte", Capital = "Rio Branco", 
                    Country = "BR" },

                new Track { 
                    UF = "AL", State = "Alagoas", 
                    Initial = 57000000, Final = 57999999, 
                    Region = "Nordeste", Capital = "Maceió",  
                    Country = "BR" },

                new Track { 
                    UF = "AM", State = "Amazonas", 
                    Initial = 69000000, Final = 69299999, 
                    Region = "Norte", Capital = "Manaus", 
                    Country = "BR" },

                new Track { 
                    UF = "AM", State = "Amazonas", 
                    Initial = 69400000, Final = 69899999, 
                    Region = "Norte", Capital = "Manaus", 
                    Country = "BR" },

                new Track { 
                    UF = "AP", State = "Amapá",  
                    Initial = 68900000, Final = 68999999, 
                    Region = "Norte", Capital = "Macapá", 
                    Country = "BR" },

                new Track { 
                    UF = "BA", State = "Bahia", 
                    Initial = 40000000, Final = 48999999, 
                    Region = "Nordeste", Capital = "Salvador", 
                    Country = "BR" },

                new Track { 
                    UF = "CE", State = "Ceará", 
                    Initial = 60000000, Final = 63999999, 
                    Region = "Nordeste", Capital = "Fortaleza",
                    Country = "BR" },

                new Track { 
                    UF = "DF", State = "Distrito Federal", 
                    Initial = 70000000, Final = 72799999, 
                    Region = "Centro-Oeste", Capital = "Brasília", 
                    Country = "BR" },

                new Track { 
                    UF = "DF", State = "Distrito Federal", 
                    Initial = 73000000, Final = 73699999, 
                    Region = "Centro-Oeste", Capital = "Brasília",                     
                    Country = "BR" },

                new Track { 
                    UF = "ES", State = "Espiríto Santo", 
                    Initial = 29000000, Final = 29999999, 
                    Region = "Sudeste", Capital = "Vitória", 
                    Country = "BR" },

                new Track { 
                    UF = "GO", State = "Goias", 
                    Initial = 72800000, Final = 72999999, 
                    Region = "Centro-Oeste", Capital = "Goiânia", 
                    Country = "BR" },

                new Track {
                    UF = "GO", State = "Goias", 
                    Initial = 73700000, Final = 76799999, 
                    Region = "Centro-Oeste", Capital = "Goiânia", 
                    Country = "BR" },

                new Track {
                    UF = "MA", State = "Maranhão", 
                    Initial = 65000000, Final = 65999999,
                    Region = "Nordeste", Capital = "São Luiz",
                    Country = "BR" },

                new Track {
                    UF = "MG", State = "Minas Gerais", 
                    Initial = 30000000, Final = 39999999, 
                    Region = "Sudeste", Capital = "Belo Horizonte", 
                    Country = "BR" },

                new Track { UF = "MS", State = "Mato Grosso do Sul",
                    Initial = 79000000, Final = 79999999, 
                    Region = "Centro-Oeste", Capital = "Campo Grande", 
                    Country = "BR" },

                new Track {
                    UF = "MT", State = "Mato Grosso", 
                    Initial = 78000000, Final = 78899999, 
                    Region = "Centro-Oeste", Capital = "Cuiabá", 
                    Country = "BR" },

                new Track { 
                    UF = "PA", State = "Pará", 
                    Initial = 66000000, Final = 68899999, 
                    Region = "Norte", Capital = "Belém", 
                    Country = "BR" },

                new Track { 
                    UF = "PB", State = "Paraíba",
                    Initial = 58000000, Final = 58999999, 
                    Region = "Nordeste", Capital = "João Pessoa",
                    Country = "BR" },

                new Track { 
                    UF = "PE", State = "Pernambuco", 
                    Initial = 50000000, Final = 56999999, 
                    Region = "Nordeste", Capital = "Recife", 
                    Country = "BR" },

                new Track { 
                    UF = "PI", State = "Piauí", 
                    Initial = 64000000, Final = 64999999,
                    Region = "Nordeste", Capital = "Teresina",
                    Country = "BR" },

                new Track { 
                    UF = "PR", State = "Paraná",  
                    Initial = 80000000, Final = 87999999,
                    Region = "Sul", Capital = "Curitiba", 
                    Country = "BR" },

                new Track { 
                    UF = "RJ", State = "Rio de Janeiro", 
                    Initial = 20000000, Final = 28999999,
                    Region = "Sudeste", Capital = "Rio de Janeiro", 
                    Country = "BR" },

                new Track { 
                    UF = "RN", State = "Rio Grande do Norte",
                    Initial = 59000000, Final = 59999999, 
                    Region = "Nordeste", Capital = "Natal", 
                    Country = "BR" },

                new Track { 
                    UF = "RO", State = "Rondônia", 
                    Initial = 78900000, Final = 78999999, 
                    Region = "Norte", Capital = "Porto Velho", 
                    Country = "BR" },

                new Track { 
                    UF = "RR", State = "Roraima", 
                    Initial = 69300000, Final = 69399999, 
                    Region = "Norte", Capital = "Boa Vista", 
                    Country = "BR" },

                new Track { 
                    UF = "RS", State = "Rio Grande do Sul",
                    Initial = 90000000, Final = 99999999, 
                    Region = "Sul", Capital = "Porto Alegre", 
                    Country = "BR" },

                new Track { 
                    UF = "SC", State = "Santa Catarina", 
                    Initial = 88000000, Final = 89999999, 
                    Region = "Sul", Capital = "Florianópolis",
                    Country = "BR" },

                new Track { 
                    UF = "SE", State = "Sergipe",
                    Initial = 49000000, Final = 49999999, 
                    Region = "Nordeste", Capital = "Aracaju", 
                    Country = "BR" },

                new Track { 
                    UF = "SP", State = "São Paulo", 
                    Initial = 01000000, Final = 19999999, 
                    Region = "Sudeste", Capital = "São Paulo", 
                    Country = "BR" },

                new Track { 
                    UF = "TO", State = "Tocantins", 
                    Initial = 77000000, Final = 77999999, 
                    Region = "Norte", Capital = "Palmas", 
                    Country = "BR" }
            };

            return _tracks;
        }

        public static IEnumerable<Track> GetAll()
        {
            return Tracks;
        }                

        public static Track GetTrackByPostalCode(string postalCode)
        {
            try
            {
                if (postalCode.IsNullOrWhiteSpace())
                {
                    return new Track();
                }

                int postal = Convert.ToInt32(postalCode.RemoveAlphabetic());

                return Tracks.FirstOrDefault(x => x.Initial <= postal && x.Final >= postal);
            }
            catch (Exception)
            {
                return new Track();                
            }           
        }

        public static IEnumerable<Track> GetTracksByState(string state)
        {
            if (String.IsNullOrWhiteSpace(state))
                return new HashSet<Track>();                

            if (state.Length > 2)
            {
                return Tracks.Where(x => x.State.Equals(state, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return Tracks.Where(x => x.UF.Equals(state.ToUpper()));
            }      
        }        
    }
}

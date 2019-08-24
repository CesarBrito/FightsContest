using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Entities
{
    public class Fighter
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "nome")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "idade")]
        public int Age { get; set; }
        [JsonProperty(PropertyName = "artesMarciais")]
        public List<string> MartialArts { get; set; }
        [JsonProperty(PropertyName = "lutas")]
        public int Fights{ get; set; }
        [JsonProperty(PropertyName = "derrotas")]
        public int Loses { get; set; }
        [JsonProperty(PropertyName = "vitorias")]
        public int Wins { get; set; }
    }
}

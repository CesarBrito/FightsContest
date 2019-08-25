using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Entities.Model
{
    public class Fighter
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "nome")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "idade")]
        public decimal Age { get; set; }
        [JsonProperty(PropertyName = "artesMarciais")]
        public List<string> MartialArts { get; set; }
        [JsonProperty(PropertyName = "lutas")]
        public decimal Fights { get; set; }
        [JsonProperty(PropertyName = "derrotas")]
        public decimal Loses { get; set; }
        [JsonProperty(PropertyName = "vitorias")]
        public decimal Wins { get; set; }
        public bool Selected { get; set; }
    }
}

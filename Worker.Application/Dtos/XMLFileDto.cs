using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Application.Dtos
{
    public class XMLFileDto
    {
        public XMLFilePersonDto Person { get; set; }
        public string Random { get; set; }
        public string RandomFloat { get; set; }
        public bool Bool { get; set; }
        public string Date { get; set; }
        public string RegEx { get; set; }
        public string Enum { get; set; }
        public List<string> Elt { get; set; }
    }

    public class XMLFilePersonDto
    {
        [JsonProperty("@firstname")]
        public string Firstname { get; set; }
        [JsonProperty("@lastname")]
        public string Lastname { get; set; }
        [JsonProperty("@city")]
        public string City { get; set; }
        [JsonProperty("@country")]
        public string Country { get; set; }
        [JsonProperty("@firstname2")]
        public string Firstname2 { get; set; }
        [JsonProperty("@lastname2")]
        public string Lastname2 { get; set; }
        [JsonProperty("@email")]
        public string Email { get; set; }
    }
}

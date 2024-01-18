using Newtonsoft.Json;

namespace CalculatorAPI.Models
{
    public class CalculatorRequest
    {
        [JsonProperty("values")]
        public double[] Values { get; set; }

        [JsonProperty("operators")]
        public char[] Operators { get; set; }
    }
}

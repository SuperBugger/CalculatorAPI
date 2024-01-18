using Newtonsoft.Json;

namespace CalculatorAPI.Models
{
    public class CalculatorResponse
    {
        [JsonProperty("result")]
        public double Result { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}

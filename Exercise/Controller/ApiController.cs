using System.Collections.Generic;
using System.Linq;
using Exercise.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Exercise.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IConfiguration configuration { get; }
        public ApiController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var secretConfig = configuration.GetSection(SecretConfig.Section).Get<SecretConfig>();
            var apiConfig = configuration.GetSection(ApiConfig.Section).Get<ApiConfig>().Key;
            IEnumerable<string> keys = configuration.GetSection(MainConfig.Section).Get<string[]>();

            Dictionary<string, TwoValues> keyList = new Dictionary<string, TwoValues>();

            TwoValues val;
            val.Value1 = secretConfig.Local;
            val.Value2 = secretConfig.Prod;
            keyList.Add(SecretConfig.Section, val);

            val.Value1 = keys.ElementAt(0);
            val.Value2 = keys.ElementAt(1);
            keyList.Add(MainConfig.Section, val);

            val.Value1 = "";
            val.Value2 = apiConfig;
            keyList.Add(ApiConfig.Section, val);
            
            return Ok(keyList);
        }
    }
}

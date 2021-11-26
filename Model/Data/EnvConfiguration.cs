using Microsoft.Extensions.Configuration;

namespace Model.Data {

    public class EnvConfiguration{

        private IConfigurationRoot envConfig;
        public string baseUrl { get; }

        public EnvConfiguration(){
            envConfig = new ConfigurationBuilder().AddJsonFile("env.json", true).Build();
            baseUrl = envConfig.GetSection("BASE_URL").Value;
        }

    }


}
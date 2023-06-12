using Microsoft.Extensions.Configuration;

namespace Interview.Infrastructure
{
    public class ApplicationSetting : IApplicationSetting
    {
        private readonly IConfigurationRoot _configuration;

        public ApplicationSetting(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("DefaultConnection");
    }
}
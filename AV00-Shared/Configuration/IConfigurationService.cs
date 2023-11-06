using System.Collections.Specialized;
using System.Configuration;

namespace AV00_Shared.Configuration
{
    public interface IConfigurationService
    {
        public NameValueCollection AppSettings { get; }
        public ConnectionStringSettingsCollection ConnectionStrings { get; }
    }
}

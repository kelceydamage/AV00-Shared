using System.Configuration;
using System.Collections.Specialized;

namespace AV00_Shared.Configuration
{
    public class ConfigurationService: IConfigurationService
    {
        public int RelayInboundTaskCollectionBatchSize;
        public int RelayInboundTaskCollectionBatchDelayMs;
        public bool RelayIssueReceipts;
        public bool RelayEnableDebugLogging;
        public int TransportMessageFrameCount;
        public int DriveServiceUpdateFrequency;
        public string ServiceBusClientSocket;
        public string ServiceBusServerSocket;
        public string SubscribeEventSocket;
        public string PushEventSocket;

        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;

        // TODO: Handle nulls
        public ConfigurationService()
        {
            RelayInboundTaskCollectionBatchSize = int.Parse(ConfigurationManager.AppSettings["RelayInboundTaskCollectionBatchSize"]);
            RelayInboundTaskCollectionBatchDelayMs = int.Parse(ConfigurationManager.AppSettings["RelayInboundTaskCollectionBatchDelayMs"]);
            RelayIssueReceipts = bool.Parse(ConfigurationManager.AppSettings["RelayIssueReceipts"]);
            RelayEnableDebugLogging = bool.Parse(ConfigurationManager.AppSettings["RelayEnableDebugLogging"]);
            TransportMessageFrameCount = int.Parse(ConfigurationManager.AppSettings["TransportMessageFrameCount"]);
            DriveServiceUpdateFrequency = int.Parse(ConfigurationManager.AppSettings["DriveServiceUpdateFrequency"]);
            ServiceBusClientSocket = ConfigurationManager.ConnectionStrings["ServiceBusClientSocket"].ConnectionString;
            ServiceBusServerSocket = ConfigurationManager.ConnectionStrings["ServiceBusServerSocket"].ConnectionString;
            SubscribeEventSocket = ConfigurationManager.ConnectionStrings["SubscribeEventSocket"].ConnectionString;
            PushEventSocket = ConfigurationManager.ConnectionStrings["PushEventSocket"].ConnectionString;
        }
    }
}

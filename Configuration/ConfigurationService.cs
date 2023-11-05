using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;

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
        public string TransportRelayClientSocket;
        public string TransportRelayServerSocket;
        public string EventSocket;
        public string EventReceiptSocket;
        public string EventLogSocket;

        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;

        // TODO: Handle nulls
        public ConfigurationService()
        {
            try
            {
                RelayInboundTaskCollectionBatchSize = int.Parse(ConfigurationManager.AppSettings["RelayInboundTaskCollectionBatchSize"]);
                RelayInboundTaskCollectionBatchDelayMs = int.Parse(ConfigurationManager.AppSettings["RelayInboundTaskCollectionBatchDelayMs"]);
                RelayIssueReceipts = bool.Parse(ConfigurationManager.AppSettings["RelayIssueReceipts"]);
                RelayEnableDebugLogging = bool.Parse(ConfigurationManager.AppSettings["RelayEnableDebugLogging"]);
                TransportMessageFrameCount = int.Parse(ConfigurationManager.AppSettings["TransportMessageFrameCount"]);
                DriveServiceUpdateFrequency = int.Parse(ConfigurationManager.AppSettings["DriveServiceUpdateFrequency"]);
                TransportRelayClientSocket = ConfigurationManager.ConnectionStrings["TransportRelayClientSocket"].ConnectionString;
                TransportRelayServerSocket = ConfigurationManager.ConnectionStrings["TransportRelayServerSocket"].ConnectionString;
                EventSocket = ConfigurationManager.ConnectionStrings["EventSocket"].ConnectionString;
                EventReceiptSocket = ConfigurationManager.ConnectionStrings["EventReceiptSocket"].ConnectionString;
                EventLogSocket = ConfigurationManager.ConnectionStrings["EventLogSocket"].ConnectionString;
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Error reading configuration", ex.Message);
                global::System.Diagnostics.Debugger.Break();
                throw new System.Exception("Error reading configuration", ex);
            }
        }
    }
}

using AV00_Shared.Logging;
using System.Globalization;

namespace AV00_Shared.Messages
{
    public readonly struct LogMessage
    {
        public string TimeStamp => timeStamp;
        private readonly string timeStamp;
        public Guid Id => id;
        private readonly Guid id;
        public string ServiceName => serviceName;
        private readonly string serviceName;
        public EnumLogMessageType LogType => logType;
        private readonly EnumLogMessageType logType;
        public string Message => message;
        private readonly string message;

        public LogMessage(Guid EventId, string ServiceName, EnumLogMessageType LogType, string Message)
        {
            timeStamp = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);
            id = EventId;
            serviceName = ServiceName;
            logType = LogType;
            message = Message;
        }
    }
}

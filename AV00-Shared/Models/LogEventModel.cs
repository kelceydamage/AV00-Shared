using AV00_Shared.Logging;
using System.Text.Json.Serialization;

namespace AV00_Shared.Models
{
    [Serializable]
    public class LogEventModel : EventModel, IEventModel
    {
        public EnumLogMessageType LogType { get => logType; }
        private readonly EnumLogMessageType logType;
        public string Message { get => message; }
        private readonly string message;

        public LogEventModel(string ServiceName, EnumLogMessageType LogType, string Message, Guid? Id = null, string? TimeStamp = null) : base(ServiceName, Id, TimeStamp)
        {
            logType = LogType;
            message = Message;
        }

        // Entity Framework constructor. Used for creating an object from SQL. Also required by JSON.
        [JsonConstructor]
        public LogEventModel(string ServiceName, EnumLogMessageType LogType, string Message, Guid Id, string TimeStamp) : base(ServiceName, Id, TimeStamp)
        {
            logType = LogType;
            message = Message;
        }

        public string ToStringMessage()
        {
            return $"{TimeStamp} {Id} {ServiceName} [{LogType}] {Message}";
        }
    }
}

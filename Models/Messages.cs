using AV00_Shared.Logging;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace AV00_Shared.Models
{
    public class LogMessage
    {
        [Key]
        public Guid Id { get; }
        public string TimeStamp { get; }
        public string ServiceName { get; }
        public EnumLogMessageType LogType { get; }
        public string Message { get; }

        public LogMessage(Guid Id, string ServiceName, EnumLogMessageType LogType, string Message)
        {
            TimeStamp = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);
            this.Id = Id;
            this.ServiceName = ServiceName;
            this.LogType = LogType;
            this.Message = Message;
        }

        public LogMessage(string TimeStamp, Guid Id, string ServiceName, EnumLogMessageType LogType, string Message)
        {
            this.TimeStamp = TimeStamp;
            this.Id = Id;
            this.ServiceName = ServiceName;
            this.LogType = LogType;
            this.Message = Message;
        }
    }
}

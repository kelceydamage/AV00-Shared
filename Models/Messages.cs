using AV00_Shared.Logging;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using AV00_Shared.FlowControl;

namespace AV00_Shared.Models
{
    public class BaseModel : IEventModel
    {
        [Key]
        public Guid Id { get => id; }
        internal Guid id;
        public string TimeStamp { get => timeStamp; }
        internal string timeStamp;
        public string ServiceName { get => serviceName; }
        internal string serviceName;

        public BaseModel(string ServiceName, Guid? Id = null, string? TimeStamp = null)
        {
            serviceName = ServiceName;
            CreateGuidIfNull(Id);
            CreateTimestampIfNull(TimeStamp);
        }

        private void CreateGuidIfNull(Guid? Id = null)
        {
            if (Id is null)
            {
                id = Guid.NewGuid();
            }
            else
            {
                id = (Guid)Id;
            }
        }

        private void CreateTimestampIfNull(string? TimeStamp = null)
        {
            if (TimeStamp is null)
            {
                timeStamp = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);
            }
            else
            {
                timeStamp = TimeStamp;
            }
        }
    }

    public class LogEventModel : BaseModel, IEventModel
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

        // Entity Framework constructor. Used for creating an object from SQL.
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

    public class TaskExecutionEventModel : BaseModel, IEventModel
    {
        public EnumEventProcessingState State { get => state; }
        private readonly EnumEventProcessingState state;
        public string ReasonForState { get => reasonForState; }
        private readonly string reasonForState;

        public TaskExecutionEventModel(string ServiceName, EnumEventProcessingState ExecutionState, string ReasonForExecutionState = "", Guid? Id = null, string? TimeStamp = null) : base(ServiceName, Id, TimeStamp)
        {
            state = ExecutionState;
            reasonForState = ReasonForExecutionState;
        }
    }


}

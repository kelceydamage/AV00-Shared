using AV00_Shared.FlowControl;
using System.Text.Json.Serialization;

namespace AV00_Shared.Models
{
    [Serializable]
    public class TaskExecutionEventModel : EventModel, IEventModel
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

        [JsonConstructor]
        public TaskExecutionEventModel(string ServiceName, EnumEventProcessingState ExecutionState, string ReasonForExecutionState, Guid Id, string TimeStamp) : base(ServiceName, Id, TimeStamp)
        {
            state = ExecutionState;
            reasonForState = ReasonForExecutionState;
        }
    }
}

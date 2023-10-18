namespace AV00_Shared.Models
{
    public interface IEventModel
    {
        public Guid Id { get; }
        public string ServiceName { get; }
        public string TimeStamp { get; }
    }
}

using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace AV00_Shared.Models
{
    public class EventModel : IEventModel
    {
        [Key]
        public Guid Id { get => id; }
        internal Guid id;
        public string TimeStamp { get => timeStamp; }
        internal string timeStamp;
        public string ServiceName { get => serviceName; }
        internal string serviceName;

        public EventModel(string ServiceName, Guid? Id = null, string? TimeStamp = null)
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
}

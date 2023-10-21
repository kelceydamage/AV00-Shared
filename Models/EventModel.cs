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
            id = CreateGuidIfNull(Id);
            timeStamp = CreateTimestampIfNull(TimeStamp);
        }

        private Guid CreateGuidIfNull(Guid? Id = null)
        {
            Guid _id;
            if (Id is null)
            {
               _id = Guid.NewGuid();
            }
            else
            {
                _id = (Guid)Id;
            }
            return _id;
        }

        private string CreateTimestampIfNull(string? TimeStamp = null)
        {
            string _timeStamp;
            if (TimeStamp is null)
            {
                _timeStamp = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);
            }
            else
            {
                _timeStamp = TimeStamp;
            }
            return _timeStamp;
        }
    }
}

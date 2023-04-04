using COINEXEN.Core.Enums;

namespace COINEXEN.Core.Entities
{
    public class Message : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string EMail { get; set; }
        public TopicTitle TopicTitle { get; set; }
        public string Details { get; set; }
        public DateTime SendingDate { get; set; }
    }
}

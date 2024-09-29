using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class Suggestion : BaseEntity
    {
        public int KeyResultId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public bool isAccepted { get; set; }
        public KeyResult KeyResult { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }

}

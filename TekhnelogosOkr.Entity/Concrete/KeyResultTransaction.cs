using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class KeyResultTransaction : BaseEntity
    {
        public KeyResultTransaction()
        {
            UpdatedDate = DateTime.Now;
            IsActive = true;
        }

        public int KeyResultId { get; set; }
        public KeyResult KeyResult { get; set; }
        public string Content { get; set; }
        public int StartingRate { get; set; }
        public int EndingRate { get; set; }
        public int? UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

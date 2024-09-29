namespace TekhnelogosOkr.ViewModel.KeyResultTransaction
{
    public class AddKeyResultTransactionViewModel
    {
        public int KeyResultId { get; set; }
        public string Content { get; set; }
        public int StartingRate { get; set; }
        public int EndingRate { get; set; }
        public int? UpdatedByUserId { get; set; }
    }
}

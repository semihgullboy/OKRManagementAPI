using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.ViewModel.OkrObjectiveTransaction
{
    public class OkrObjectiveTransactionViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UpdatedByUserFullName { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

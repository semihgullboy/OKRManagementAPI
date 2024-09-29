using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.ViewModel.CompanyObjective
{
    public class CompanyObjectiveViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal? Progress { get; set; }
        public int TotalWeight { get; set; }
        public int StatusId { get; set; }

    }
}

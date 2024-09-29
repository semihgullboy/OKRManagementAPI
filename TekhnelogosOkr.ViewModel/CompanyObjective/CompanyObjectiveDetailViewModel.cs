using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.ViewModel.CompanyObjective
{
    public class CompanyObjectiveDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? Progress { get; set; }
        public int? StatusId { get; set; }
        public List<OkrObjectiveViewModel> OkrObjectives { get; set; }
    }
}

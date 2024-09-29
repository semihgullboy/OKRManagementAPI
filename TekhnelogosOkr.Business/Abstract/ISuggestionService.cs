using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface ISuggestionService
    {
        Task<IResult> CreateSuggestionAsync(AddSuggestionViewModel suggestionViewModel);
        Task<IResult> ApproveSuggestionAsync(int suggestionId);
        Task<IDataResult<List<SuggestionDetailsViewModel>>> GetSuggestionDetailsAsync(int receiverId);
        Task<IResult> DeclineSuggestionAsync(int suggestionId);
    }
}

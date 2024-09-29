using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface ISuggestionDal : IEntityRepository<Suggestion>
    {
        Task AddSuggestionsAsync(AddSuggestionViewModel suggestionViewModel);
        Task<List<SuggestionDetailsViewModel>> GetSuggestionsAsync(int receiverId);
    }
}

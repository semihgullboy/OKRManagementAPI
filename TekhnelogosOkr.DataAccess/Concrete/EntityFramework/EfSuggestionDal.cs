using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfSuggestionDal : EfEntityRepositoryBase<Suggestion, TekhnelogosOkrContext>, ISuggestionDal
    {
        private readonly TekhnelogosOkrContext _context;
        public EfSuggestionDal(TekhnelogosOkrContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddSuggestionsAsync(AddSuggestionViewModel suggestionViewModel)
        {
            var suggestions = suggestionViewModel.ReceiverIds.Select(receiverId => new Suggestion
            {
                KeyResultId = suggestionViewModel.KeyResultId,
                SenderId = suggestionViewModel.SenderId,
                ReceiverId = receiverId,
                isAccepted = false,
                IsActive = true,
            }).ToList();

            await Task.Run(() => _context.Suggestions.AddRange(suggestions));
            await _context.SaveChangesAsync();
        }

        public async Task<List<SuggestionDetailsViewModel>> GetSuggestionsAsync(int receiverId)
        {
            var suggestions = await _context.Suggestions
                .Include(s => s.Sender)
                .Include(s => s.KeyResult)
                .Where(s => s.KeyResult.IsActive)
                .Include(s => s.Receiver)
                .Where(s => s.ReceiverId == receiverId && !s.isAccepted && s.IsActive)
                .ToListAsync();

            if (suggestions == null || !suggestions.Any())
            {
                return null;
            }

            var viewModelList = suggestions.Select(s => new SuggestionDetailsViewModel
            {
                SuggestionId = s.Id,
                SenderFullName = $"{s.Sender.FirstName} {s.Sender.LastName}",
                ReceiverFullName = $"{s.Receiver.FirstName} {s.Receiver.LastName}",
                KeyResultTitle = s.KeyResult.Title
            }).ToList();

            return viewModelList;
        }

    }
}


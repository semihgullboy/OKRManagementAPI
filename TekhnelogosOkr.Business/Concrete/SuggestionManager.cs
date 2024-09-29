using System.Net;
using System.Transactions;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.Business.Concrete
{
    public class SuggestionManager : ISuggestionService
    {
        private readonly ISuggestionDal _suggestionDal;
        private readonly IKeyResultDal _keyResultDal;
        private readonly IOkrObjectiveDal _objectiveDal;
        private readonly IOkrObjectiveUserDal _objectiveUserDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeyResultOkrObjectiveDal _keyResultOkrObjectiveDal;

        public SuggestionManager(ISuggestionDal suggestionDal, IKeyResultDal keyResultDal, IOkrObjectiveDal objectiveDal, IOkrObjectiveUserDal objectiveUserDal, IUnitOfWork unitOfWork, IKeyResultOkrObjectiveDal keyResultOkrObjectiveDal)
        {
            _suggestionDal = suggestionDal;
            _keyResultDal = keyResultDal;
            _objectiveDal = objectiveDal;
            _objectiveUserDal = objectiveUserDal;
            _unitOfWork = unitOfWork;
            _keyResultOkrObjectiveDal = keyResultOkrObjectiveDal;
        }

        //Takım Okrlarını kullanıcılara atama işlemi için
        public async Task<IResult> CreateSuggestionAsync(AddSuggestionViewModel suggestionViewModel)
        {
            try
            {
                await _suggestionDal.AddSuggestionsAsync(suggestionViewModel);
                return new SuccessResult(Messages.SuggestionSuccess);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.SuggestionError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> ApproveSuggestionAsync(int suggestionId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var suggestion = await _suggestionDal.GetAsync(s => s.Id == suggestionId);
                if (suggestion == null)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new ErrorResult(Messages.SuggestionNotFound, (int)HttpStatusCode.NotFound);
                }

                suggestion.isAccepted = true;
                await _suggestionDal.UpdateAsync(suggestion);

                var keyResult = await _keyResultDal.GetAsync(kr => kr.Id == suggestion.KeyResultId);
                if (keyResult == null)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new ErrorResult(Messages.KeyResultNotFound, (int)HttpStatusCode.NotFound);
                }

                //Atanan key resultları Okr oluşturmak için
                var objective = new OkrObjective
                {
                    Title = keyResult.Title,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Weight = 0,
                    Progress = 0,
                    IsActive = true,
                };
                await _objectiveDal.AddAsync(objective);

                var objectiveUser = new OkrObjectiveUser
                {
                    OkrObjectiveId = objective.Id,
                    UserId = suggestion.ReceiverId.Value
                };
                objectiveUser.IsActive = true;

                await _objectiveUserDal.AddAsync(objectiveUser);

                //Okr'ın hangi key resulttan oluşturulduğunu tutmak için
                var keyResultOkrObjective = new KeyResultOkrObjective
                {
                    KeyResultId = suggestion.KeyResultId,
                    ObjectiveId = objective.Id,
                };
                keyResultOkrObjective.IsActive = true;
                await _keyResultOkrObjectiveDal.AddAsync(keyResultOkrObjective);

                await _unitOfWork.CommitTransactionAsync();

                return new SuccessResult(Messages.SuggestionSuccess);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.SuggestionError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeclineSuggestionAsync(int suggestionId)
        {
            try
            {
                var suggestion = await _suggestionDal.GetAsync(s => s.Id == suggestionId);
                if (suggestion == null)
                {
                    return new ErrorResult(Messages.SuggestionNotFound, (int)HttpStatusCode.NotFound);
                }

                await _suggestionDal.DeleteAsync(suggestion);

                return new SuccessResult(Messages.SuggestionSuccess);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.SuggestionError, (int)HttpStatusCode.InternalServerError);
            }
        }

        // Beklenen Okr'da göstermek için
        public async Task<IDataResult<List<SuggestionDetailsViewModel>>> GetSuggestionDetailsAsync(int receiverId)
        {
            try
            {
                var suggestion = await _suggestionDal.GetSuggestionsAsync(receiverId);
                if (suggestion == null)
                {
                    return new ErrorDataResult<List<SuggestionDetailsViewModel>>(Messages.SuggestionNotFound, (int)HttpStatusCode.NotFound);
                }

                return new SuccessDataResult<List<SuggestionDetailsViewModel>>(suggestion);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<SuggestionDetailsViewModel>>(Messages.SuggestionError, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

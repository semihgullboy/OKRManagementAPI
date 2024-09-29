using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.Business.Concrete
{
    public class OkrObjectiveTransactionManager : IOkrObjectiveTransactionService
    {
        private readonly IOkrObjectiveTransactionDal _okrObjectiveTransactionDal;
        private readonly IOkrObjectiveDal _okrObjectiveDal;
        private readonly IMapper _mapper;

        public OkrObjectiveTransactionManager(IOkrObjectiveTransactionDal okrObjectiveTransactionDal, IOkrObjectiveDal okrObjectiveDal, IMapper mapper)
        {
            _okrObjectiveTransactionDal = okrObjectiveTransactionDal;
            _okrObjectiveDal = okrObjectiveDal;
            _mapper = mapper;
        }

        // Okr vazgeçilme işlemini eklemek için 
        public async Task<IResult> CreateOkrObjectiveTransaction(AddOkrObjectiveTransactionViewModel okrObjectiveTransactionViewModel)
        {
            var okrObjectiveTransaction = _mapper.Map<OkrObjectiveTransaction>(okrObjectiveTransactionViewModel);
            okrObjectiveTransaction.UpdatedDate = DateTime.Now;
            okrObjectiveTransaction.IsActive = true;

            var okrObjective = await _okrObjectiveDal.GetAsync(okr => okr.Id == okrObjectiveTransactionViewModel.OkrObjectiveId);
            okrObjective.StatusId = okrObjectiveTransactionViewModel.StatusId;

            try
            {
                await _okrObjectiveTransactionDal.AddAsync(okrObjectiveTransaction);
                return new SuccessResult(Messages.OkrObjectiveTransactionSucces);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.OkrObjectiveTransactionFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<OkrObjectiveTViewModel>> GetOkrObjectiveTransactionAsync(int okrObjectiveId)
        {
            try
            {
                var okrObjectiveTViewModel = await _okrObjectiveDal.GetOkrObjectiveWithTransactionsAsync(okrObjectiveId);

                if (okrObjectiveTViewModel == null)
                {
                    return new ErrorDataResult<OkrObjectiveTViewModel>(Messages.OkrObjectiveTransactionNotFound, (int)HttpStatusCode.NotFound);
                }

                return new SuccessDataResult<OkrObjectiveTViewModel>(okrObjectiveTViewModel);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OkrObjectiveTViewModel>(Messages.OkrObjectiveTransactionFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}

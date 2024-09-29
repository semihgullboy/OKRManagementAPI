using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.KeyResult;

namespace TekhnelogosOkr.Business.Concrete
{
    public class KeyResultManager : IKeyResultService
    {
        private readonly IKeyResultDal _keyResultDal;
        private readonly IMapper _mapper;

        public KeyResultManager(IKeyResultDal keyResultDal, IMapper mapper)
        {
            _keyResultDal = keyResultDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<int>> CreateKeyResultAsync(AddKeyResultViewModel keyResultViewModel)
        {
            var keyResult = _mapper.Map<KeyResult>(keyResultViewModel);
            keyResult.OwnerId = keyResultViewModel.CreatedByUserId;
            keyResult.Progress = 0;
            keyResult.CreatedDate = DateTime.Now;
            keyResult.UpdatedDate = DateTime.Now;
            keyResult.IsActive = true;

            try
            {
                await _keyResultDal.AddAsync(keyResult);

                return new SuccessDataResult<int>(keyResult.Id, Messages.KeyResultSuccessAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<int>(default, Messages.KeyResultFailedAdded, (int)HttpStatusCode.InternalServerError);
            }
        }


        public async Task<IResult> DeleteKeyResultAsync(int id)
        {
            try
            {
                var existingKeyResult = await _keyResultDal.GetAsync(kr => kr.Id == id);

                if (existingKeyResult == null)
                {
                    return new ErrorResult(Messages.KeyResultNotFound, (int)HttpStatusCode.NotFound);
                }

                await _keyResultDal.DeleteAsync(existingKeyResult);
                return new SuccessResult(Messages.KeyResultSuccessDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.KeyResultFailedDeleted, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateKeyResultAsync(UpdateKeyResultViewModel keyResultViewModel, int id)
        {
            try
            {
                var existingKeyResult = await _keyResultDal.GetAsync(kr => kr.Id == id);

                if (existingKeyResult == null)
                {
                    return new ErrorResult(Messages.KeyResultNotFound, (int)HttpStatusCode.NotFound);
                }

                existingKeyResult.Title = keyResultViewModel.Title;
                existingKeyResult.UpdatedDate = DateTime.Now;

                await _keyResultDal.UpdateAsync(existingKeyResult);
                return new SuccessResult(Messages.KeyResultSuccessUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.KeyResultFailedUpdated, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
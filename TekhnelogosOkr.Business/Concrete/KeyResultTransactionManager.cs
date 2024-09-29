using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.KeyResultTransaction;

namespace TekhnelogosOkr.Business.Concrete
{
    public class KeyResultTransactionManager : IKeyResultTransactionService
    {
        private readonly IKeyResultTransactionDal _keyResultTransactionDal;
        private readonly IMapper _mapper;

        public KeyResultTransactionManager(IKeyResultTransactionDal keyResultTransactionDal, IMapper mapper)
        {
            _keyResultTransactionDal = keyResultTransactionDal;
            _mapper = mapper;
        }

        public async Task<IResult> CreateKeyResultTransaction(AddKeyResultTransactionViewModel addKeyResultTransactionViewModel)
        {
            try
            {
                var keyResultTransaction = _mapper.Map<KeyResultTransaction>(addKeyResultTransactionViewModel);
                await _keyResultTransactionDal.AddAsync(keyResultTransaction);
                return new SuccessResult(Messages.KeyResultTransactionSuccessAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.KeyResultTransactionFailedAdded, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

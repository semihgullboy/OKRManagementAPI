using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.ViewModel.Status;

namespace TekhnelogosOkr.Business.Concrete
{
    public class StatusManager : IStatusService
    {
        private readonly IStatusDal _statusDal;
        private readonly IMapper _mapper;

        public StatusManager(IStatusDal statusDal, IMapper mapper)
        {
            _statusDal = statusDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<StatusViewModel>>> GetAllStatusesAsync()
        {
            try
            {
                var statuses = await _statusDal.GetAllAsync(s => s.IsActive);
                var statusViewModels = _mapper.Map<List<StatusViewModel>>(statuses);
                return new SuccessDataResult<List<StatusViewModel>>(statusViewModels, Messages.StatuesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<StatusViewModel>>("Bir hata oluştu: " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
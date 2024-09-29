using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.CompanyObjective;

namespace TekhnelogosOkr.Business.Concrete
{
    public class CompanyObjectiveManager : ICompanyObjectiveService
    {
        private readonly ICompanyObjectiveDal _companyObjectiveDal;
        private readonly IMapper _mapper;

        public CompanyObjectiveManager(ICompanyObjectiveDal companyObjectiveDal, IMapper mapper)
        {
            _companyObjectiveDal = companyObjectiveDal;
            _mapper = mapper;
        }

        public async Task<IResult> CreateCompanyObjectiveAsync(AddCompanyObjectiveViewModel companyObjectiveViewModel)
        {
            var companyObjective = _mapper.Map<CompanyObjective>(companyObjectiveViewModel);
            companyObjective.Progress = 0;
            companyObjective.CreatedDate = DateTime.Now;
            companyObjective.UpdatedDate = DateTime.Now;
            companyObjective.IsActive = true;
            try
            {
                await _companyObjectiveDal.AddAsync(companyObjective);
                return new SuccessResult(Messages.CompanyObjectiveSuccessAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.CompanyObjectiveFailedAdded, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteCompanyObjectiveAsync(int id)
        {
            try
            {
                var existingObjective = await _companyObjectiveDal.GetAsync(co => co.Id == id);

                if (existingObjective == null)
                {
                    return new ErrorResult(Messages.CompanyObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                await _companyObjectiveDal.DeleteAsync(existingObjective);
                return new SuccessResult(Messages.CompanyObjectiveSuccessDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.CompanyObjectiveFailedDeleted, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<List<CompanyObjectiveViewModel>>> GetAllCompanyObjectivesAsync()
        {
            try
            {
                var companyObjectives = await _companyObjectiveDal.GetAllAsync(co => co.IsActive);
                var companyObjectiveViewModels = _mapper.Map<List<CompanyObjectiveViewModel>>(companyObjectives);

                var totalWeight = companyObjectives.Sum(co => co.Weight);

                foreach (var objective in companyObjectiveViewModels)
                {
                    objective.TotalWeight = totalWeight;
                }

                return new SuccessDataResult<List<CompanyObjectiveViewModel>>(companyObjectiveViewModels, Messages.CompanyObjectivesListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CompanyObjectiveViewModel>>(Messages.CompanyObjectivesFailedListed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<CompanyObjectiveDetailViewModel>> GetCompanyObjectiveWithOkrObjectivesAsync(int companyObjectiveId)
        {
            var companyObjectives = await _companyObjectiveDal.GetCompanyObjectiveWithOkrObjectivesAsync(companyObjectiveId);
            if (companyObjectives == null)
            {
                return new ErrorDataResult<CompanyObjectiveDetailViewModel>(Messages.CompanyObjectiveNotFound, (int)HttpStatusCode.NotFound);
            }
            var companyObjectivesViewModel = _mapper.Map<CompanyObjectiveDetailViewModel>(companyObjectives);
            return new SuccessDataResult<CompanyObjectiveDetailViewModel>(companyObjectivesViewModel, Messages.CompanyObjectivesListed);
        }

        public async Task<IResult> UpdateCompanyObjectiveAsync(UpdateCompanyObjectiveViewModel companyObjectiveViewModel, int id)
        {
            try
            {
                var existingObjective = await _companyObjectiveDal.GetAsync(co => co.Id == id);
                if (existingObjective == null)
                {
                    return new ErrorResult(Messages.CompanyObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                existingObjective.Title = companyObjectiveViewModel.Title;
                existingObjective.Weight = companyObjectiveViewModel.Weight;
                existingObjective.UpdatedDate = DateTime.Now;

                await _companyObjectiveDal.UpdateAsync(existingObjective);
                return new SuccessResult(Messages.CompanyObjectiveSuccessUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.CompanyObjectiveFailedUpdated, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
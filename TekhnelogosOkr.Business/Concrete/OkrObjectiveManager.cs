using AutoMapper;
using System.Net;
using System.Security.AccessControl;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.Business.Concrete
{
    public class OkrObjectiveManager : IOkrObjectiveService
    {
        private readonly IOkrObjectiveDal _objectiveDal;
        private readonly IMapper _mapper;
        private readonly ICompanyObjectiveOkrObjectiveDal _companyObjective_OkrObjectiveDal;
        private readonly IDepartmentService _departmentService;
        private readonly IOkrObjectiveUserDal _okrObjectiveUserDal;
        private readonly IUnitOfWork _unitOfWork;

        public OkrObjectiveManager(IOkrObjectiveDal objectiveDal, IMapper mapper, ICompanyObjectiveOkrObjectiveDal companyObjective_OkrObjectiveDal, IDepartmentService departmentService, IOkrObjectiveUserDal okrObjectiveUserDal, IUnitOfWork unitOfWork)
        {
            _objectiveDal = objectiveDal;
            _mapper = mapper;
            _companyObjective_OkrObjectiveDal = companyObjective_OkrObjectiveDal;
            _departmentService = departmentService;
            _okrObjectiveUserDal = okrObjectiveUserDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> CreateDepartmanObjectiveAsync(AddDepartmentOkrObjectiveViewModel objectiveViewModel)
        {
            var isDepartmentManager = await _departmentService.IsUserDepartmentManagerAsync(objectiveViewModel.CreatedByUserId);
            if (!isDepartmentManager)
            {
                return new ErrorResult(Messages.ObjectiveAddedRole, (int)HttpStatusCode.Forbidden);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var objective = _mapper.Map<OkrObjective>(objectiveViewModel);
                objective.Progress = 0;
                objective.CreatedDate = DateTime.Now;
                objective.UpdatedDate = DateTime.Now;
                objective.IsActive = true;

                await _objectiveDal.AddAsync(objective);

                // Oluşturulan departman hedefinin hangi şirket hedefine bağlı olduğunu eklemek için
                var companyObjectiveOkrObjective = new CompanyObjectiveOkrObjective
                {
                    CompanyObjectiveId = objectiveViewModel.CompanyObjectiveId,
                    ObjectiveId = objective.Id
                };
                companyObjectiveOkrObjective.IsActive = true;
                await _companyObjective_OkrObjectiveDal.AddAsync(companyObjectiveOkrObjective);

                // Oluşturulan departman hedefinin kime ait olduğunu eklemek için
                var objectiveUser = new OkrObjectiveUser
                {
                    UserId = objectiveViewModel.CreatedByUserId,
                    OkrObjectiveId = objective.Id
                };
                objectiveUser.IsActive = true;
                await _okrObjectiveUserDal.AddAsync(objectiveUser);

                await _unitOfWork.CommitTransactionAsync();
                return new SuccessResult(Messages.ObjectiveAddedSuccess);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.ObjectiveAddedFailed + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> CreateObjectiveAsync(AddOkrObjectiveViewModel objectiveViewModel)
        {
            try
            {
                var objective = _mapper.Map<OkrObjective>(objectiveViewModel);
                objective.Progress = 0;
                objective.CreatedDate = DateTime.Now;
                objective.UpdatedDate = DateTime.Now;
                objective.IsActive = true;

                await _unitOfWork.BeginTransactionAsync();

                await _objectiveDal.AddAsync(objective);

                var objectiveUser = new OkrObjectiveUser
                {
                    UserId = objectiveViewModel.CreatedByUserId,
                    OkrObjectiveId = objective.Id
                };
                objectiveUser.IsActive = true;
                await _okrObjectiveUserDal.AddAsync(objectiveUser);

                await _unitOfWork.CommitTransactionAsync();

                return new SuccessResult(Messages.ObjectiveAddedSuccess);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.ObjectiveAddedFailed + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteObjectiveAsync(int id)
        {
            try
            {
                var existingObjective = await _objectiveDal.GetAsync(o => o.Id == id);

                if (existingObjective == null)
                {
                    return new ErrorResult(Messages.ObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                await _objectiveDal.DeleteAsync(existingObjective);
                return new SuccessResult(Messages.ObjectiveDeletedSuccess);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ObjectiveDeletedFailed + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<List<OkrObjectiveViewModel>>> GetOkrObjectivesByUserIdAsync(int userId)
        {
            try
            {
                var objective = await _objectiveDal.GetOkrObjectivesByUserIdAsync(userId);
                if (objective == null)
                {
                    return new ErrorDataResult<List<OkrObjectiveViewModel>>(Messages.ObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                var objectiveViewModel = _mapper.Map<List<OkrObjectiveViewModel>>(objective);
                var totalWeight = objective.Where(co => co.StatusId == 1 || co.StatusId == 2).Sum(co => co.Weight);

                foreach (var objectives in objectiveViewModel)
                {
                    objectives.TotalWeight = totalWeight;
                }
                return new SuccessDataResult<List<OkrObjectiveViewModel>>(objectiveViewModel, Messages.ObjectivesListedSuccess);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<OkrObjectiveViewModel>>(Messages.ObjectivesListedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateDepartmentOkrObjectiveAsync(UpdateDepartmentOkrObjectiveViewModel objectiveViewModel, int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var existingObjective = await _objectiveDal.GetAsync(o => o.Id == id);

                if (existingObjective == null)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new ErrorResult(Messages.ObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                existingObjective.Title = objectiveViewModel.Title;
                existingObjective.UpdatedDate = DateTime.Now;
                existingObjective.StatusId = objectiveViewModel.StatusId;

                await _objectiveDal.UpdateAsync(existingObjective);

                var companyObjectiveOkrObjective = new CompanyObjectiveOkrObjective
                {
                    CompanyObjectiveId = objectiveViewModel.CompanyObjectiveId,
                    ObjectiveId = existingObjective.Id
                };
                await _companyObjective_OkrObjectiveDal.UpdateAsync(companyObjectiveOkrObjective);

                await _unitOfWork.CommitTransactionAsync();
                return new SuccessResult(Messages.ObjectiveUpdatedSuccess);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.ObjectiveUpdatedFailed + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateOkrObjectiveAsync(UpdateOkrObjectiveViewModel objectiveViewModel, int id)
        {
            try
            {
                var existingObjective = await _objectiveDal.GetAsync(o => o.Id == id);

                if (existingObjective == null)
                {
                    return new ErrorResult(Messages.ObjectiveNotFound, (int)HttpStatusCode.NotFound);
                }

                existingObjective.Title = objectiveViewModel.Title;
                existingObjective.UpdatedDate = DateTime.Now;
                existingObjective.StatusId = objectiveViewModel.StatusId;

                await _objectiveDal.UpdateAsync(existingObjective);
                return new SuccessResult(Messages.ObjectiveUpdatedSuccess);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ObjectiveUpdatedFailed + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
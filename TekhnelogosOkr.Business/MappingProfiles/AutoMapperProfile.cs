using AutoMapper;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.CompanyObjective;
using TekhnelogosOkr.ViewModel.Department;
using TekhnelogosOkr.ViewModel.KeyResult;
using TekhnelogosOkr.ViewModel.KeyResultTransaction;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;
using TekhnelogosOkr.ViewModel.Role;
using TekhnelogosOkr.ViewModel.Status;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.Business.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DepartmentViewModel, Department>();
            CreateMap<Department, DepartmentViewModel>();

            CreateMap<UserViewModel, User>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore());
            CreateMap<User, UserViewModel>();
            CreateMap<User, ManagerViewModel>();

            CreateMap<LdapUserViewModel, User>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore());
            CreateMap<User, LdapUserViewModel>();

            CreateMap<AddCompanyObjectiveViewModel, CompanyObjective>();
            CreateMap<CompanyObjective, CompanyObjectiveViewModel>();
            CreateMap<CompanyObjectiveDetailViewModel, CompanyObjective>();
            CreateMap<UpdateCompanyObjectiveViewModel, CompanyObjective>();

            CreateMap<StatusViewModel, Status>();
            CreateMap<Status, StatusViewModel>();

            CreateMap<AddOkrObjectiveViewModel, OkrObjective>();
            CreateMap<AddDepartmentOkrObjectiveViewModel, OkrObjective>();
            CreateMap<OkrObjective, OkrObjectiveViewModel>();
            CreateMap<UpdateOkrObjectiveViewModel, OkrObjective>();

            CreateMap<AddKeyResultViewModel, KeyResult>();
            CreateMap<KeyResult, KeyResultViewModel>();
            CreateMap<UpdateKeyResultViewModel, KeyResult>();

            CreateMap<AddOkrObjectiveTransactionViewModel, OkrObjectiveTransaction>();

            CreateMap<Role, RoleViewModel>();

            CreateMap<AddKeyResultTransactionViewModel, KeyResultTransaction>();
        }
    }
}
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Authentication;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IResult> Login(UserLoginViewModel user);
    }
}
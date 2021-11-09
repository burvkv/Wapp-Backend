using Core.Entity.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult AddClaimsToUser(User user, int[] operationClaimIds);
        IResult DeleteClaimsToUser(User user, int[] operationClaimIds);
    }

}

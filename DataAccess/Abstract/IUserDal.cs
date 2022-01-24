using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserDetailsDto> GetUserDetails(int? userId);
    }
}

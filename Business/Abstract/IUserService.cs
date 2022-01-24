using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
        IResult Add(User user);
        IDataResult<List<UserDetailsDto>> GetUserDetailsDto(int? userId);
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, PathAppContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (PathAppContext context = new PathAppContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = userOperationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }
        }

        public List<UserDetailsDto> GetUserDetails(int? userId)
        {
            using (PathAppContext context = new PathAppContext())
            {
                var result = from user in context.Users
                             join address in context.Addresses
                                on user.Id equals address.UserId
                             where user.Id == userId
                             select new UserDetailsDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 PhoneNumber = user.PhoneNumber,
                                 Province = address.Province,
                                 District = address.District,
                                 AddressDescription = address.AddressDescription,
                             };
                return result.ToList();
            }
        }
    }
}

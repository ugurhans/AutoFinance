using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDto> getUserDtos(Expression<Func<UserDto, bool>> filter = null);
    }
}

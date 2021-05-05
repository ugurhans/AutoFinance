using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        User GetByMail(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        List<OperationClaim> GetClaims(User user);
        IDataResult<List<UserDto>> getAllUserDto();
        IDataResult<List<UserDto>> getAllUserDtoById(int userId);
    }
}

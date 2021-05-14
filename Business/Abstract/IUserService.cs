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
        IDataResult<User> Get(int userId);

        IResult Add(User User);
        IResult Delete(User user);
        IResult Update(User user);




        IDataResult<User> GetByMailData(string email);
        User GetByMail(string email);

        IDataResult<List<UserDto>> getAllUserDto();
        IDataResult<List<UserDto>> GetUserDtoByMail(string email);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<UserDto>> getAllUserDto()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.getUserDtos());
        }

        public IDataResult<List<UserDto>> getAllUserDtoById(int userId)
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.getUserDtos(u => u.Id == userId));
        }
    }
}

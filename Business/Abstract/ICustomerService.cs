using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);

        IDataResult<List<CustomerDto>> GetAllCustomersDto();
        IDataResult<List<CustomerDto>> GetAllCustomersDtoById(int customerId);


        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);



    }
}

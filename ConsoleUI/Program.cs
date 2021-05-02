using System;
using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFrameWork;

namespace ConsoleUI
{
    class Program
    {
        static IProductService _itemService;

        public Program(IProductService itemService)
        {
            _itemService = itemService;
        }


        static void Main(string[] args)
        {

            var result = _itemService.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Name + "/" + item.Price + "/" + item.Description + "/" + item.StockAmount);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

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


        }

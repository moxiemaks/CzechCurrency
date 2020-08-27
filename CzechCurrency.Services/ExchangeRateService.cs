﻿using System;
using System.Threading.Tasks;
using Common.Service;
using CzechCurrency.Data.Contract;
using CzechCurrency.Entities;
using CzechCurrency.Services.Contract;

namespace CzechCurrency.Services
{
    /// <summary>
    /// Сервис работы со справочником валют
    /// </summary>
    public class ExchangeRateService : BaseService<ExchangeRate>, IExchangeRateService
    {
        private readonly IExchangeRateRepository _repository;

        public ExchangeRateService(IExchangeRateRepository repository) : base(repository)
        {
            _repository = repository;
        }


        public Task<ExchangeRate> Get(string numberCurrency, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Service;
using CzechCurrency.Entities;
using JetBrains.Annotations;

namespace CzechCurrency.Services.Contract
{
    /// <summary>
    /// Интерфейс истории курсов валют
    /// </summary>
    public interface IExchangeRateService : IBaseService<ExchangeRate>
    {
        /// <summary>
        /// Получить курс обмена по дате и по коду валюты
        /// </summary>
        /// <param name="numberCurrency">Код</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        [ItemNotNull]
        Task<ExchangeRate> Get([NotNull] string numberCurrency, DateTime date);

        /// <summary>
        /// Пакетное сохранение курсов обмена в БД
        /// </summary>
        /// <param name="exchangeRates">Набор курсов</param>
        /// <returns></returns>
        Task AddRange(IEnumerable<ExchangeRate> exchangeRates);

        /// <summary>
        /// Пакетное удаление курсов обмена в БД за год
        /// </summary>
        /// <param name="year">год</param>
        /// <returns></returns>
        Task DeleteByYear(int year);

    }
}

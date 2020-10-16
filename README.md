# CzechCurrency

Приложение для отслеживания валютных курсов Чешского национального банка.

## Описание

Решение содержит три приложения:

* Консольное приложение на C#, которое при запуске считывает валютные курсы Чешский национального банка
* ASP.NET Core Web API выдающее валютные курсы из БД клиенту
* Single Page Aplication на котором пользователь может выбрать день, месяц и год, название валюты, а также посмотреть ее курс к кроне на этот день.

### Особенности

* Репозиторий ведется по GitFlow
* Используются 3 конфига для развертывания в средах Development, Staging, Production
* Подключено логирование Serilog

## База данных

* PostgreSQL 12.4
* Entity Framework Core Code First
* Используются индексы
* Используются внешние ключи

## CzechCurrency.Downloader
Чешский национальный банк выкладывает курсы по адресу https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/year.txt?year=2018.
Первая строка содержит название валюты и ее количество, последующие строки — курсы на конкретную дату.

Консольное приложение при запуске будет считывает информацию по указанной выше ссылке и записывает в базу новые курсы на текущий год.

В файле appsettings.json в параметре "CzechCurrencyDownloaderOptions":"Year" можно передать год, за который нужно загрузить валютные курсы

Запросы к банку выполняются через интерфейс API с использование Refit

## CzechCurrency.API

Предоставляет два ендпоинта:

* http://localhost:5001/Currency/GetAll - возвращает справочник всех валют в БД
* http://localhost:5001/ExchangeRate/Get?CurrencyCode=RUB&Date=2020-08-01 - возвращает курс обмена на указанный день для выбранной валюты по отношению к чешской кроне

В выходные и праздничные дни выдается курс ближайшего предыдущего рабочего дня.
## CzechCurrency.Site

### При запуске приложения

* Запрашивается список доступных валют
* Запрашивается курс для первой валюты на текущую дату

При изменении даты или валюты происходит запрос в API  для получения курса обмена

## Что можно доделать

* Запросы в API по токену
* Redis кэш
* Хелс чеки
* PaginationQuery
* Потокобезопасность на случай одновременного запуска
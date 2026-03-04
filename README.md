# Pahra – Цифровая платформа для ежегодного мероприятия «Трип Пахра». На текущем этапе — модуль регистрации участников; в планах расширение функционала (личные кабинеты, регистрация на события, медиа-блоки, панель администрирования).(In development)

Ключевые цели разработки:

- Демонстрация Clean Architecture с разделением на 4 слоя (Domain, Application, Infrastructure, WebApi)
- Реализация CQRS паттерна через MediatR (разделение команд и запросов)
- Repository Pattern для абстракции доступа к данных
- Entity Framework Core с миграциями и PostgreSQL
- REST API с полной документацией и примерами

Дорожная карта (Roadmap)

Ниже представлен план реализации функционала:

- [x] Проектирование архитектуры (Clean Architecture с 4 слоями)
- [x] Настройка PostgreSQL и EF Core миграции
- [x] Реализация CQRS паттерна для участников через MediatR
- [x] CRUD операции для участников (Create, Read, Update, Delete)
- [x] Docker Compose для готовой разработки
- [ ] Проектирование остальных сущностей(Мероприятия, авторизация, статистика)
- [ ] Глобальная обработка ошибок 
- [ ] Валидация входных данных (FluentValidation)
- [ ] Система авторизации (JWT)
- [ ] Unit-тесты (xUnit + Moq)
- [ ] Логирование

Архитектура и Технологии

**Стек:** C#, .NET 10, ASP.NET Core, MediatR (CQRS), Entity Framework Core, PostgreSQL, React + TypeScript, Vite, Docker Compose.

**База данных:** PostgreSQL 18.

**Архитектурные паттерны:**
- Clean Architecture (Domain → Application → Infrastructure → WebApi)
- CQRS (Command Query Responsibility Segregation)
- MediatR для маршрутизации команд и запросов
- Repository Pattern для абстракции доступа к БД
- Dependency Injection & IoC контейнер
- DTO (Data Transfer Objects)

Как запустить проект

**Предварительные требования**

- .NET 10 SDK
- Docker Desktop
- PostgreSQL 18+ (или использовать Docker)
- Node.js 18+

**Шаги запуска**

1. Клонируйте репозиторий:
```bash
git clone https://github.com/YOUR_NICK/Pahra.git
cd Pahra
```

2. Создайте .env файл (опционально):
```bash
cp .env.example .env
```
Измените переменные в файле .env:

POSTGRES_USER=postgres-user
POSTGRES_PASSWORD=secret
POSTGRES_DB=db
ConnectionStrings__DefaultConnection=
Mediatr__License=
3. Запустите Docker Compose:
```bash
docker-compose up -d
```

**API(Scalar) будет доступен по адресу:** http://localhost:5200/scalar

**Альтернатива – локальная разработка без Docker:**
```bash
# Убедитесь, что PostgreSQL установлена локально
cd src/Pahra.WebApi
dotnet ef database update
dotnet run --configuration Debug
```

Примененные навыки и решения

В процессе разработки я реализовал и закрепил следующие навыки:

**Clean Architecture:**
Разделение приложения на 4 отдельных слоя (Domain, Application, Infrastructure, WebApi) с чёткими правилами зависимостей. Внутренние слои не знают о внешних – это даёт гибкость и тестируемость.

**CQRS паттерн:**
Разделение операций на команды (изменение данных) и запросы (чтение) через MediatR. Это упрощает масштабирование и оптимизацию – можно по-разному обрабатывать Commands и Queries.

**Repository Pattern:**
Абстракция доступа к данным через интерфейсы. Теперь бизнес-логика не зависит от конкретной реализации БД – можно легко поменять PostgreSQL на другую СУБД.

**Dependency Injection:**
Правильная настройка IoC контейнера в ASP.NET Core. Это режет boilerplate и делает code более testable благодаря инъекции зависимостей.

**Docker & Docker Compose:**
Контейнеризация приложения и БД. Теперь новый разработчик просто запускает `docker-compose up` и всё готово к разработке.

Контактная информация

- **Telegram:** [@makcnov](https://t.me/makcnov)
- **Email:** makcnov0001@gmail.com

---

**Проект создан для ежегодного мероприятия "Трип Пахра" и для обучения и демонстрации навыков в Clean Architecture, CQRS и современной архитектуры .NET приложений.**
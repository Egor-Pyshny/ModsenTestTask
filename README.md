# **Описание**
Разработка web-приложения для работы с событиями, выполняется на .Net Core, 
с использованием EF Core. Для разработки клиентской части приложения следует 
использовать Angular или React.

**Функционал Web-приложения:**
-	Получение списка всех событий;
-	Получение определённого события по его Id;
-	Регистрация нового события;
-	Изменение информации о существующем событии;
-	Удаление события.
-	Получение списка событий по определенным критериям
  (по дате, месту проведения или организатору).
-	Регистрация участия пользователя в событии.
-	Отмена участия пользователя в событии.
-	Получение списка участников определённого события.
-	Отправка уведомлений зарегистрированным участникам о изменениях в событии
  (например, об изменении даты или места проведения).
-	Возможность добавления изображений к событиям и их хранение.

**Разработка клиентской части приложения:**
-	Реализация страницы аутентификации/регистрации пользователей;
-	Реализация страницы отображения списка событий. Если все места на событие
  уже заняты, отображать информацию о том, что свободных мест нет;
-	Реализация страницу с подробной информацией о конкретном событии;
-	Реализация страницы для просмотра событий на которые пользователь был
  зарегистрирован;
-	Реализация пагинации, поиска по названию/дате события, фильтрации по
  категории/организатору;
-	Для пользователей, обладающих правами администратора, должен быть
  предусмотрен раздел для управления списком событий, где они могут создавать,
  редактировать и удалять события.

**Требования к Web API**
-	Реализация policy-based авторизации с использованием refresh и
  jwt access токенов;
-	Внедрение паттерна репозиторий и Unit of Work;
-	Разработка middleware для глобальной обработки исключений.
-	Реализация пагинации;
-	Обеспечение покрытия репозиториев и сервисов unit-тестами;
-	*Внедрение кеширования изображений (будет плюсом).

**Необходимые к использованию технологии:**
-	.Net 5.0+;
-	Entity Framework Core;
-	MS SQL / PostgreSQL or any other;
-	AutoMapper / Mapster or any other;
-	FluentValidation;
-	Authentication via jwt access & refresh token (ex.: IdentityServer4);
-	Swagger;
-	EF Fluent API;
-	Angular/React;
-	xUnit/nUnit.

**Архитектура:**
- Приложение должно быть разработано на чистой архитектуре.
____
## **Инструкция по запуску:**
- Будет в будущем
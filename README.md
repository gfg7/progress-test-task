# progress-test-task
Тестовое задание ООО НПК ПРОГРЕСС.
1) Создать структуру таблиц:

А) Пациенты

Таблица Пациент

Поле
Тип

Ид Пациента 
Строка (36) 

Фамилия
Строка (50)

Имя
Строка (50)

Отчество
Строка (50)

Дата рождения
Дата

Телефон
Строка (15)

Б) Посещения

Таблица Посещения

Поле
Тип
Комментарий
Ид посещения
Строка (36) 
 
Дата посещения
Дата
 
Диагноз
Строка (36) 
Справочник МКБ10

ИД Пациента
Строка (36) 
 
 
Справочник МКБ10 найти самостоятельно на просторах интернета.

СУБД использовать Oracle или MS SQL, либо любое СУБД.

2) Требования к интерфейсу программы:

Программа должна быть разработана в среде разработки Visual Studio, с использованием языков
программирования C#.net, на платформе ASP.net либо WindowsForms.

Программа должна содержать формы:

Ввод данных по пациенту.

Ввод данных по посещениям.

Просмотр данных по пациенту, фильтрация данных.

Просмотр по выбранному пациенту его посещения.

Выгрузка выбранного пациента с его посещениями в XML файл.
Структура XML файла на ваше усмотрение.

## Запуск

Установить переменную среды DB_CONN - строка подключения к PostgreSQL для EF в формате `Host=<Host>;Port=<Port>;Database=<Database>;Username=<Username>;Password=<Password>`

Если БД не существует, то создастся при запуске

Если не существует таблиц, запустить скрипт миграции create_schema.sql или использовать cli dotnet ef

Импортировать справочник mkb10.csv в таблицу Diagnosis

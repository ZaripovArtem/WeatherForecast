# Задание 1 - Приложение WPF с прогнозом погоды

Пользовательский интерфейс WPF, платформа .NET 7.

Данные о погоде берутся с https://openweathermap.org/api

Для запуска требуется склонировать репозиторий и запустить программу.

Окна приложения:

![image](https://github.com/ZaripovArtem/WeatherForecast/assets/78857901/4b301112-5e03-4d05-aff5-a28d10bb831b)

# Задание 2 - SQL

Находится в файле SecondTask.txt.
При клонировании репозитория, расположение файла следующее:

![image](https://github.com/ZaripovArtem/WeatherForecast/assets/78857901/05e829af-43b5-4375-b7b0-f4f89f68fe5e)

Для удобства, продублировано ниже:

1. Вывести менеджеров у которых имеется номер телефона

        SELECT ID, Fio
        FROM Managers
        WHERE Phone IS NOT NULL

2. Вывести кол-во продаж за 20 июня 2021

        SELECT COUNT(*) FROM Sells
        WHERE Date = '2021-06-20'

3. Вывести среднюю сумму продажи с товаром 'Фанера';

        SELECT AVG(Sum) FROM Sells
        WHERE ID_Prod = 
          (SELECT ID FROM Products
          WHERE Name='Фанера')

4. Вывести фамилии менеджеров и общую сумму продаж для каждого с товаром 'ОСБ';

        SELECT Managers.Fio as fio, SUM(Sells.Sum) as sum
        FROM Managers, Sells
        WHERE Managers.ID = Sells.ID_Manag
        AND Sells.ID_Prod = 
          (SELECT Products.ID FROM Products
          WHERE Products.Name = 'ОСБ')
        GROUP BY fio

5. Вывести менеджера и товар, который продали 22 августа 2021

        SELECT Managers.Fio as manager, Products.Name as product
        FROM Managers, Products, Sells
        WHERE Managers.ID = Sells.ID_Manag
          AND Products.ID = Sells.ID_Prod
          AND Sells.Date = '2021-08-22'

6. Вывести все товары, у которых в названии имеется 'Фанера' и цена не ниже 1750

        SELECT Products.Name, Products.Cost
        FROM Products
        WHERE Products.Name LIKE '%Фанера%'
          AND Products.Cost >= 1750

7. Вывести историю продаж товаров, группируя по месяцу продажи и наименованию товара

        SELECT Managers.Fio, Products.Name, Sells.Count, Sells.Sum, Sells.Date
        FROM Products, Sells, Managers
        WHERE Managers.ID = Sells.ID_Manag
          AND Products.ID = Sells.ID_Prod
        ORDER BY Sells.Date, Products.Name

8. Вывести количество повторяющихся значений и сами значения из таблицы 'Товары', где количество повторений больше 1.

        SELECT Name, COUNT(*) AS Name_count
        FROM Products
        GROUP BY Name
        HAVING COUNT(*) > 1

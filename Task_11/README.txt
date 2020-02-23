You can change type of DAL in Web.config: "DB" for SQL DAL and "JSON" for Json DAL;
SQL Connection string  you can change in Web.config (locate in PL -> WebPagesPL)(for DB DAL);
Default path to json files is "C:/dataStorage", you can change it in Web.config (locate in PL -> WebPagesPL)(for JSON DAL);
Default admin login is: admin
Defaul admin password is: admin
P.S.
Столкнулся проблемой, когда попробовал собрать решение на другом своем пк: Почему то после первой сборки вылетала ошибка "Could not find a part of the path … bin\roslyn\csc.exe".
Вроде ошибка связанна с 19-ой версией VS. Если вдруг появится(на двух других пк все собиралось нормально) такая ошибка, то мне помогло очищение решения, и его последующая пересборка.
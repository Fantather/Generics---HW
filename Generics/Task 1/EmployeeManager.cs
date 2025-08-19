using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Задание 1
// Создайте приложение для менеджмента сотрудников и паролей
// Необходимо хранить следующую информацию:
// Логины сотрудников;
// Пароли сотрудников.
// Для хранения информации используйте Dictionary<T>.

// Приложение должно предоставлять такую функциональность:
// Добавление логина и пароля сотрудника;
// Удаление логина сотрудника;
// Изменение информации о логине и пароле сотрудника;
// Получение информации о пароле по логину сотрудника.

namespace Generics_HW.Task_1
{
    internal class EmployeeManager
    {
        private readonly Dictionary<string, string> credentials = [];
        public IReadOnlyDictionary<string, string> Credentials => credentials;


        public bool AddUser(string login, string password) => credentials.TryAdd(login, password);

        public bool RemoveUser(string login) => credentials.Remove(login);

        public bool ChangeLogin(string old_login, string new_login)
        {
            if (credentials.ContainsKey(old_login) == false || credentials.ContainsKey(new_login) == true || old_login == new_login)
                return false;

            credentials.Add(new_login, credentials[old_login]);
            credentials.Remove(old_login);

            return true;
        }

        public bool ChangePassword(string login, string new_password)
        {
            if(credentials.ContainsKey(login) == false)
                return false;

            credentials[login] = new_password;
            return true;
        }

        public string? GetPassword(string login) => credentials.TryGetValue(login, out string? password) ? password : null;
    }
}

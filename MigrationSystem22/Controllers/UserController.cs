using System;
using System.Collections.Generic;
using MigrationSystem22.Models;
using MigrationSystem22.Services;

namespace MigrationSystem22.Controllers
{
    public class UserController
    {
        private readonly UserService _userService = new UserService();
        private readonly RoadMapService _roadMapService = new RoadMapService();
        private readonly AccountService _accountService = new AccountService();

        private User _currentUser;

        private AccountEntity _currentOperatorAccount;


        public void NewUser()
        {
            _currentUser = new User();
        }

        public bool LoadUser(int id, out string error)
        {
            try
            {
                var u = _userService.GetUserById(id)
                        ?? throw new Exception($"Пользователь {id} не найден");
                _currentUser = u;
                error = null;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }


        public bool LoginMigrant(string username, string password, out string error)
        {
            error = null;
            var acct = _accountService.AuthenticateAccount(username, password);
            if (acct == null || acct.Role != "Migrant")
            {
                error = "Неверный логин или пароль мигранта";
                return false;
            }
            _currentUser = acct.User;
            return true;
        }

        public bool RegisterMigrant(string username, string password, out string error)
        {
            error = null;
            try
            {
                var acct = _accountService.RegisterOperatorOrMigrant(
                    username, password, "Migrant"
                );
                _currentUser = acct.User;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public int CurrentUserId => _currentUser?.Id ?? 0;

        public bool EnterDetails(
            DateTime entryDate,
            DateTime? registrationDate,
            DateTime? patentIssueDate,
            string fullName,
            string country,
            bool qualification,
            bool isInProgram,
            bool wasMigrant,
            bool hasWorkPermit,
            bool hasPatent,
            string entryGoal,
            out string error
        )
        {
            error = null;
            _currentUser.EntryDate = entryDate;
            _currentUser.RegistrationDate = registrationDate;
            _currentUser.PatentIssueDate = patentIssueDate;
            _currentUser.FullName = fullName;
            _currentUser.Country = country;
            _currentUser.Qualification = qualification;
            _currentUser.IsInProgram = isInProgram;
            _currentUser.WasMigrant = wasMigrant;
            _currentUser.HasWorkPermit = hasWorkPermit;
            _currentUser.HasPatent = hasPatent;
            _currentUser.EntryGoal = entryGoal;

            try
            {
                if (_currentUser.Id == 0)
                    _userService.SaveUser(_currentUser);
                else
                    _userService.UpdateUser(_currentUser);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message +
                        (ex.InnerException != null ? "\nInner: " + ex.InnerException.Message : "");
                return false;
            }
        }

        public RoadMap ViewRoadMap()
            => _roadMapService.GenerateForUser(_currentUser);

        public List<User> GetAllUsers()
            => _userService.GetAllUsers();


        public bool AnyOperatorExists()
            => _accountService.HasAnyOperator();

        public bool RegisterOperator(string username, string password, out string error)
        {
            error = null;
            if (AnyOperatorExists())
            {
                error = "Оператор уже зарегистрирован";
                return false;
            }

            try
            {
                _currentOperatorAccount = _accountService.RegisterOperatorOrMigrant(
                    username, password, "Operator"
                );
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool LoginOperator(string username, string password, out string error)
        {
            error = null;
            var acct = _accountService.AuthenticateAccount(username, password);
            if (acct == null || acct.Role != "Operator")
            {
                error = "Неверный логин или пароль оператора";
                return false;
            }
            _currentOperatorAccount = acct;
            return true;
        }

        public int CurrentOperatorUserId => _currentOperatorAccount?.UserId ?? 0;


        public string FullName => _currentUser?.FullName ?? "";
        public DateTime EntryDate => _currentUser.EntryDate;
    }
}

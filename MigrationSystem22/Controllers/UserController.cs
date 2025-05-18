using System;
using MigrationSystem22.Models;
using MigrationSystem22.Services;

namespace MigrationSystem22.Controllers
{
    public class UserController
    {
        private readonly UserService userService = new UserService();
        private readonly RoadMapService roadMapService = new RoadMapService();
        private User user;

        public void NewUser()
        {
            user = new User();
        }

        public bool LoadUser(int id, out string error)
        {
            try
            {
                user = userService.GetUserById(id)
                      ?? throw new Exception($"Пользователь {id} не найден");
                error = null;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

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
            user.EntryDate = entryDate;
            user.RegistrationDate = registrationDate;
            user.PatentIssueDate = patentIssueDate;
            user.FullName = fullName;
            user.Country = country;
            user.Qualification = qualification;
            user.IsInProgram = isInProgram;
            user.WasMigrant = wasMigrant;
            user.HasWorkPermit = hasWorkPermit;
            user.HasPatent = hasPatent;
            user.EntryGoal = entryGoal;

            try
            {
                if (user.Id == 0)
                    userService.SaveUser(user);
                else
                    userService.UpdateUser(user);

                error = null;
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\r\nInner: " + ex.InnerException.Message;
                error = msg;
                return false;
            }

        }

        public RoadMap ViewRoadMap()
        {
            return roadMapService.GenerateForUser(user);
        }

        public List<User> GetAllUsers()
    => userService.GetAllUsers();

        public string FullName => user.FullName;
        public DateTime EntryDate => user.EntryDate;
        public DateTime? RegistrationDate => user.RegistrationDate;
        public DateTime? PatentIssueDate => user.PatentIssueDate;
        public string Country => user.Country;
        public bool Qualification => user.Qualification;
        public bool IsInProgram => user.IsInProgram;
        public bool WasMigrant => user.WasMigrant;
        public bool HasWorkPermit => user.HasWorkPermit;
        public bool HasPatent => user.HasPatent;
        public string EntryGoal => user.EntryGoal;
    }
}

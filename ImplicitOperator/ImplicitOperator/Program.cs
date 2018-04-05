using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitOperator
{
    #region ViewModel
    public class RegisterViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public static implicit operator User(RegisterViewModel vm)
        {
            return new User
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password
            };
        }
    }
    #endregion

    #region Model
    public class User
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public string Email { get; set; }

        public static implicit operator RegisterViewModel(User user)
        {
            return new RegisterViewModel
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                UserName = user.UserName,
                Password = user.Password,
                ConfirmPassword = user.Password,
                Email = user.Email
            };
        }
    }
    #endregion

    #region Test Program
    class Program
    {
        static void Main(string[] args)
        {
            RegisterViewModel registerVM = new RegisterViewModel()
            {
                UserName = "zsyed",
                ConfirmPassword = "Password",
                Email = "Email@emal",
                FirstName = "FirstName",
                LastName = "LastName",
                Password = "password",
                UserID = 1
            };
            User user = new User();
            user = registerVM;
            registerVM = user;

        }
    }
    #endregion
}

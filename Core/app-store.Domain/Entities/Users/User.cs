using app_store.Domain.Entities.Users.ValueObjects;

namespace app_store.Domain.Entities.Users
{
    public class User
    {
        #region Ctors
        public User() {  }
        public User(
            string firstName,
            string lastName,
            string userName,
            string password,
            string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
        }
        #endregion

        #region Props
        public Guid Id { get; private init; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public UserName UserName { get; private set; }
        public Password Password { get; private set; }
        public string Email { get; private set; }
        #endregion

        #region Methods
        public void Update(
            string firstName,
            string lastName,
            string userName,
            string passWord,
            string email
         )
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = passWord;
            Email = email;
        }
        #endregion
    }
}


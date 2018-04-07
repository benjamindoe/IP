using System.Web;

namespace IP
{

    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public User()
        {
        }

        public static User GetCurrentUser()
        {
            var user = (User)HttpContext.Current.Session["User"];
            return user;
        }

        public static void SetCurrentUser(User user)
        {
            HttpContext.Current.Session["User"] = user;
        }
    }
}

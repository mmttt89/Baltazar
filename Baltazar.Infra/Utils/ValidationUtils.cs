using System;
namespace Baltazar.Infra.Utils
{
	public static class ValidationUtils
	{
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && username.Length >= 3;
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8;
        }
    }
}


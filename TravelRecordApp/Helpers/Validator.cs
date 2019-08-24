using System;
using System.Net.Mail;

namespace TravelRecordApp.Helpers
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

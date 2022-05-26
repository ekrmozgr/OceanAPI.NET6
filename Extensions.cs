using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;

namespace OceanAPI.NET6
{

    public static class Extensions
    {
        public static bool IsCurrentUser(int id, ClaimsPrincipal User)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return false;
            if (!userId.Equals(id.ToString()))
                return false;
            return true;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
        
        public static T GetValueFromName<T>(this string name) where T : Enum
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }

                if (field.Name == name)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }

        public static async Task Email(string subject, string body, string toMailAddress)
        {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ocean8741@gmail.com");
                message.To.Add(new MailAddress(toMailAddress));
                message.Subject = subject;
                message.IsBodyHtml = false; //to make message body as html  
                message.Body = body;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ocean8741@gmail.com", "ekrem123");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
        }
    }
}

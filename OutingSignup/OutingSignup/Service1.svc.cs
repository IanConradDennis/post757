using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace OutingSignup
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection("Data Source=coltsbaseball.cdh8w9afpvmi.us-east-2.rds.amazonaws.com;Initial Catalog=ColtsBaseball;User ID=sa;Password=drowssap");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegistrationTable" +
                "(CaptainName, CaptainEmail, Golfer2Name, Golfer2Email, Golfer3Name, Golfer3Email, Golfer4Name, Golfer4Email, CreateDateTime) " +
                "values(@captainName,@captainEmail,@golfer2Name,@golfer2Email,@golfer3Name,@golfer3Email,@golfer4Name,@golfer4Email,@createDateTime)", con);
            cmd.Parameters.AddWithValue("@captainName", userInfo.CaptainName);
            cmd.Parameters.AddWithValue("@captainEmail", userInfo.CaptainEmail);
            cmd.Parameters.AddWithValue("@golfer2Name", userInfo.Golfer2Name);
            cmd.Parameters.AddWithValue("@golfer2Email", userInfo.Golfer2Email);
            cmd.Parameters.AddWithValue("@golfer3Name", userInfo.Golfer3Name);
            cmd.Parameters.AddWithValue("@golfer3Email", userInfo.Golfer3Email);
            cmd.Parameters.AddWithValue("@golfer4Name", userInfo.Golfer4Name);
            cmd.Parameters.AddWithValue("@golfer4Email", userInfo.Golfer4Email);
            cmd.Parameters.AddWithValue("@createDateTime", DateTime.Now);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "pass";
                string message = sendit("dennisic@mail.uc.edu", userInfo.CaptainName, userInfo.Golfer2Name, userInfo.Golfer3Name, userInfo.Golfer4Name);
            }
            else
            {
                Message = "fail";
            }
            con.Close();
            return Message;
        }

        public string sendit(string ReciverMail, string captain, string golfer2, string golfer3, string golfer4)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("coltsbaseball44@gmail.com");
            msg.To.Add(ReciverMail);
            msg.Subject = "Stewart Woods Memorial Golf Outing Registration";
            msg.Body = "Thank you for registering for our outing at Jaycee Golf Course Chillicothe on July 30, 2017. \r\nCaptain: " + captain + " with " + golfer2 + ", " + golfer3 + ", and " + golfer4;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("coltsbaseball44@gmail.com", "a482d2567377208d1ccc3cbdcc725bcf");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Mail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
    //public string GetData(int value)
    //    {
    //        return string.Format("You entered: {0}", value);
    //    }

    //    public CompositeType GetDataUsingDataContract(CompositeType composite)
    //    {
    //        if (composite == null)
    //        {
    //            throw new ArgumentNullException("composite");
    //        }
    //        if (composite.BoolValue)
    //        {
    //            composite.StringValue += "Suffix";
    //        }
    //        return composite;
    //    }

}

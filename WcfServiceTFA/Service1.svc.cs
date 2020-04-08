using QRCoder;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using wcfservice;

namespace WcfServiceTFA
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=SSPI;AttachDbFileName =C:\\Users\\ASUS\\source\\repos\\test2factorAuth\\test2factorAuth\\twoFactor.mdf ");

        public string Hello()
        {
            return "hello";
        }
        public string inscription(string username, string lastname, string login, string pwd, string adresse, string email)
        {
            int verif;
            string PSK = TimeSensitivePassCode.GeneratePresharedKey();
            string data = "otpauth://totp/" + login + "?secret=" + PSK;

            QRCodeGenerator qrg = new QRCodeGenerator();
            QRCodeData qc = qrg.CreateQrCode(data, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qc);
            Bitmap bm = qrCode.GetGraphic(20);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Gif);
            Byte[] b = ms.ToArray();
            string bcd = Convert.ToBase64String(b);

            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Employe(Nom,Prenom,Adresse,Email,Psk,Login,Pwd) VALUES (@username,@lastname,@adresse,@email,@psk,@login,@pwd)";
            cmd.Parameters.AddWithValue("@username", username.Trim());
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@adresse", adresse);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@PSK", PSK);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Error", typeof(string));
            DataSet ds = new DataSet();
            dt.Columns.Add("SKey", typeof(string));
            dt.Columns.Add("SourceImage", typeof(string));

            try
            {
                verif = cmd.ExecuteNonQuery();
                dt.Rows.Add("true", PSK, bcd);
            }
            catch (Exception ex)
            {
                dt.Rows.Add("Probl�me" + ex.Message, "fff", "******");
            }
            ds.Tables.Add(dt);
            return bcd;
        }

        public string rechPSK(string login, string pwd)
        {
            string psk;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select psk from Employe where Login = '" + login + "' and Pwd ='" + pwd + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return psk = reader.GetString(0);
        }

        public bool ValidOTP(string login, string pwd, String token)
        {
            string psk = rechPSK(login, pwd);
            return OtpHelper.HasValidTotp(token, psk);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SessionManagement
{
    public class Module : IHttpModule
    {
        public static Dictionary<string, string> users = new Dictionary<string, string>();

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string URL = context.Request.Path;
            string username = context.Request.QueryString["u"];
            string password = context.Request.QueryString["p"];
            string user = string.Empty;
            string pass = string.Empty;

            if (!string.IsNullOrEmpty(username))
            {
                if (!users.ContainsKey(user))
                {

                    user = Encrypt(username);
                    pass = Encrypt(password);
                    users.Add(user, username);
                    users.Add(pass, password);
                }
                if (URL.Contains("SecondPage.aspx") && users.Count > 4) 
                { 
                    URL = "MembersMain.aspx"; 
                }
                context.RewritePath(URL, string.Empty, "u=" + user + "&p=" + pass, true);

                if (users.ContainsKey(username) && users.ContainsValue(username))
                {
                    context.RewritePath(URL, string.Empty, "u=" + users[username] + "&p=" + users[password], true);
                }
                else if (users.ContainsValue(username))
                {
                    context.Response.Redirect(context.Request.Url.ToString());
                }
            }
        }

        Random randomize = new Random();
        public const string characters = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string SaltGen(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = characters[randomize.Next(characters.Length)];
            }
            return new string(chars);
        }

        private string Encrypt(string plainText)
        {
            byte[] h = new SHA256CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(SaltGen(8) + plainText));

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < h.Length; i++)
            {
                output.Append(h[i].ToString("x2"));
            }
            return output.ToString();
        }
    }
}
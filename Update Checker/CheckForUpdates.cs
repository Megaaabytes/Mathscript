using System.IO;
using System.Net;
using System.Text;

namespace Math_Script_Runtime_Environment.Update_Checker
{
    // Crappy way of checking for updates

    public class CheckForUpdates
    {
        private static readonly string nextUpdateVersion = "Mathscript Interpreter 1.0.3";

        public static bool GetCurrentVersion()
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/megaaabytes/Mathscript/releases");
            Request.Method = "GET";
            Request.KeepAlive = true;
            Request.UserAgent = "Guest";
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

            if (Response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string responseString = reader.ReadToEnd();
                    return GetTimePublished(responseString);
                }
            }
            else if(Response.StatusCode == HttpStatusCode.Forbidden)
            {
                using (Stream stream = Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string responseString = reader.ReadToEnd();
                    Program.errorMessage = responseString;
                    Program.tooManyRequests = true;
                    return false;
                }
            }
            return false;
        }

        private static bool GetTimePublished(string response)
        {
            string[] responseSplit = response.Split(',');
            foreach (string line in responseSplit)
            {
                if (line.Contains(nextUpdateVersion))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

public static class ErrorLog
{
    public static void WriteLog(string message)
    {
        try
        {
            //Logfile
            string strDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            string logDocument = "Log " + strDate; //.Replace("-", "");
            string filePath2 = AppDomain.CurrentDomain.BaseDirectory;
            //filePath2 = filePath2.Replace("\", "\\");
            string filePath = Path.Combine(filePath2, "Logs") + "\\" + logDocument + ".txt";
            string path = filePath;
            StreamWriter sw;
            if (!File.Exists(path))
            { sw = File.CreateText(path); }
            else
            { sw = File.AppendText(path); }

            sw.WriteLine("{0}", DateTime.Now.ToString() + "    " + message);
            sw.WriteLine("----------------------------------------");

            sw.Flush();
            sw.Close();
        }
        catch (Exception ex)
        {
        }
    }
}


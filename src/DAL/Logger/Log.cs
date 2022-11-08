namespace DAL.Logger
{
    public class Log
    {
        public async Task Create(string errorMessage, string model)
        {
            try
            {
                string _path = $@"c:\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}_{model}.log";

                if (!File.Exists(_path))
                {
                    using (StreamWriter sw = File.CreateText(_path))
                    {
                        await sw.WriteLineAsync(errorMessage);
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = new(_path, true))
                    {
                        streamWriter.WriteLine(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

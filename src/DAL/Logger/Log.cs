namespace DAL.Logger
{
    public class Log
    {
        public async Task Create(string errorMessage, string model)
        {
            try
            {
                string _path = $@"c:\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}_{model}.log";

                using (StreamWriter streamWriter = new(_path, true))
                {
                    await streamWriter.WriteLineAsync($"{DateTime.Now} {errorMessage}");

                    await streamWriter.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

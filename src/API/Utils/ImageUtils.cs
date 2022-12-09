namespace API.Utils
{
    public class ImageUtils
    {
        public async Task CopyImageToFolder(IFormFile file)
        {
            try
            {
                byte[] bytes;                

                if (file is not null)
                {
                    string path = @$"C:\Users\cleit\Desktop\PetUI_Maui\src\UI\wwwroot\imagens\{file.FileName}";

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        bytes = memoryStream.ToArray();

                        await memoryStream.FlushAsync();
                    }

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await fileStream.WriteAsync(bytes, 0, bytes.Length);
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

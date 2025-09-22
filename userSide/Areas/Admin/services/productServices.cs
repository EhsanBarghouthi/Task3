using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Cryptography;
using userSide.Models;

namespace userSide.Areas.Admin.services
{
    public class productServices
    {
        [Area("Admin")]
        public string uploadImage(IFormFile imageFile)
        {
            string imagePath = null;
            string fileName = null;

            if (imageFile != null && imageFile.Length > 0)
            {

                // Create a unique name for the file
                 fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                // Path to save inside wwwroot/images
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");

                // Create folder if it doesn't exist
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                // Full path to save the image
                string filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            return fileName;
        }

        public Boolean deleteImage(string fileName)
        {
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
            var filePath = Path.Combine(imagesPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true; 
            }
            return false;
        }
    }

    
}

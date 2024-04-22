using DemoBlazorPhotoReviewUpload.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace DemoBlazorPhotoReviewUpload.Services
{
    public class UploadPhotoData : IUploadPhotoData
    {
        private readonly IWebHostEnvironment _env;
        public UploadPhotoData(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task UploadFile(List<IBrowserFile> files)
        {
            foreach (var file in files)
            {


                string fileName_new = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(file.Name);
                var fname = fileName_new + extension;


                var path = Path.Combine(_env.ContentRootPath, "Images", fname);

                var subpath = Path.Combine(_env.ContentRootPath, "Images");
                System.IO.Directory.CreateDirectory(subpath);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream().CopyToAsync(fs);

            }
        }
    }
}

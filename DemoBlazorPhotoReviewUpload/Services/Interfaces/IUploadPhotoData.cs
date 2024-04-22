using Microsoft.AspNetCore.Components.Forms;

namespace DemoBlazorPhotoReviewUpload.Services.Interfaces
{
    public interface IUploadPhotoData
    {
        public Task UploadFile(List<IBrowserFile> files);

    }
}

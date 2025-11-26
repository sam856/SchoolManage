using Microsoft.AspNetCore.Http;

namespace SchoolManagment.Services.Abstract
{
    public interface IFileServices
    {
        public Task<string> UploadFile(string Location, IFormFile image);

    }
}

using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        void RemoveOldFile(string directory);
        void CreateFile(string directory, IFormFile file);
        void CheckDirectoryExist(string directory);
        IResult CheckFileTypeValid(string type);
        IResult CheckFileExist(IFormFile file);
        IResult Upload(IFormFile file);
        IResult Update(IFormFile file, string imagePath);
        IResult Remove(string path);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;
/* 업로드한 파일을 수취하고, Chunk 단위로 전송된 파일을 재조립하여 저장하는 서버 측 코드입니다. 
 * 서버에서 해당 코드가 실행중이어야만 Post Request를 수취할 수 있습니다. */
namespace FileTransferService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadChunk()
        {
            var file = Request.Form.Files[0];

            /* 업로드된 파일이 존재하지 않는다면 BadRequest를 return합니다. */
            if (file == null || file.Length == 0)
            {
                return BadRequest("No File Uploaded");
            }

            /* Directory 클래스를 사용하여 바탕화면에 uploads라는 폴더를 생성합니다.
             * 해당 위치에 파일을 저장합니다. 
             * 이하 기타 파일 경로 및 파일명 설정 파트*/
            var desktopPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "uploads");
            Directory.CreateDirectory(desktopPath);
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(desktopPath, fileName);

            /* 파일에 데이터를 쓰기 위해 FileStream을 사용합니다.
             * 이후, 업로드 파일 데이터를 해당 경로 파일에 씁니다. */
            using (var stream = new FileStream(filePath, FileMode.Append))
            {
                await file.CopyToAsync(stream);
            }
            /* 성공적으로 전송이 완료되었을 경우, OK 사인을 return합니다. */
            return Ok("File chunk uploaded successfully");
        }
    }
}
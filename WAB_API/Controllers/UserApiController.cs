using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAB_API.Models;

namespace WAB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly KrufitnesContext db;
        private readonly IWebHostEnvironment _environment;

        public UserApiController(KrufitnesContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableUser>>> GetPeople()
        {
            var data = await db.TableUser.ToListAsync();          
    
            return data;
        }

        [HttpPost]
        public async Task<ActionResult<TableUser>> PostUser([FromForm] TableUser user, [FromForm] IFormFile files)
        {
            #region ImageManageMent

            var directory = "\\uploads\\";
            var path = _environment.WebRootPath + directory;
            if (files?.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                    //ตัดเอาเฉพาะชื่อไฟล์
                    var fileName = "";
                    if (files.FileName != null)
                    {
                        fileName = files.FileName?.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                    }


                    using (FileStream filestream =
                        System.IO.File.Create(path + fileName))
                    {
                        files.CopyTo(filestream);
                        filestream.Flush();

                        user.UserPic = directory + fileName;
                    }
                }
                catch (Exception ex)
                {
                    return CreatedAtAction(nameof(PostUser), ex.ToString());
                }
            }

            #endregion

            try
            {
                db.TableUser.Add(user);

                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Conflict();
            }

            return CreatedAtAction(nameof(PostUser), user);
        }






    }


}
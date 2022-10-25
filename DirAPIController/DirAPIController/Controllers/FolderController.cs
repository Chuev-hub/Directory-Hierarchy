using Dir.BLL.DTO;
using Dir.BLL.Services;
using Dir.DAL.Context;
using Dir.DAL.Repositories;
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DirAPIController.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FolderController : Controller
    {
        private readonly IService<FolderDTO,Folder> folderService;
        public FolderController(IService<FolderDTO, Folder> service)
        {
            folderService = service;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await folderService.GetAll());
        }
        async Task<string> GetPath(FolderDTO f)
        {
            if (f == null)
                return "";
            if (f.ParentId == null)
                return ":/" + f.Name;
            else
                return await GetPath(await folderService.Get(Convert.ToInt32(f.ParentId))) + "/" + f.Name;
        }
        [HttpGet]

        public async Task<IActionResult> GetById(int id)
        {
            FolderDTO f = await folderService.Get(id);
            return Json(new { obj = f,
                path = await GetPath(f)
            });
        }
        [HttpGet]

        public async Task<IActionResult> GetChildren(int id)
        {
            var list = await folderService.GetAll();
           
            return Json(new
            {
                list = list.Where(x => x.ParentId == id),
                path = await GetPath(await folderService.Get(id))
            });
        }
        [HttpPut]
        public async Task<IActionResult> SetHierarchy([FromBody] List<FolderDTO> list)
        {
            await folderService.RemoveAsync();
            await folderService.AddRangeAsync(list);
            return Ok();
        }
    }
}
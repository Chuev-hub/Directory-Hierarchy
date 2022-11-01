using AutoMapper;
using Dir.BLL.DTO;
using Dir.BLL.Services;
using Dir.DAL.Context;
using Dir.DAL.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DirAPIController.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [EnableCors("AllowOrigin")]
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
            return Json(new
            {
                obj = f,
                path = await GetPath(f)
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetByPath(string path)
        {
            if (path[path.Count() - 1] == '/')
                path = path.Remove(path.Count() - 1);
            List<string> list =  new List<string>(path.Split("/"));
            var root =  (await folderService.GetAll()).FirstOrDefault(x => x.ParentId == null);
            if (root?.Name == list[0])
            {
                FolderDTO f = null;
                if (list.Count == 1)
                {
                    return Json(new
                    {
                        obj = root,
                        path = await GetPath(root)
                    });
                   
                }
                for (int i = 1; i < list.Count; i++)
                {
                    f = (await folderService.GetAll())
                        .FirstOrDefault(x => x.ParentId == root.Id && 
                                             x.Name == list[i]);
                    if(f == null)
                       return BadRequest(StatusCodes.Status406NotAcceptable);
                    root = f;
                }

                return Json(new
                {
                    obj = f,
                    path = await GetPath(f)
                });
            }
            else
                return BadRequest(StatusCodes.Status406NotAcceptable);

        }
        [HttpGet]
        public async Task<IActionResult> GetChildrenByPath(string path)
        {
            if (path[path.Count() - 1] == '/')
                path = path.Remove(path.Count() - 1);
            List<string> list = new List<string>(path.Split("/"));
            var root = (await folderService.GetAll()).FirstOrDefault(x => x.ParentId == null);
            if (root?.Name == list[0])
            {
                FolderDTO f = null;
                if (list.Count == 1)
                {
                    return Json(new
                    {
                        list = (await folderService.GetAll()).Where(x => x.ParentId == root.Id),
                        path = await GetPath(root)
                    });
                }
                for (int i = 1; i < list.Count; i++)
                {
                    f = (await folderService.GetAll())
                        .FirstOrDefault(x => x.ParentId == root.Id &&
                                             x.Name == list[i]);
                    if (f == null)
                        return BadRequest(StatusCodes.Status406NotAcceptable);
                    root = f;
                }
                
                return Json(new
                {
                    list = (await folderService.GetAll()).Where(x => x.ParentId == f.Id),
                    path = await GetPath(f)
                });
            }
            else
                return BadRequest(StatusCodes.Status406NotAcceptable);

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
        [HttpGet]
        public async Task<IActionResult> GetRoot()
        {
            var list = await folderService.GetAll();
            return Json(list.FirstOrDefault(x => x.ParentId == null));
        }
        [HttpPut]
        public async Task<IActionResult> SetHierarchy([FromBody] List<FolderDTO> list)
        {
            if (list.FirstOrDefault(x => x.ParentId == null) != null)
            {
                await folderService.RemoveAsync();
                await folderService.AddRangeAsync(list);
                return Ok();
            }
            else
            {
                return BadRequest(StatusCodes.Status406NotAcceptable);
            }

     
        }
    }
}
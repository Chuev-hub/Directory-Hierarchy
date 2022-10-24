using Dir.BLL.DTO;
using Dir.BLL.Services;
using Dir.DAL.Context;
using Dir.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DirAPIController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController : ControllerBase
    {
        private readonly IService<FolderDTO,Folder> folderService;
        public FolderController(IService<FolderDTO, Folder> service)
        {
            folderService = service;
            
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<FolderDTO>> Get()
        {
            return await folderService.GetAll();
        }
       
    }
}
using Dir.BLL.DTO;
using Dir.DAL.Context;
using Dir.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir.BLL.Services
{
    public class FolderService : GenericService<FolderDTO, Folder>
    {
        public FolderService(DirectoryContext context)
        {
            Repository = new FolderRepository(context);
        }
       
    }
}

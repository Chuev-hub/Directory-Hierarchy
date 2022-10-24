using Dir.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dir.DAL.Repositories
{
    public class FolderRepository : GenericRepository<Folder>
    {
        public FolderRepository(DirectoryContext context) : base(context)
        {

        }
        public virtual IEnumerable<Folder> GetAll()
        {
            return table.AsNoTracking().ToList();
        }
    }
}

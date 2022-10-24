using Dir.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir.BLL.DTO
{
    public class FolderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}

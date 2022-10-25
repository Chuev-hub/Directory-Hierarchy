using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dir.DAL.Context
{
    public class Folder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Folder Parent { get; set; }

        public int? ParentId { get; set; }
        
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual ICollection<Folder> Children { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seleznev2702Test
{
    public class Role
    {
        [Index]
        public int Id { get; set; }
        [Key]
        public string NameRole { get; set; }
        public string Description { get; set; }
    }
}

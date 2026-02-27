using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seleznev2702Test
{
    internal class User
    {
        [Index]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Patronymic { get; set; }
        public int Age { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Login { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Position")]
        [Required]
        public string PositionName { get; set; }
        [ForeignKey("Role")]
        [Required]
        public string RoleName { get; set; }
        public Role Role { get; set; }
        public Position Position { get; set; }

    }
}

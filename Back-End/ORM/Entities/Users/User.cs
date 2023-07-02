using Dietbox.ECommerce.ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.ORM.Entities.Users
{
    public class User : IIdentity, ICreatedDate
    {
        /// <summary>
        /// Identificador do usuário.
        /// </summary>
        [Key]
        [Required]
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        [Required]
        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        [Required]
        [Column("Email")]
        [MaxLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Senha de acesso do usuário.
        /// </summary>
        [Required]
        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; }


        /// <summary>
        /// Data/Hora de cadastro do usuário no sistema.
        /// </summary>
        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}

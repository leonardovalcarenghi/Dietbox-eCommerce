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

    [Table("Customers", Schema = "dbo")]
    public class Customer : IIdentity, ICreatedDate
    {
        /// <summary>
        /// Identificador do cliente.
        /// </summary>
        [Key]
        [Required]
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Nome completo do cliente.
        /// </summary>
        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Data de nascimento do cliente.
        /// </summary>
        [Required]
        [Column("Birthdate")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// CPF do cliente.
        /// </summary>
        [Required]
        [Column("CPF")]
        [MaxLength(14)]
        public string CPF { get; set; }


        /// <summary>
        /// E-mail do cliente.
        /// </summary>
        [Required]
        [Column("Email")]
        [MaxLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Senha de acesso do cliente.
        /// </summary>
        [Required]
        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// Flag indicando se cliente está com cadastro ativo.
        /// </summary>
        [Required]
        [Column("Active")]
        public bool Active { get; set; }

        /// <summary>
        /// Data/Hora de cadastro do usuário no sistema.
        /// </summary>
        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}

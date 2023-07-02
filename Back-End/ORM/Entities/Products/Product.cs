using Dietbox.ECommerce.ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.ORM.Entities.Products
{
    public class Product : IIdentity, ICreatedDate
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        [Key]
        [Required]
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Identificador da empresa que o produto está vinculado.
        /// </summary>
        [Required]
        [Column("CompanyID")]
        public int CompanyID { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        [Required]
        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        [Column("Description")]
        [MaxLength(200)]
        public string? Description { get; set; }

        /// <summary>
        /// Código de barras do produto.
        /// </summary>
        [Required]
        [Column("BarCode")]
        [MaxLength(10)]
        public string BarCode { get; set; }

        /// <summary>
        /// Código interno do produto.
        /// </summary>
        [Column("InternCode")]
        [MaxLength(50)]
        public string? InternCode { get; set; }

        /// <summary>
        /// Preço de venda do produto.
        /// </summary>
        [Required]
        [Column("Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Data/Hora de cadastro do produto no sistema.
        /// </summary>
        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

    }
}

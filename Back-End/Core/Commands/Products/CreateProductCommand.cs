using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Commands.Products
{
    public class CreateProductCommand : Command
    {

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do produto (opcional).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Código de barras do produto.
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Código interno do produto (opcional).
        /// </summary>
        public string? InternCode { get; set; }

        /// <summary>
        /// Preço de venda do produto.
        /// </summary>
        public decimal Price { get; set; }

    }
}

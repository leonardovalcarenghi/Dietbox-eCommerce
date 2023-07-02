using Dietbox.ECommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Exceptions
{
    public class InvalidParameterException : Exception, IApplicationException
    {

        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string[] Messages { get; }

        public string? Title { get; }

        /// <summary>
        /// Excessão de parâmetro inválido, retorna um HttpStatusCode 400.
        /// </summary>
        /// <param name="messages">Mensagens.</param>
        /// <param name="title">Título</param>
        public InvalidParameterException(string[] messages, string? title = null)
        {
            Messages = messages;
            Title = title;
        }

        /// <summary>
        /// Excessão de parâmetro inválido, retorna um HttpStatusCode 400.
        /// </summary>
        /// <param name="messages">Array de mensagens.</param>
        /// <param name="title">Título.</param>
        public InvalidParameterException(string message, string? title = null)
        {
            Messages = new string[] { message };
            Title = title;
        }

    }
}

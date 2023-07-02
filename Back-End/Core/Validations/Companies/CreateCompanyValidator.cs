using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Services;
using Dietbox.ECommerce.ORM.Entities.Companies;
using Dietbox.ECommerce.ORM.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Validations.Companies
{
    public class CreateCompanyValidator : IValidator<CreateCompanyCommand>
    {

        private readonly IRepository<Company> _repository;
        private readonly List<string> _messages;

        private const int _NAME_MAX_LENGTH = 100;
        private const int _EMAIL_MAX_LENGTH = 80;
        private const int _PASSWORD_MIN_LENGTH = 4;
        private const int _PASSWORD_MAX_LENGTH = 30;

        public CreateCompanyValidator(IRepository<Company> repository)
        {
            _repository = repository;
            _messages = new();
        }

        public async Task<(bool isValid, List<string> messages)> Validate(CreateCompanyCommand command)
        {
            if (command is null)
                return (false, new() { "Parâmetro inválido." });


            #region Google Recaptcha

            if (string.IsNullOrEmpty(command.Recaptcha))
                return (false, new() { "Recaptcha não validado." });

            //bool recapchaIsValid = _googleRecaptcha.Validate(command.RecaptchaToken);
            //if (recapchaIsValid)
            //    return (false, new() { "Recaptcha inválido." });

            #endregion



            #region Nome da Empresa

            if (string.IsNullOrEmpty(command.Name))
            {
                _messages.Add("O campo 'Nome da empresa' é obrigatório.");
            }
            else
            {
                command.Name = command.Name.Trim();

                if (command.Name.Length > _NAME_MAX_LENGTH)
                    _messages.Add(string.Format("o campo 'Nome da empresa' não pode exceder o limite de {0} caracteres.", _NAME_MAX_LENGTH));

                if (command.Name.All(char.IsDigit))
                    _messages.Add("O campo 'Nome da empresa' não pode conter somente números.");
            }

            #endregion



            #region CNPJ

            if (string.IsNullOrEmpty(command.CNPJ))
            {
                _messages.Add("O campo 'CNPJ' é obrigatório.");
            }
            else
            {
                command.CNPJ = command.CNPJ.Trim();
                command.CNPJ = command.CNPJ.Replace(" ", "");

                if (command.CNPJ.Length is not 14)
                    throw new Exception("O campo 'CNPJ' não contém 14 caracteres.");

                if (!command.CNPJ.All(char.IsDigit))
                    throw new Exception("O campo 'CNPJ' está inválido.");

            }

            #endregion



            #region E-mail da Empresa

            if (string.IsNullOrEmpty(command.Email))
            {
                _messages.Add("O campo 'E-mail da empresa' é obrigatório.");
            }
            else
            {
                command.Email = command.Email.Trim();

                if (command.Email.Length > _EMAIL_MAX_LENGTH)
                    _messages.Add(string.Format("o campo 'E-mail da empresa' não pode exceder o limite de {0} caracteres.", _EMAIL_MAX_LENGTH));

                if (command.Email.All(char.IsDigit))
                    _messages.Add("O campo 'E-mail da empresa' não pode conter somente números.");

                bool isValidEmail = MailAddress.TryCreate(command.Email, out var _);
                if (isValidEmail is false)
                    _messages.Add("O 'E-mail da empresa' informado é inválido.");

            }

            #endregion


            #region Senha

            if (string.IsNullOrEmpty(command.Password))
            {
                _messages.Add("O campo 'Senha' é obrigatório.");
            }
            else
            {

                if (command.Password.Length < _PASSWORD_MIN_LENGTH)
                    _messages.Add(string.Format("o campo 'Senha' precisa conter pelo menos {0} caracteres.", _PASSWORD_MIN_LENGTH));

                if (command.Password.Length > _PASSWORD_MAX_LENGTH)
                    _messages.Add(string.Format("o campo 'Senha' não pode exceder o limite de {0} caracteres.", _PASSWORD_MAX_LENGTH));
            }

            #endregion



            // Retornar caso houver problemas na validação dos campos do comando:
            if (_messages.Any()) return (false, _messages);

            // Validar se CNPJ está cadastrado:
            bool existsCNPJ = await _repository.Get(_ => _.CNPJ == command.CNPJ).AnyAsync();
            if (existsCNPJ)
                return (false, new() { "O CNPJ informado já possui cadastro no sistema." });

            return (true, new());
        }
    }
}

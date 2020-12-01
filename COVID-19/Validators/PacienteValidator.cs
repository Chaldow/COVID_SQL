using COVID_19.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente> {
        public PacienteValidator() {
            RuleFor(p => p.nome)
                .NotEmpty().WithMessage("Nome obrigatório")
                .NotNull().WithMessage("Nome obrigatório")
                .MinimumLength(3).WithMessage("Nome no minimo de 3 caracteres")
                .MaximumLength(100).WithMessage("Nome no maximo com 100 caracteres");

			RuleFor(p => p.cpf)
				.NotEmpty().WithMessage("CPF obrigatório")
				.NotNull().WithMessage("CPF obrigatório")
				.Must(IsCpf).WithMessage("CPF NÃO VÁLIDO")
				.Equal(p => p.cpf).WithMessage("CPF JÀ EXISTE");
			RuleFor(p => p.idade)
				.LessThanOrEqualTo(120).WithMessage("Idade maior que 120 anos")
			.GreaterThanOrEqualTo(1).WithMessage("Não é possivel cadastrar idade negativa")
			;
				
		}

		public bool IsCpf(string cpf)
			{
				int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				string tempCpf;
				string digito;
				int soma;
				int resto;
				cpf = cpf.Trim();
				cpf = cpf.Replace(".", "").Replace("-", "");
				if (cpf.Length != 11)
					return false;
				tempCpf = cpf.Substring(0, 9);
				soma = 0;

				for (int i = 0; i < 9; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;
				digito = resto.ToString();
				tempCpf = tempCpf + digito;
				soma = 0;
				for (int i = 0; i < 10; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;
				digito = digito + resto.ToString();
				return cpf.EndsWith(digito);
			}
		


	}
}

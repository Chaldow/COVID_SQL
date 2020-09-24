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
                .MaximumLength(50).WithMessage("Nome no maximo com 50 caracteres");
        }
    }
}

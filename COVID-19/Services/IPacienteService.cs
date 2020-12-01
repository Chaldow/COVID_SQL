using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Services
{
    public interface IPacienteService
    {
        public Paciente buscaPorId(int id);
        public IList<Paciente> buscaPorCidade(string cidade);
        public IList<Paciente> buscaPorCPF(string cpf);
        public IList<Paciente> buscaTodosPacientes();

        public int inserir(Paciente paciente);
        public void atualizar(int id);
        public void remover(int id );
    }
}

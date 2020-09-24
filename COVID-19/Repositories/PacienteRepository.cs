using COVID_19.Models;
using COVID_19.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private IList<Paciente> listaPaciente = new List<Paciente>();
        public PacienteRepository()
        {
            listaPaciente.Add(new Paciente() { id = 1, cidade = "Nunes" });
            listaPaciente.Add(new Paciente() { id = 2, cidade = "Humberto" });
            listaPaciente.Add(new Paciente() { id = 3, cidade = "Robinson" });
            listaPaciente.Add(new Paciente() { id = 4, cidade = "Renato" });
        }
        public Paciente BuscarPacientePorId(int pid)
        {
            return listaPaciente.Where(x => x.id == pid).FirstOrDefault();
        }

        public void InserirPaciente(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
                listaPaciente.Add(paciente);
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }

        public IList<Paciente> ListarTodosPacientes()
        {
            return listaPaciente;
        }
    }
}

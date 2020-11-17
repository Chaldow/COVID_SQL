using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Models
{
    public class Paciente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string cidade  { get; set; }
        public string estado  { get; set; }
        public string sexo  { get; set; }
        public string estado_civil  { get; set; }
        public int comorbidade { get; set; }
        public DateTime data_registro { get; set; }
    }
}

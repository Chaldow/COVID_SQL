using COVID_19.Context;
using COVID_19.Models;
using COVID_19.Repositories;
using COVID_19.Services;
using NUnit.Framework;
using System;

namespace COVID19.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*[Test]
        public void Test1()
        {
            Assert.Pass();
            Paciente paciente = new Paciente();
            { paciente.id = 1;
                paciente.nome = "Nunes";
                paciente.cpf = "115.615.611-25";
                paciente.sexo = "masculino";
                paciente.cidade = "Osasco";
                paciente.estado = "SP";
                paciente.estado_civil = "casado";
                paciente.comorbidade = false;
                paciente.data_registro = DateTime.Now;

            } 
            PacienteService _service = new PacienteService();
            var ex = Assert.Throws<Exception>(() => _service.inserir(paciente));
            Assert.That(ex.Message, Is.EqualTo("Cpf é invalido"));
        }*/
        [Test]
        public void InserirNovoPaciente()
        {
            Paciente novoPaciente = new Paciente();
            novoPaciente.nome = "Nunes";
            COVID_Context context = new COVID_Context();
            PacienteRepository pacienteRepository = new PacienteRepository(context);
            PacienteService _service = new PacienteService(pacienteRepository);
            int retorno = _service.inserir(novoPaciente);
            Assert.Greater(retorno, 0);
        }
        [Test]
        public void TestePacienteCPF()
        {
            Paciente novoPaciente = new Paciente();
            novoPaciente.cpf = "113227126900";
            COVID_Context context = new COVID_Context();
            PacienteRepository pacienteRepository = new PacienteRepository(context);
            PacienteService _service = new PacienteService(pacienteRepository);
            var ex = Assert.Throws<Exception>(() => _service.inserir(novoPaciente));
            Assert.That(ex.Message, Is.EqualTo("Já existente"));
        }

        [Test]
        public void TesteNomeVazio()
        {
            Paciente novoPaciente = new Paciente();
            novoPaciente.nome = "";
            COVID_Context context = new COVID_Context();
            PacienteRepository pacienteRepository = new PacienteRepository(context);
            PacienteService _service = new PacienteService(pacienteRepository);
            var ex = Assert.Throws<Exception>(() => _service.inserir(novoPaciente));
            Assert.That(ex.Message, Is.EqualTo("Nome Obrigatório"));
        }

        [Test]
        public void TesteIdadeNegativa()
        {
            Paciente novoPaciente = new Paciente();
            novoPaciente.idade = -12;
            COVID_Context context = new COVID_Context();
            PacienteRepository pacienteRepository = new PacienteRepository(context);
            PacienteService _service = new PacienteService(pacienteRepository);
            var ex = Assert.Throws<Exception>(() => _service.inserir(novoPaciente));
            Assert.That(ex.Message, Is.EqualTo("Idade não válida"));
        }

        [Test]
        public void TesteIdadeMaxima()
        {
            Paciente novoPaciente = new Paciente();
            novoPaciente.idade = 130;
            COVID_Context context = new COVID_Context();
            PacienteRepository pacienteRepository = new PacienteRepository(context);
            PacienteService _service = new PacienteService(pacienteRepository);
            var ex = Assert.Throws<Exception>(() => _service.inserir(novoPaciente));
            Assert.That(ex.Message, Is.EqualTo("Idade acima do limite"));
        }

    }
}   
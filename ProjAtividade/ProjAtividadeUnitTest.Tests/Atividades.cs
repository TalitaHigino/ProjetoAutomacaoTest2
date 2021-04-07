using Microsoft.EntityFrameworkCore;
using ProjAtividadelUnitTest.Api.Controllers;
using ProjAtividadelUnitTest.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjAtividadeUnitTest.Tests
{
    public class Atividades
    {
        private DbContextOptions<AtividadeContext>options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AtividadeContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid()
            .ToString()).Options;

            using (var context = new AtividadeContext(options))
            {
                    context.Atividade.Add(new Atividade { Id = 1, Descricao= "Name 1", DataInicio= DateTime.Now, DataFinal= DateTime.Now });
                    context.Atividade.Add(new Atividade { Id = 2, Descricao= "Name 2", DataInicio= DateTime.Now, DataFinal = DateTime.Now });
                    context.Atividade.Add(new Atividade { Id = 3, Descricao= "Name 3", DataInicio= DateTime.Now, DataFinal = DateTime.Now });
                
                    context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AtividadeContext(options))
            {
                AtividadeController atividadeController = new AtividadeController(context);
                IEnumerable<Atividade> atividades = atividadeController.GetAtividade().Result.Value;
    
                Assert.Equal(3, atividades.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AtividadeContext(options))
            {
                int atividadeId = 2;
                AtividadeController atividadeController = new AtividadeController(context);
                Atividade atividade = atividadeController.GetAtividade(atividadeId).Result.Value;
                Assert.Equal(2, atividade.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

             Atividade atividade = new Atividade()
            {
                Id = 4,
                Descricao= "Bolacha",
                 DataInicio= DateTime.Now,
                DataFinal= DateTime.Now
               

            };

            // Use a clean instance of the context to run the test
            using (var context = new AtividadeContext(options))
            {
                AtividadeController atividadeController = new AtividadeController(context);
                Atividade ativ = atividadeController.PostAtividade(atividade).Result.Value;
                Assert.Equal(4, ativ.Id);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Atividade atividade = new Atividade()
            {
                 Id = 3,
                Descricao= "Bolacha",
                DataInicio= DateTime.Now,
                DataFinal= DateTime.Now
               
            };

            // Use a clean instance of the context to run the test
            using (var context = new AtividadeContext(options))
            {
                AtividadeController atividadeController = new AtividadeController(context);
                Atividade ativ = atividadeController.PutAtividade(3, atividade).Result.Value;
                Assert.Equal("Bolacha", ativ.Descricao);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AtividadeContext(options))
            {
                AtividadeController atividadeController = new AtividadeController(context);
                 Atividade atividade = atividadeController.DeleteAtividade(2).Result.Value;
                Assert.Null(atividade );
            }
        }
    }    
}
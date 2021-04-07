using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAtividadelUnitTest.Api.Models;

    public class AtividadeContext : DbContext
    {
        public AtividadeContext (DbContextOptions<AtividadeContext> options)
            : base(options)
        {
        }

        public DbSet<ProjAtividadelUnitTest.Api.Models.Atividade> Atividade { get; set; }
    }

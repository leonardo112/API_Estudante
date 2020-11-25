using API_Estudante.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Estudante.Context
{
    public class EstudanteContext : DbContext
    {
        public EstudanteContext(DbContextOptions<EstudanteContext> options)
            : base(options)
        {

        }

        public DbSet<Estudante> estudantes { get; set; }
    }
}

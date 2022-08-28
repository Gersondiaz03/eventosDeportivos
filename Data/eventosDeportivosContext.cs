using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcColegioArbitral.Models;
using MvcMunicipio.Models;
using MvcPatrocinador.Models;
using MvcTorneo.Models;
using MvcEscenario.Models;
using MvcCancha.Models;
using MvcEquipo.Models;
using MvcDeportista.Models;

    public class eventosDeportivosContext : DbContext
    {
        public eventosDeportivosContext (DbContextOptions<eventosDeportivosContext> options)
            : base(options)
        {
        }

        public DbSet<MvcColegioArbitral.Models.colegioArbitral> colegioArbitral { get; set; } = default!;

        public DbSet<MvcMunicipio.Models.Municipio> Municipio { get; set; }

        public DbSet<MvcPatrocinador.Models.Patrocinador> Patrocinador { get; set; }

        public DbSet<MvcTorneo.Models.Torneo> Torneo { get; set; }

        public DbSet<MvcEscenario.Models.Escenario> Escenario { get; set; }

        public DbSet<MvcCancha.Models.Cancha> Cancha { get; set; }

        public DbSet<MvcEquipo.Models.Equipo> Equipo { get; set; }

        public DbSet<MvcDeportista.Models.Deportista> Deportista { get; set; }
    }

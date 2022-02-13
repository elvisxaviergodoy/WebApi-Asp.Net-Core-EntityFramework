//modelo
using apiFutbolistas.Models;
//libreria para trabajar con entityFramework
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFutbolistas.Context
{
    //                          :heredamos de DbContext
    public class AppDbContext : DbContext
    {
        //constructor                   del tipo AppDbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //representación de la tabla
        //    del mismo tipo del modelo, futbolista es y tiene que ser del nombre de la tabla
        public DbSet<Futbolista> futbolistas { get; set; }//importar el modelo de Futbolista
    }
}

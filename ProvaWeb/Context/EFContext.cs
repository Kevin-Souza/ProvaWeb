using ProvaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProvaWeb.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("PROVA") { }
        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<Produto> produtos { get; set; }
    }
}
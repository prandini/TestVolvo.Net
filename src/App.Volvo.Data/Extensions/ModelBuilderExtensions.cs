using App.Volvo.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace microblogAPI.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static Guid _guidIdDefaultModelo = Guid.NewGuid();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelo>().HasData(
                new Modelo
                {
                    Id = _guidIdDefaultModelo,
                    Nome = "FH",
                    IsPermitidoCadastro = true
                },
                new Modelo
                {
                    Id = Guid.NewGuid(),
                    Nome = "FM",
                    IsPermitidoCadastro = true
                },
                new Modelo
                {
                    Id = Guid.NewGuid(),
                    Nome = "FMX",
                    IsPermitidoCadastro = false
                },
                new Modelo
                {
                    Id = Guid.NewGuid(),
                    Nome = "FHX",
                    IsPermitidoCadastro = false
                });

            modelBuilder.Entity<Caminhao>().HasData(
                new Caminhao
                {
                    Id = Guid.NewGuid(),
                    AnoFabricacao = 2021,
                    AnoModelo = 2021,
                    Chassi = "398A4ch95b9PX8897",
                    ModeloId = _guidIdDefaultModelo
                }
            );

        }
        
    }
}

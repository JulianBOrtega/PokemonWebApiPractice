﻿using Microsoft.EntityFrameworkCore;
using PokemonWebApiPractice.Models;

namespace PokemonWebApiPractice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pokemonCategory => new { pokemonCategory.PokemonId, pokemonCategory.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pokemon => pokemon.Pokemon)
                .WithMany(pokemonCategory => pokemonCategory.PokemonCategories)
                .HasForeignKey(pokemon => pokemon.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pokemon => pokemon.Category)
                .WithMany(pokemonCategory => pokemonCategory.PokemonCategories)
                .HasForeignKey(category => category.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(pokemonOwner => new { pokemonOwner.PokemonId, pokemonOwner.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(pokemon => pokemon.Pokemon)
                .WithMany(pokemonOwner => pokemonOwner.PokemonOwners)
                .HasForeignKey(pokemon => pokemon.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(pokemon => pokemon.Owner)
                .WithMany(pokemonOwner => pokemonOwner.PokemonOwners)
                .HasForeignKey(owner => owner.OwnerId);
        }
    }
}

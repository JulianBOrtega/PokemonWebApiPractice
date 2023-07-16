using PokemonWebApiPractice.Models;

namespace PokemonWebApiPractice.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfPokemon(int pokemonId);
        bool ReviewExists(int id);
    }
}

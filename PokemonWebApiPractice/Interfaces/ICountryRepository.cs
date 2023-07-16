using PokemonWebApiPractice.Models;

namespace PokemonWebApiPractice.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        bool CountryExists(int id);
        bool OwnerExists(int ownerId);
    }
}

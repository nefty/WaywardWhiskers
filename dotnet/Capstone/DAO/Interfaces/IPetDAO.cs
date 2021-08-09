using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IPetDAO
    {
        bool AddPet(Pet pet);
        IEnumerable<Pet> GetAllPets();
        Pet GetPet(int petId);
        IEnumerable<Pet> GetLikedPets(int userId);
        IEnumerable<Pet> GetFilteredPets(SearchCriteria search);
        bool UpdatePet(Pet pet);
        bool DeletePet(int petId);
    }
}

import axios from 'axios';


export default {
    getAllPets() {
        console.log("Reached Get All Pets in PetService")
        return axios.get('/pets');
    },
    getPet(petID) {
        return axios.get(`/pets/${petID}`)
    },
    addPet(pet) {
        return axios.post('/pets', pet);
    },
    deletePet(petId) {
        console.log("Reached DeletePet in PetServices");
        console.log(petId);
        return axios.delete(`/pets/${petId}`)
    }
}
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
        console.log("Reached addPet in PetService");
        console.log(pet);
        return axios.post('/pets', pet);
    },
    deletePet(petId) {
        return axios.delete(`/pets/${petId}`)
    }
}
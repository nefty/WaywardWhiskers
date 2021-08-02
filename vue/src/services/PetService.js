import axios from 'axios';


export default {
    getAllPets() {
        console.log("Reached Get All Pets in PetService")
        return axios.get('/pets');
    },
    getPet(petID) {
        return axios.get(`/pets/${petID}`)
    },
}
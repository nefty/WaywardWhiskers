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
        console.log(pet);
        return axios.post('/pets', pet);
    },
    updatePet(pet) {
        console.log(pet);
        return axios.put('/pets', pet)
    },
    deletePet(petId) {
        console.log("Reached DeletePet in PetServices");
        console.log(petId);
        return axios.delete(`/pets/${petId}`)
    },
    addPetToPetMatches(petId){
        let userId = this.$store.state.user.userId;
        console.log(userId, petId);
        return axios.post(`/matchpet/${petId}`)
    },
    getPetsBasedOnSearchCriteria(filter){
        console.log(filter);
        return axios.get('/search/', filter)
    }
}
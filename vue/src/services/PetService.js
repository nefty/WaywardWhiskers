import axios from 'axios';


export default {
    getPets() {
        return axios.get('/pets');
    },
    getPet(petID) {
        return axios.get(`/pets/${petID}`)
    },
}
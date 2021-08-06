import axios from 'axios';


export default {
    getAllAgencies() {
        console.log("Reached Get All Agencies in AgencyService")
        return axios.get('/agency');
    },
    getAgency(agencyId) {
        return axios.get(`/agency/${agencyId}`)
    },
    addAgency(agency) {
        console.log(agency);
        return axios.post('/agency', agency);
    },
    updateAgency(agency) {
        console.log(agency);
        return axios.put('/agency', agency)
    },
    deleteAgency(agencyId) {
        console.log("Reached Delete Agency in AgencyServices");
        console.log(agencyId);
        return axios.delete(`/agency/${agencyId}`)
    }
}
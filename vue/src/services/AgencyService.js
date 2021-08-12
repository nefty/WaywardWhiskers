import axios from 'axios';


export default {
    getAllAgencies() {
        console.log("Reached Get All Agencies in AgencyService")
        return axios.get('/agency');
    },
    getAgency(agencyId) {
        return axios.get(`/agency/${agencyId}`)
    },
    async getAgencyCoords(address) {
        let response = await fetch(`https://api.mapbox.com/geocoding/v5/mapbox.places/${address}.json?limit=1&access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw`)
        let data = await response.json();
        data = JSON.stringify(data);
        data = JSON.parse(data);
        return data;
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
import axios from 'axios';

export default {
    getAllUsers() {
        console.log("Reached Get All Users in UserService")
        return axios.get('/admin');
    },
    getUser(userID) {
        return axios.get(`/admin/${userID}`)
    },
    updateUserRole(user) {
        console.log(user);
        return axios.put(`/admin/users/${user.userId}`, user)
    },
    deleteUser(userId) {
        console.log("Reached Delete User in UserService");
        console.log(userId);
        return axios.delete(`/admin/${userId}`)
    },
    updateUserPassword(resetCode, newPassword){
        return axios.put(`/resetpassword/`, {resetCode: resetCode, newPassword: newPassword})
    },
    getUserFromPWResetCode(resetCode){
        return axios.get(`/resetpassword/${resetCode}`)
    },
    getUserResetCodeFromEmailAddress(emailAddress){
        console.log(emailAddress);
        return axios.get(`/forgotpassword/${emailAddress}`)
    },
    likePets(likedPets) {
        return axios.post(`/user/pets/liked`, likedPets)
    },
    unlikePet(unlikedPet) {
        return axios.delete(`/user/pets/liked`, unlikedPet)
    }
    
}
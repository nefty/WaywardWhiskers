<template>

      <div class="form-group">
    <form v-on:submit.prevent="onSubmit" >
        <h3>Please Select A Role</h3>
  <input type="radio" name='role' v-model="role" value='user'>User
  <input type="radio" name='role' v-model="role" value='agency'>Agency
  <input type="radio" name='role' v-model="role" value='admin' v-if="$store.state.user.role == 'admin'">Admin
  
  <br />
  <span>value: {{role}}</span>
  <br />
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click="returnToUsers"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import UserService from '@/services/UserService.js'
export default {
name: 'role-change',
data() {
    return {
      editedUser: {},
      role: ''
    };
  },

  
  created(){
    console.log("reached created method");
    this.editedUser = this.$store.state.users.find(user => user.userId === this.$route.params.userId);
    console.log(this.editedUser);
  },

  methods: {
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedUser.id = this.$route.params.userId
      this.$store.commit("UPDATE_USER_ROLE", this.editedUser);

      UserService.updateUserRole(this.editedUser)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "user-list" });
        })
        .catch((error) => {
         
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });

      this.resetForm();
      this.returnToUsers();
    },

    resetForm() {
      this.editedUser = {};
    },

    returnToUsers() {
      this.$router.push({name: "user-list" });
    }
  },
}
</script>

<style>

</style>
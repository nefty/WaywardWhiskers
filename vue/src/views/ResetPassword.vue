<template>
  <b-container class="reset-password-form">
      <b-form @submit.prevent="onSubmit">
      <b-form-group
        id="input-group-1"
        label="New Password:"
        label-for="input-1"
        description="Password Reset Form"
      >
        <b-form-input
          id="input-1"
          v-model="password"
          type="email"
          placeholder="Enter new password"
          required
        ></b-form-input>
        <b-form-input
          id="input-1"
          v-model="confirmPassword"
          type="email"
          placeholder="Confirm new password"
          required
        ></b-form-input>
        <b-button type="submit" variant="primary">Submit</b-button>
      </b-form-group>
      </b-form>
  </b-container>
</template>

<script>
export default {
    name: "reset-password",
    data(){
        return {
            password: '',
            confirmPassword: '',
        }
    },
    methods: {
        onSubmit(){
            
        }
    }


}
</script>

<style>

</style>
<template>
  <b-container class="forgot-email-form" >
    <b-form @submit="onSubmit" @reset="onReset" >
      <b-form-group
        id="input-group-1"
        label="Email address:"
        label-for="input-1"
        description="We'll never share your email with anyone else."
      >
        <b-form-input
          id="input-1"
          v-model="email"
          type="email"
          placeholder="Enter email"
          required
        ></b-form-input>
        <b-button type="submit" variant="primary">Submit</b-button>
        <router-link :to="{ name: 'login' }">
        <b-button type="reset" variant="secondary">Cancel</b-button>
        </router-link>
      </b-form-group>
    </b-form>
  </b-container >
</template>

<script>
export default {
  name: "forgot-password",
  data() {
    return {
        email: ''
    };
  },
  methods: {
    onSubmit() {
        
    },
    onReset() {},
  },
};
</script>

<style>
</style>
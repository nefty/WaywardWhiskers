<template>
  <b-container class="forgot-email-form">
    <b-form @submit.prevent="onSubmit" @reset="onReset" v-if="showForm">
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
      <router-link :to="{name: 'reset-password', params: {resetCode: '5esmpjtymvx'}}">GO TO RESET PASSWORD PAGE</router-link>
        <b-button type="submit" variant="primary">Submit</b-button>
        <router-link :to="{ name: 'login' }">
          <b-button type="reset" variant="secondary">Cancel</b-button>
        </router-link>
      </b-form-group>
    </b-form>
    <p class="text-center" v-else>Thank you. An email has been sent with further instructions on resetting your password.</p>
  </b-container>
</template>

<script>
import emailjs from "emailjs-com";
export default {
  name: "forgot-password",
  data() {
    return {
      email: "",
      message: "http://localhost:8080/resetpassword/",
      from_name: "Wayward Whiskers",
      showForm: true
    };
  },
  methods: {
    onSubmit() {
      try {
        let user = this.$store.state.users.find(user => user.email === this.email);
        this.message += user.passwordResetCode;
          emailjs.send(
            "service_ma4flzn",
            "template_4pvo5su",
            {
              from_name: this.from_name,
              message: this.message,
              email: this.email,
            },
            "user_zwKLQJuOYaw9GImXa9FKt",
          );
          this.showForm = false;
        
      } catch (error) {
        console.log({ error });
      }
      // Reset form field
      this.email = "";
      this.message = "";
    },
    onReset() {},
  },
};
</script>

<style>
</style>
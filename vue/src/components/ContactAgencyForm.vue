<template>
  <b-form class="contact-form" @submit.prevent="sendEmail">
    <label>Name</label>
    <b-form-input type="text" name="user_name" />
    <label>Email</label>
    <b-form-input type="email" name="user_email" />
    <label>Message</label>
    <b-form-textarea name="message"></b-form-textarea>
    <b-button variant="primary"  >Send</b-button>
  </b-form>
</template>

<script>
import emailjs from "emailjs-com";

export default {
  name: "contact-agency-form",
  methods: {
    sendEmail: (e) => {
      emailjs
        .sendForm(
          "service_ma4flzn",
          "template_4pvo5su",
          e.target,
          "user_zwKLQJuOYaw9GImXa9FKt"
        )
        .then(
          (result) => {
            console.log("SUCCESS!", result.status, result.text);
          },
          (error) => {
            console.log("FAILED...", error);
          }
        );
    },
  },
};
</script>

<style>
</style>
<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Agency</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Agency Name </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newAgency.name"
        />
      </div>
      <div class="form-group">
        <label for="address">Address </label>
        <input
          required
          type="text"
          id="adress"
          name="adress"
          class="form-control"
          v-model="newAgency.address"
        />
      </div>
      <div class="form-group">
        <label for="address2">Address 2 </label>
        <input
          type="text"
          id="address2"
          name="address2"
          class="form-control"
          v-model="newAgency.address2"
        />
      </div>

      <div class="form-group">
        <label for="city">City </label>
        <input
          required
          type="text"
          id="city"
          name="city"
          class="form-control"
          v-model.number="newAgency.city"
        />
      </div>

      <div class="form-group">
        <label for="state">State </label>
        <input
          required
          type="text"
          id="state"
          name="state"
          class="form-control"
          v-model="newAgency.state"
        />
      </div>
      <div class="form-group">
        <label for="postal_code">Postal Code </label>
        <input
          required
          type="number"
          id="postal-code"
          name="postal-code"
          class="form-control"
          v-model.number="newAgency.postalCode"
        />
      </div>
      <div class="form-group">
          <label for="description">Description</label>
          <input
          required
          type="text"
          id="description"
          name="description"
          class="form-control"
          v-model.number="newAgency.description"
        />
      </div>

      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import AgencyService from "../services/AgencyService.js";

export default {
  name: "agency-add",
  data() {
    return {
      newAgency: {},

      isFormShown: false,
    };
  },

  methods: {
    onSubmit() {
      this.$store.commit("ADD_AGENCY", this.newAgency);

      AgencyService.addAgency(this.newAgency)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "agency-list" });
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
    },

    resetForm() {
      this.newAgency = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style>

</style>
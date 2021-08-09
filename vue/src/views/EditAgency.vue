<template>
  <div class="container">

    <form v-on:submit="onSubmit">
      <div class="form-group">
        <label for="name">Agency Name </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="editedAgency.name"
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
          v-model="editedAgency.address"
        />
      </div>
      <div class="form-group">
        <label for="address2">Address 2 </label>
        <input
          type="text"
          id="address2"
          name="address2"
          class="form-control"
          v-model="editedAgency.address2"
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
          v-model.number="editedAgency.city"
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
          v-model="editedAgency.state"
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
          v-model.number="editedAgency.postalCode"
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
          v-model.number="editedAgency.description"
        />
      </div>

      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click="returnToAgency"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import AgencyService from '../services/AgencyService.js'

export default {
  name: "edit-agency",
  data() {
    return {
      editedAgency: {},
    };
  },

  
  created(){
    console.log("reached created method");
    this.editedAgency = this.$store.state.agencies.find(agency => agency.id === this.$route.params.id);
    console.log(this.editedAgency);
  },

  methods: {
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedAgency.id = this.$route.params.id
      this.$store.commit("UPDATE_AGENCY", this.editedAgency);

      AgencyService.updateAgency(this.editedAgency)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.go({ name: "agency-list" });
        })
        .catch((error) => {
         
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
      this.returnToAgency();
    },

    returnToAgency() {
      this.$router.push({name: "agency-list" });
    }
  },
};
</script>

<style>

</style>
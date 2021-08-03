<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Pet</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newPet.name"
        />
      </div>
      <div class="form-group">
        <label for="type">Type: </label>
        <input
          required
          type="text"
          id="type"
          name="type"
          class="form-control"
          v-model="newPet.type"
        />
      </div>
      <div class="form-group">
        <label for="breed">Breed: </label>
        <input
          required
          type="text"
          id="breed"
          name="breed"
          class="form-control"
          v-model="newPet.breed"
        />
      </div>

      <div class="form-group">
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          name="age"
          class="form-control"
          v-model.number="newPet.age"
        />
      </div>

      <div class="form-group">
        <label for="description">Description: </label>
        <input
          required
          type="text"
          id="description"
          name="description"
          class="form-control"
          v-model="newPet.description"
        />
      </div>
      <div class="form-group">
        <label for="image">Image URL: </label>
        <input
          type="text"
          id="image"
          name="image"
          class="form-control"
          v-model="newPet.imageUrl"
        />
      </div>
      <div class="form-group">
          <label for="agency_id">Agency ID:</label>
          <input
          type="number"
          id="agency_id"
          name="agency_id"
          class="form-control"
          v-model.number="newPet.agencyId"
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
import PetService from "../services/PetService.js";

export default {
  name: "PetAdd",
  data() {
    return {
      newPet: {},

      isFormShown: false,
    };
  },

  methods: {
    onSubmit() {
      this.$store.commit("ADD_PET", this.newPet);

      PetService.addPet(this.newPet)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "pets-list" });
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
      this.newPet = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style>

</style>
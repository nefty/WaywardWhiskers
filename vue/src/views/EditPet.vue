<template>
  <div class="container">

    <form v-on:submit.prevent="onSubmit" >
      <div class="form-group">
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="editedPet.name"
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
          v-model="editedPet.type"
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
          v-model="editedPet.breed"
        />
      </div>

      <div class="form-group">
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          name="age"
          class="form-control"
          v-model.number="editedPet.age"
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
          v-model="editedPet.description"
        />
      </div>
      <div class="form-group">
        <label for="image">Image URL: </label>
        <input
          type="text"
          id="image"
          name="image"
          class="form-control"
          v-model="editedPet.imageUrl"
        />
      </div>
      <div class="form-group">
          <label for="agency_id">Agency ID:</label>
          <input
          type="number"
          id="agency_id"
          name="agency_id"
          class="form-control"
          v-model.number="editedPet.agencyId"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="returnToPets"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import PetService from '../services/PetService.js'

export default {
  name: "edit-pet",
  data() {
    return {
      editedPet: {},
    };
  },

  
  created(){
    console.log("reached created method");
    this.editedPet = this.$store.state.pets.find(pet => pet.id === this.$route.params.id);
    console.log(this.editedPet);
  },

  methods: {
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedPet.id = this.$route.params.id
      this.$store.commit("UPDATE_PET", this.editedPet);

      PetService.updatePet(this.editedPet)
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
      this.returnToPets();
    },

    resetForm() {
      this.editedPet = {};
    },

    returnToPets() {
      this.$router.push({name: "pets-list" });
    }
  },
};
</script>

<style>

</style>
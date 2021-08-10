<template>
  <div class="container">

    <form v-on:submit="onSubmit" >

      <div class="form-group required-field">
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

      <div class="form-group required-field">
        <label for="breed">Breed: </label>
        <input
          required
          type="text"
          id="breed"
          name="breed"
          class="form-control"
          v-model="editedPet.breedId"
        />
      </div>

      <div class="form-group">
        <label for="ageString">Age: (ex: 1 year 7 months) </label>
        <input
          type="text"
          id="ageString"
          name="ageString"
          class="form-control"
          v-model="editedPet.ageString"
        />
      </div>
      <div class="form-group required-field">
        <label for="ageGroup">Age Group: </label>
        <input
        required
          type="text"
          id="ageGroup"
          name="age"
          class="form-control"
          v-model="editedPet.age"
        />
      </div>
      <div class="form-group required-field">
        <label for="activityLevel">Activity Level: </label>
        <input
          required
          type="text"
          id="activityLevel"
          name="activityLevel"
          class="form-control"
          v-model="editedPet.activityLevel"
        />
      </div>
      <div class="form-group required-field">
        <label for="exerciseNeeds">Exercise Needs: </label>
        <input
          required
          type="text"
          id="exerciseNeeds"
          name="exerciseNeeds"
          class="form-control"
          v-model="editedPet.exerciseNeeds"
        />
      </div>
      <div class="form-group required-field">
        <label for="ownerExperience">Owner Experience Required?: </label>
        <input
          required
          type="text"
          id="ownerExperience"
          name="ownerExperience"
          class="form-control"
          v-model="editedPet.ownerExperience"
        />
      </div>
      <div class="form-group required-field">
        <label for="sizeGroup">Size Group: </label>
        <input
          required
          type="text"
          id="sizeGroup"
          name="sizeGroup"
          class="form-control"
          v-model="editedPet.sizeGroup"
        />
      </div>
      <div class="form-group required-field">
        <label for="vocalLevel">Vocal Level: </label>
        <input
          required
          type="text"
          id="vocalLevel"
          name="vocalLevel"
          class="form-control"
          v-model="editedPet.vocalLevel"
        />
      </div>
      <div class="form-group required-field">
        <label for="description">Description: </label>
        <input
          required
          type="text"
          id="description"
          name="description"
          class="form-control"
          v-model="editedPet.descriptionText"
        />
      </div>
      <div class="form-group required-field">
        <label for="image">Primary Image URL: </label>
        <input
          required
          type="text"
          id="primaryImage"
          name="primaryImage"
          class="form-control"
          v-model="editedPet.PrimaryImageUrl"
        />
      </div>
      <div class="form-group">
        <label for="thumbnail">Thumbnail URL: </label>
        <input
          type="text"
          id="thumbnail"
          name="thumbnail"
          class="form-control"
          v-model="editedPet.ThumbnailUrl"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click="returnToPets"
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
    this.editedPet = this.$store.state.pets.find(pet => pet.petId === this.$route.params.id);
    console.log(this.editedPet);
  },

  methods: {
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedPet.petId = this.$route.params.id
      this.$store.commit("UPDATE_PET", this.editedPet);

      PetService.updatePet(this.editedPet)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.go({ name: "pets-list" });
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
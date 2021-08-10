<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Pet</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group required-field">
        <label for="agency_id">Agency ID:</label>
        <input
          type="number"
          id="agency_id"
          name="agency_id"
          class="form-control"
          v-model.number="newPet.agencyId"
        />
      </div>
      <div class="form-group required-field">
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
      <div class="form-group required-field">
        <label for="species">Species: </label>
        <input
          required
          type="text"
          id="species"
          name="species"
          class="form-control"
          v-model.number="newPet.speciesId"
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
          v-model="newPet.breedId"
        />
      </div>

      <div class="form-group required-field">
        <label for="sex">Sex: </label>
        <input
          type="text"
          id="sex"
          name="sex"
          class="form-control"
          v-model="newPet.sex"
        />
      </div>
      <div class="form-group required-field">
        <label for="ageString">Age: (ex: 1 year 7 months) </label>
        <input
          type="text"
          id="ageString"
          name="ageString"
          class="form-control"
          v-model="newPet.ageString"
        />
      </div>
      <div class="form-group required-field">
        <label for="ageGroup">Age Group: </label>
        <input
          type="text"
          id="ageGroup"
          name="age"
          class="form-control"
          v-model="newPet.age"
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
          v-model="newPet.activityLevel"
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
          v-model="newPet.exerciseNeeds"
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
          v-model="newPet.ownerExperience"
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
          v-model="newPet.sizeGroup"
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
          v-model="newPet.descriptionText"
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
          v-model="newPet.descriptionText"
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
          v-model="newPet.PrimaryImageUrl"
        />
      </div>
      <div class="form-group">
        <label for="thumbnail">Thumbnail URL: </label>
        <input
          type="text"
          id="thumbnail"
          name="thumbnail"
          class="form-control"
          v-model="newPet.ThumbnailUrl"
        />
      </div>
      <div>
        <p class="required-field">Required field</p>
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
          // this.$router.push({ name: "pets-list" });
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
.required-field::before {
  content: "*";
  color: red;
  margin-right: 2px;
}
</style>
<template>
  <div class="container">

    <!-- <form v-on:submit="onSubmit" >

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
        <label for="ageString">Age: (ex: 1 year 7 months) </label>
        <input
          type="text"
          id="ageString"
          name="ageString"
          class="form-control"
          v-model="editedPet.ageString"
        />
      </div>
      <div class="form-group">
        <label for="ageGroup">Age Group: </label>
        <input
        required
          type="text"
          id="ageGroup"
          name="age"
          class="form-control"
          v-model="editedPet.ageGroup"
        />
      </div>
      <div class="form-group">
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
      <div class="form-group">
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
      <div class="form-group">
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
      <div class="form-group">
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
      <div class="form-group">
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
      <div class="form-group">
        <label for="description">Description: </label>
        <input
          required
          type="textarea"
          id="description"
          name="description"
          class="form-control"
          v-model="editedPet.descriptionText"
        />
      </div>
      <div class="form-group">
        <label for="image">Primary Image URL: </label>
        <input
          required
          type="text"
          id="primaryImage"
          name="primaryImage"
          class="form-control"
          v-model="editedPet.primaryImageUrl"
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
      </div> -->
      <b-form @submit.prevent="onSubmit">
      <b-form-group id="name" label="Name:" label-for="name">
        <b-form-input
          id="name"
          v-model="editedPet.name"
          type="text"
          placeholder="Enter Animal Name"
          required
        />
      </b-form-group>

      <b-form-group id="species" label="Species:" label-for="species">
        <b-form-select
          id="species"
          v-model="editedPet.speciesId"
          :options="species"
          value-field="speciesId"
          text-field="name"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="breed" label="Breed:" label-for="breeds">
        <b-form-select
          id="input-breeds"
          v-model="editedPet.breedId"
          :options="speciesBreeds"
          value-field="breedId"
          text-field="name"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="ageString" label="Age:" label-for="ageString">
        <b-form-input
          id="ageString"
          v-model="editedPet.ageString"
          type="text"
          description="Ex. 1 year 7 months"
        />
      </b-form-group>

      <b-form-group id="age-group" label="Age Group:" label-for="age-group">
        <b-form-select
          id="age-groups"
          v-model="editedPet.ageGroup"
          :options="ageGroupOptions"
          name="age-group"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="activity-level"
        label="Activity Level:"
        label-for="activity-level"
      >
        <b-form-select
          id="activity-level"
          v-model="editedPet.activityLevel"
          :options="activityLevelOptions"
          name="activity-level"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="exercise-needs"
        label="Exercise Needs:"
        label-for="exercise-needs"
      >
        <b-form-select
          id="input-exercise-needs"
          v-model="editedPet.exerciseNeeds"
          :options="exerciseNeedsOptions"
          name="exercise-needs"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="owner-experience"
        label="Owner Experience Required:"
        label-for="owner-experience"
      >
        <b-form-select
          id="owner-experience"
          v-model="editedPet.ownerExperience"
          :options="ownerExperienceOptions"
          name="owner-experience"
        ></b-form-select>
      </b-form-group>

      <b-form-group id="size-group" label="Size Group:" label-for="size-group">
        <b-form-select
          id="input-size-group"
          v-model="editedPet.sizeGroup"
          :options="sizeGroupOptions"
          name="size-group"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="vocal-level"
        label="Vocal Level:"
        label-for="vocal-level"
      >
        <b-form-select
          id="vocal-level"
          v-model="editedPet.vocalLevel"
          :options="vocalLevelOptions"
          name="vocal-level"
        ></b-form-select>
      </b-form-group>

      <b-form-group id="description" label="Description:" label-for="description">
        <b-form-textarea
          id="description"
          v-model="editedPet.descriptionText"
          required
        />
      </b-form-group>

      <b-form-group id="imageUrl" label="Image URL:" label-for="imageUrl">
        <b-form-input
          id="imageUrl"
          v-model="editedPet.primaryImageUrl"
          type="text"
          required
        />
      </b-form-group>

      <b-form-group id="thumbnailUrl" label="Thumbnail Url:" label-for="thumbnailUrl">
        <b-form-input
          id="thumbnailUrl"
          v-model="editedPet.thumbnailUrl"
          type="text"
          description="Can be the same as primary image."
        />
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
      <input
        type="button"
        v-on:click="returnToPets"
        class="btn btn-secondary"
        value="Cancel"
      />
    </b-form>
  </div>
</template>

<script>
import PetService from '../services/PetService.js';
import SpeciesService from "@/services/SpeciesService.js";
import BreedService from "@/services/BreedService.js";

export default {
  name: "edit-pet",
  data() {
    return {
      editedPet: {},
     sexOptions: [
        "Male",
        "Female"
      ],
      ageGroupOptions: [
        "Baby",
        "Young",
        "Adult",
        "Senior"
      ],
      activityLevelOptions: [
        "Not Active",
        "Slightly Active",
        "Moderately Active",
        "Highly Active"
      ],
      exerciseNeedsOptions: [
        "Not Required",
        "Low",
        "Moderate",
        "High"
      ],
      ownerExperienceOptions: [
        "None",
        "Species",
        "Breed"
      ],
      sizeGroupOptions: [          
        "Small",
        "Medium",
        "Large",
        "X-Large"
      ],
      vocalLevelOptions: [
        "Quiet",
        "Some",
        "Lots"
      ],
    };
  },
computed: {
   speciesBreeds: function () {
      if (this.editedPet.speciesId !== 0) {
        return this.breeds.filter( (breed) => {          
          return breed.speciesId === this.editedPet.speciesId;
        });
        } else {
          return this.breeds;
        }
    },
    species: function () {
      return this.$store.state.species;
    },
    breeds: function () {
      return this.$store.state.breeds;
    },
    agencies: function () {
      return this.$store.state.agencies;
    },
  },
  
  created(){
    console.log("reached created method");
    this.editedPet = this.$store.state.pets.find(pet => pet.petId === this.$route.params.id);
    console.log(this.editedPet);
    
    SpeciesService.getAllSpecies().then((response) => {
        this.$store.commit("SET_SPECIES", response.data);
      });
      BreedService.getAllBreeds().then((response) => {
        this.$store.commit("SET_BREEDS", response.data) 
      });
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
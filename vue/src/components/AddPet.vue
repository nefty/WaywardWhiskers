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
        <label for="agency_id">Agency: </label>
  <select required class="form-control" @change="changeAgency($event)">
    <option value="" selected disabled>Choose</option>
    <option v-for="agency in agencies" :value="agency.agencyId" :key="agency.agencyId">{{ agency.name }}</option>
  </select>
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
     <select required class="form-control" @change="changeSpecies($event)">
    <option value="" selected disabled>Choose</option>
    <option v-for="pet in pets" :value="pet.speciesId" :key="pet.speciesId">{{ pet.species }}</option>
  </select>
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
      <div class="form-group">
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
  <select required class="form-control" @change="changeAge($event)">
    <option value="" selected disabled>Choose</option>
    <option v-for="age in ageGroups" :value="age.name" :key="age.id">{{ age.name }} ({{age.desc}})</option>
  </select>
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
  <select required class="form-control" @change="changeExperience($event)">
    <option value="" selected disabled>Choose</option>
    <option v-for="experience in experienceTypes" :value="experience.id" :key="experience.id">{{ experience.name }}</option>
  </select>
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
import AgencyService from "@/services/AgencyService.js";

export default {
  name: "PetAdd",
    computed: {
    agencies() {
      return this.$store.state.agencies;
    },
    pets() {
      return this.$store.state.pets;
    },
  },
  data() {
    return {
      newPet: {},

      isFormShown: false,

      experienceTypes: [
        {name: "None", id: 0},
        {name: "Species Specific", id: 1}
      ],
            ageGroupOptions: [
          { text: "Baby", value: "Baby" },
          { text: "Young", value: "Young" },
          { text: "Adult", value: "Adult" },
          { text: "Senior", value: "Senior" },
        ],
      ageGroups: [
        {name: "baby", desc:"<6 months", id: 0},
        {name: "young", desc:"6 months - 2 years", id: 1},
        {name: "adult", desc:"2 years - 6 years", id: 2},
        {name: "senior", desc:"6+ years", id: 3}
      ],
      energyLevels: [

      ]
    };
  },
created() {
    AgencyService.getAllAgencies().then((response) => {
      this.$store.commit("SET_AGENCIES", response.data); 
    });
    PetService.getAllPets().then((response) => {
      this.$store.commit("SET_PETS", response.data);
    });
  },
  methods: {
        changeExperience(event) {
      this.newpet.ownerExperience = event.target.options[event.target.options.selectedIndex].text
    },
    changeSpecies(event) {
      this.newpet.speciesId = event.target.options[event.target.options.selectedIndex].text
    },
    changeAge(event) {
      this.newpet.ageGroup = event.target.options[event.target.options.selectedIndex].text
    },
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
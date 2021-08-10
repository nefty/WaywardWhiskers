<template>
  <div class="container">
    <b-card title="Find Your Purrfect Furry Friend!" class="mb-3" bg-variant="light">
      <b-form @submit="onSubmit" @reset="onReset">
        <b-form-group id="species" label="Species:" label-for="input-species">
          <b-form-select
            id="input-species"
            v-model="filter.speciesId"
            :options="species"
            value-field="speciesId"
            text-field="name"
          >
            <template #first>
              <b-form-select-option :value="null" disabled>Select an option</b-form-select-option>
            </template>
          </b-form-select>
          <div class="mt-3">Selected: <strong>{{ filter.speciesId }}</strong></div>
        </b-form-group>

        <b-form-group id="breed" label="Breed:" label-for="input-breeds">
          <b-form-select
            id="input-breeds"
            v-model="filter.breedIds"
            :options="speciesBreeds"
            value-field="breedId"
            text-field="name"
            multiple
          >
            <template #first>
              <b-form-select-option :value="null" disabled>Select an option</b-form-select-option>
            </template>
            
          </b-form-select>
          <div class="mt-3">Selected: <strong>{{ filter.breedIds }}</strong></div>
        </b-form-group>
        
        <b-form-group id="agencies" label="Agencies:" label-for="input-agencies">
          <b-form-select
            id="input-breed"
            v-model="filter.agencyIds"
            :options="agencies"
            value-field="agencyId"
            text-field="name"
            multiple
          >
            <template #first>
              <b-form-select-option :value="null" disabled>Select an option</b-form-select-option>
            </template>
            
          </b-form-select>
          <div class="mt-3">Selected: <strong>{{ filter.agencyIds }}</strong></div>
        </b-form-group>
        
        <b-form-group id="sex" label="Sex:" label-for="input-sex">
          <b-form-radio-group
            id="input-sex"
            v-model="filter.sex"
            :options="sexOptions"
          ></b-form-radio-group>
          <div class="mt-3">Selected: <strong>{{ filter.sex }}</strong></div>
        </b-form-group>
        
        <b-form-group id="age-groups" label="Age Groups:" label-for="input-age-groups">
          <b-form-radio-group
            id="input-age-groups"
            v-model="filter.sex"
            :options="sexOptions"
          ></b-form-radio-group>
          <div class="mt-3">Selected: <strong>{{ filter.sex }}</strong></div>
        </b-form-group>
        

        <b-button type="submit" variant="primary">Submit</b-button>

      </b-form>
    </b-card>
  </div>
</template>

<script>
import SpeciesService from "@/services/SpeciesService.js";
import BreedService from "@/services/BreedService.js";
import AgencyService from "@/services/AgencyService.js";

export default {
  name: "criteria-form",
  data() {
    return {
      sexOptions: [
          { value: "Male", text: "Male" },
          { value: "Female", text: "Female" },
        ],
      ageGroupOptions: [
          { text: "Baby", value: "Baby" },
          { text: "Young", value: "Young" },
          { text: "Adult", value: "Adult" },
          { text: "Senior", value: "Senior" },
        ],
      activityLevelOptions: [
          { text: "Not Active", value: "Not Active" },
          { text: "Slightly Active", value: "Slightly Active" },
          { text: "Moderately Active", value: "Moderately Active" },
          { text: "Highly Active", value: "Highly Active" },
        ],
      filter: {
        userId: 0,
        speciesId: 0,
        breedIds: [],
        agencyIds: [],
        sex: '',
        ageGroups: [],
        activityLevels: [],
        allExerciseNeeds: [],
        ownerExperiences: [],
        sizeGroups: [],
        vocalLevels: [],
      }
    };
  },
  computed: {
    speciesBreeds: function () {
      if (this.filter.speciesId !== 0) {
        return this.breeds.filter( (breed) => {          
          return breed.speciesId === this.filter.speciesId;
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
  methods: {
    onSubmit() {
      this.$store.commit("SET_SEARCH_CRITERIA", this.filter);
      this.$router.push('/petmatcher')
    },
    onReset() {},
    
  },
  created() {
      SpeciesService.getAllSpecies().then((response) => {
        this.$store.commit("SET_SPECIES", response.data);
      });
      BreedService.getAllBreeds().then((response) => {
        this.$store.commit("SET_BREEDS", response.data) 
      });
      AgencyService.getAllAgencies().then((response) => {
        this.$store.commit("SET_AGENCIES", response.data) 
      });
    },
};
</script>

<style>
</style>
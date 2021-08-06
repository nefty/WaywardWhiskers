<template>
  <div class="container">
    <b-card title="Find Your Purrfect Furry Friend!" class="mb-2" bg-variant="light">
      <b-form @submit="onSubmit" @reset="onReset">
        <label for="species-options">Species:</label>
        <b-form-select
          v-model="filter.speciesSelected"
          :options="filter.speciesOptions"
          name="species-options"
        ></b-form-select>

        <label>Sex:</label>
        <b-form-select
          v-model="filter.sexSelected"
          :options="filter.sexOptions"
        ></b-form-select>

        <label for="ageGroupCheckbox">Age Range:</label>
        <b-form-checkbox-group
          name="ageGroupCheckbox"
          id="age-range-checkbox-group"
          v-model="filter.ageGroupsSelected"
          :options="filter.ageOptions"
        ></b-form-checkbox-group>

        <label for="ageGroupCheckbox">Activity Level:</label>
        <b-form-checkbox-group
          name="activityLevelsCheckbox"
          id="activity-level-checkbox-group"
          v-model="filter.activityLevelsSelected"
          :options="filter.activityLevelOptions"
        ></b-form-checkbox-group>

        <b-button type="submit" variant="primary">Submit</b-button>

      </b-form>
    </b-card>
  </div>
</template>

<script>

export default {
  name: "criteria-form",
  data() {
    return {
      filter: {
        speciesSelected: null,
        speciesOptions: [
          { value: null, text: "Please select an option" },
          { value: "dog", text: "Dogs" },
          { value: "cat", text: "Cats" },
        ],
        sexSelected: null,
        sexOptions: [
          { value: null, text: "Please select an option" },
          { value: "male", text: "Male" },
          { value: "female", text: "Female" },
        ],
        ageGroupsSelected: [],
        ageOptions: [
          { text: "Baby", value: "baby" },
          { text: "Young", value: "young" },
          { text: "Adult", value: "adult" },
          { text: "Senior", value: "senior" },
        ],
        activityLevelsSelected: [],
        activityLevelOptions: [
          { text: "Not Active", value: "not active" },
          { text: "Slightly Active", value: "slightly active" },
          { text: "Moderately Active", value: "moderately active" },
          { text: "Highly Active", value: "highly active" },
        ],
      }
    };
  },
  methods: {
    onSubmit() {
      this.$store.commit("SET_FILTER_CRITERIA", this.filter);
      this.$router.push('/petmatcher')
    },
    onReset() {},
  },

  
};
</script>

<style>
</style>
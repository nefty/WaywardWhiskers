<template>
  <b-container>
    <b-container id="new-search">
      <b-button v-b-toggle.criteria variant="outline-primary"
        class="mx-2 my-2" pill block>New Search</b-button>
    </b-container>
    <b-sidebar id="criteria" title="Search Criteria" shadow>
      <template class="px-3 py-2" >
        <criteria-form />
      </template>
    </b-sidebar>
      <!-- <pet-card /> -->
    <pet-card-stack />      
  </b-container>
</template>

<script>
import PetCardStack from "@/components/PetCardStack.vue";
import CriteriaForm from "@/components/CriteriaForm.vue";
import PetService from "@/services/PetService.js";

export default {
  components: { PetCardStack, CriteriaForm },
  name: "pet-matcher",
  beforeCreate() {
      this.filter = {
        postalCode: 0,
        userId: 0,
        speciesId: 0,
        breedIds: [],
        agencyIds: [],
        sex: "",
        ageGroups: [],
        activityLevels: [],
        allExerciseNeeds: [],
        ownerExperiences: [],
        sizeGroups: [],
        vocalLevels: [],
      };
      this.$store.commit("SET_SEARCH_CRITERIA", this.filter);
      console.log(this.$store.state.filter);
            PetService.getFilteredPets(this.filter).then((response) => {
        this.$store.commit("SET_PETS", response.data);
      });
  },
};
</script>

<style scoped>
  #new-search {
    width: 350px;
  }
</style>
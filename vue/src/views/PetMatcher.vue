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

export default {
  components: { PetCardStack, CriteriaForm },
  name: "pet-matcher",
};
</script>

<style scoped>
  #new-search {
    width: 350px;
  }
</style>
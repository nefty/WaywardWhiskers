<template>
  <b-container>
    <div v-for="(pet, index) of pets" v-bind:key="index">
      <pet-card :pet="pet" :isMatchedPage="isMatchedPage" class="card" />
    </div>
  </b-container>
</template>

<script>
import PetCard from "@/components/PetCard.vue";
export default {
  name: "matches",
  components: { PetCard },
  computed: {
      pets() {
          return this.$store.state.matchedPets;
    },
  },
  data() {
      return {
        matchedPets: [],
        isMatchedPage: true,
    };
  },
  created() {
    this.matchedPets = this.$store.state.matchedPets;
    console.log(this.matchedPets);
  },
};
</script>

<style>
</style>
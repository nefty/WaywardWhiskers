<template>
  <div>
      <pet-card v-for="pet in pets" v-bind:pet="pet" v-bind:key="pet.id"  />
  </div>
</template>

<script>
import PetCard from "./PetCard.vue";
import PetService from "@/services/PetService.js"
export default {
    name: "pet-card-stack",
    
  components: { PetCard },
  computed: {
      pets() {
          return this.$store.state.pets;
      },
  },
  created() {
    PetService.getAllPets().then((response) => {
      this.$store.commit("SET_PETS", response.data);
    });
  },
  
};
</script>

<style>
</style>
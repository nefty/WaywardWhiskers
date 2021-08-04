<template>
  <div>
      <pet-card v-for="pet in pets" v-bind:key="pet.id" v-bind:currentPet="pet" />
  </div>
</template>

<script>
import PetCard from "./PetCard.vue";
export default {
    name: "pet-card-stack",
    pets: [],
  components: { PetCard },
  created(){
      this.pets = this.$store.state.pets;
  }
};
</script>

<style>
</style>
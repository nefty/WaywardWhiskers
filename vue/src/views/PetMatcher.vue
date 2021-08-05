<template>
  <div>

      <!-- <pet-card /> -->
<pet-card-stack :cards="cards"/>      
  </div>
</template>

<script>
import PetCardStack from "@/components/PetCardStack.vue";

export default {
  components: { PetCardStack },
  name: "pet-matcher",
  data() {
    return {
      cards: this.$store.state.pets
    }
  }
};
</script>

<style>
</style>
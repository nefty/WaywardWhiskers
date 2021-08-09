<template>
  <div>

      <!-- <pet-card /> -->
<pet-card-stack />      
  </div>
</template>

<script>
import PetCardStack from "@/components/PetCardStack.vue";

export default {
  components: { PetCardStack },
  name: "pet-matcher",
};
</script>

<style scoped>

</style>
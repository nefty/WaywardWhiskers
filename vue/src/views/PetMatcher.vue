<template>
  <div>
      <vue-swing @throwout="throwout" @throwin="throwin" :config="config">

      <pet-card />
      </vue-swing>
  </div>
</template>

<script>
import PetCard from '../components/PetCard.vue'

export default {
  name: "pet-matcher",
  components: { PetCard },
};
</script>

<style>
</style>
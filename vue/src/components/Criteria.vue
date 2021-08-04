<template>
  <div class="container">
      <label>Type:  </label>
              <select class="filter" name="type" id="type">
                  <option value=""></option>
                  <option value="dog">Dog</option>
                  <option value="cat">Cat</option>
              </select>
      <label>Age Range: </label>
      <select class="filter" name="type" id="type">
                  <option value=""></option>
                  <option value="baby">&lt;1</option>
                  <option value="young">1-3</option>
                  <option value="adult">3-5</option>
                  <option value="senior">6+</option>
              </select>
  </div>
</template>

<script>
import PetService from "@/services/PetService.js"

export default {
    name: "Criteria",

  computed: {
    pets() {
        let pets = this.$store.state.pets;
      return pets;
    },
    
  },
  created() {
    PetService.getAllPets().then((response) => {
      this.$store.commit("SET_PETS", response.data);
    });
  },
}
</script>

<style>

</style>
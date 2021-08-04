<template>
  <div class="container">
      <label>Type:  </label>
              <select name="type" id="type">
                  <option value=""></option>
                  <option value="dog">Dog</option>
                  <option value="cat">Cat</option>
              </select>
      <label>Age Range: </label>
      <select name="type" id="type">
                  <option value=""></option>
                  <option value="baby">&lt;1</option>
                  <option value="young">1-3</option>
                  <option value="adult">3-5</option>
                  <option value="senior">6+</option>
              </select>
      <label>Breed: </label>
      <select name="breed" id="breed">
      <option v-for="pet in this.$store.state.pets" v-bind:key="pet.id"> {{pet.breed}} </option>
      </select>
  </div>
</template>

<script>
import PetService from "@/services/PetService.js"

export default {
    name: "Criteria",
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

    data() {
        
    }
}
</script>

<style>

</style>
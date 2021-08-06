<template>
  <div class="container">
      <label>Type:  </label>
              <select class="filter" name="type" id="type">
                  <option v-on:click="type = ''"></option>
                  <option v-on:click="type = 'dog'">Dog</option>
                  <option v-on:click="type = 'cat'">Cat</option>
              </select>
      <label>Age Range: </label>
      <select class="filter" name="age-group" id="age-group">
                  <option v-on:click="ageGroup=''"></option>
                  <option v-on:click="ageGroup='baby'">Baby</option>
                  <option v-on:click="ageGroup='young-adult'">Young Adult</option>
                  <option v-on:click="ageGroup='senior'">Senior</option>
              </select>
  </div>
</template>

<script>
import PetService from "@/services/PetService.js"

export default {
    name: "criteria-form",

  computed: {
    pets() {
        let pets = this.$store.state.pets;
      return pets;
    },
    filteredPets() {
      return this.pets.filter(pet => {
        return this.filter === "" ? true : this.filter === pet.id;
      });
    }
    
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
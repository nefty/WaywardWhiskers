<template>
<div>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Age</th>
          <th scope="col">Type</th>
          <th scope="col">Breed</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pet, index) in pets" v-bind:key="index">
          <td>{{ pet.name }}</td>
          <td>{{ pet.age }}</td>
          <td>{{ pet.type }}</td>
          <td>{{ pet.breed }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import PetService from '@/services/PetService.js';

export default {
    name: 'pets-list',
    computed: {
        pets() { 
            console.log("Reached Computed in PetList");
            console.log(this.$store.state.pets);
            return this.$store.state.pets;
    }
    },
    created () {
        PetService.getAllPets()
        .then((response)=> {
            console.log(response.data);
            this.$store.commit("SET_PETS", response.data);
    }
        )}
}
</script>

<style>

</style>
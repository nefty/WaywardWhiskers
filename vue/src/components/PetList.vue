<template>
  <div>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Age</th>
          <th scope="col">Type</th>
          <th scope="col">Breed</th>
          <th scope ="col">ID</th>
          <th scope="col">Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pet) in pets" v-bind:key="pet.id">
          <td>{{ pet.name }}</td>
          <td>{{ pet.age }}</td>
          <td>{{ pet.type }}</td>
          <td>{{ pet.breed }}</td>
          <td>{{ pet.id }}</td>
          <td>
            <router-link v-bind:to="{name: 'edit-pet', params: {id: pet.id}}">
              <button class="btn btn-warning" >Edit</button>
            </router-link>
            <button class="btn btn-danger" v-on:click="deletePet(pet.id)" >Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
    <add-pet />
  </div>
</template>

<script>
import PetService from "@/services/PetService.js";
import AddPet from '../components/AddPet.vue';

export default {
  name: "pets-list",
  components: { AddPet },
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
  methods: {
    deletePet(petId){
      PetService.deletePet(petId)
      .then(() => this.$store.commit("DELETE_PET", petId))
    }
  }
};
</script>

<style>
</style>
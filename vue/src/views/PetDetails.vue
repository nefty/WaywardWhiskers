<template>
  <div>
    <h1>{{pet.name}}</h1>
    <h2>{{pet.petId}}</h2>

  </div>
</template>

<script>
import PetService from '../services/PetService.js'

export default {
    name: 'pet-details',
    data(){
        return {
            pet: {
                id: 0,
                name: '',
                type: '',
                breed: '',
                age: 0,
                description: '',
                imageURL: '',
            }
        }
    },
    created() {
        PetService
            .getPet(this.$route.params.petID)
            .then(() => {
                this.$store.commit("SET_ACTIVE_PET", this.$route.params.petID);

                this.pet = this.$store.state.pets.find(pet => pet.petID == this.$store.state.activePet);
                return this.pet;
            })
    }
    

}
</script>

<style>

</style>
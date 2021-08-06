<template>
  <b-container class="accept-reject-bar" >
    <b-row>
      <b-col>
        <b-icon icon="heart-fill" scale="2"  class="heart-button" style="color: #FF69B4" @click="addPetToMatched(pet.id)"></b-icon>
      </b-col>
      <b-col>
        <b-icon icon="x-circle" scale="2"  variant="danger" class="skip-button"></b-icon>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  components: {},
  pet: {},
  methods: {
      addPetToMatched(petId){
          this.$store.commit("ADD_PET_TO_MATCHED", petId);
      }
  },
  created(){
      this.pet = this.$store.state.activePet;
  }
};
</script>

<style>
.accept-reject-bar {
  justify-content: center;
  margin: 20px;
}

</style>
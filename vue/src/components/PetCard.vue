<template>
    <b-card
      elevation="2"
      bg-variant="light"
      v-bind:title="pet.name"
      v-bind:img-src="pet.primaryImageUrl"
      img-alt="Image"
      tag="article"
      style="max-width: 20rem"
      class="mb-2"
      display="flex"
      v-if="(this.$store.state.matchedPets.includes(pet) === false && this.$store.state.rejectedPets.includes(pet) === false) || isMatchedPage === true"
      v-on:mouseover="setActivePet"
    >
      <b-collapse id="collapse-1">
        
          <p class="card-text">{{ pet.descriptionText }}</p>
        
      </b-collapse>
      <b-button v-b-toggle.collapse-1 variant="primary" v-show="!isMatchedPage"
        >About {{pet.name}}
      </b-button>
      <accept-reject-icons-bar  v-show="!isMatchedPage"/>
      <router-link v-show="isMatchedPage" :to="{ name: 'pet-details', params: {id: pet.petId} }" >
        
      <b-button variant="primary"> View Adoption Details
      </b-button>
        
        </router-link>
    </b-card>
</template>

<script>
import AcceptRejectIconsBar from './AcceptRejectIconsBar.vue';

export default {
  components: { AcceptRejectIconsBar },
  name: "pet-card",
  props: {
    isMatchedPage: Boolean,
    pet: {
      type: Object,
    },
  },
  methods: {
    setActivePet(){
      this.$store.commit("SET_ACTIVE_PET", this.pet);
    },
  },
  
  
};
</script>

<style>
.mb-2 {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  margin: 100px;
  align-items: center;
  justify-content: center;
  margin: auto;
  display: flex;
  
  
}
.mb-2 img {
  height: 220px;
  border-radius: 20px;
  margin: 5px;
  pointer-events: none;
}

</style>
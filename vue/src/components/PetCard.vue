<template>
    <b-card
      v-bind:title="pet.name"
      v-bind:img-src="pet.imageUrl"
      img-alt="Image"
      tag="article"
      style="max-width: 20rem"
      class="mb-2"
      display="flex"
      v-on:click.prevent="writeLog"
      v-if="this.$store.state.matchedPets.includes(pet.id) === false && this.$store.state.rejectedPets.includes(pet.id) === false"
    >
      <b-collapse id="collapse-1">
        <b-card>
          <p class="card-text">{{ pet.description }}</p>
        </b-card>
      </b-collapse>
      <b-button v-b-toggle.collapse-1 variant="primary"
        >Toggle Collapse
      </b-button>
      <accept-reject-icons-bar  />
    </b-card>
</template>

<script>
import AcceptRejectIconsBar from './AcceptRejectIconsBar.vue';

export default {
  components: { AcceptRejectIconsBar },
  name: "pet-card",
  props: {
    pet: {
      type: Object,
    },
  },
  methods: {
    writeLog(){
      console.log(this.pet)
    },
    
  },
  created(){
    this.$store.state.activePet = this.pet;
  }
  
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
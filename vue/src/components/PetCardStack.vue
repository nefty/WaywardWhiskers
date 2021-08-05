<template>
  <div>
        <vue-swing
          @throwout="throwout"
          @throwin="throwin"
          :config="config"
          class="cards"
          
        >
          <pet-card v-for="pet in pets"
          :key="pet.id"
          :pet="pet"  class="card"/>
        </vue-swing>
  
  </div>
</template>

<script>
import PetCard from "./PetCard.vue";
import PetService from "@/services/PetService.js";
import Swing from 'swing'


export default {
  name: "pet-card-stack",
  props: {
    cards: {
      type: Array,
    }
  },
  mounted(){

  },
  components: { PetCard},
  computed: {
    pets() {
      return this.$store.state.pets;
    },
    currentPet() {
      return this.$store.state.pets[this.$store.state.pets.length - 1];
    },
    stack(){
      var stack = Swing.Stack();
      
      return stack;
    }
    
  },
  created() {
    PetService.getAllPets().then((response) => {
      this.$store.commit("SET_PETS", response.data);
    });
  },
  data() {
    return {
      config: {
        /**
         * Invoked in the event of dragmove.
         * Returns a value between 0 and 1 indicating the completeness of the throw out condition.
         * Ration of the absolute distance from the original card position and element width.
         *
         * @param {number} xOffset Distance from the dragStart.
         * @param {number} yOffset Distance from the dragStart.
         * @param {HTMLElement} element Element.
         * @returns {number}
         */
        throwOutConfidence: (xOffset, yOffset, element) => {
          const xConfidence = Math.min(
            Math.abs(xOffset) / element.offsetWidth,
            1
          );
          const yConfidence = Math.min(
            Math.abs(yOffset) / element.offsetHeight,
            1
          );

          return Math.max(xConfidence, yConfidence);
        },
      },
    };
  },
  methods: {
    throwin() {},
    throwout() {
      const index = this.$store.state.pets.findIndex(
        (x) => x.id === this.currentPet.id
      );
      this.$store.state.pets.splice(index, 1);
    },
    
  },
};
</script>

<style scoped>
.card {
  position: relative;
}
</style>
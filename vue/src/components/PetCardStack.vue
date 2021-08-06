<template>
  <div>
    <vue-swing
      @throwin="throwin"
      :config="config"
      v-for="pet in pets"
      @throwoutright="throwoutMatch(pet.id)"
      @throwoutleft="throwoutReject(pet.id)"
      :key="pet.id"
    >
      <pet-card :pet="pet" class="card" />
    </vue-swing>
  </div>
</template>

<script>
import PetCard from "./PetCard.vue";
import PetService from "@/services/PetService.js";
import VueSwing from "vue-swing";

export default {
  name: "pet-card-stack",
  components: { PetCard },
  computed: {
    pets() {
      return this.$store.state.pets;
    },
  },
  created() {
    PetService.getAllPets().then((response) => {
      
      this.$store.commit("SET_PETS", response.data);
    });
    this.petsTestArray = this.$store.state.pets;
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
        allowedDirections: [VueSwing.Direction.LEFT, VueSwing.Direction.RIGHT],
      },
    };
  },
  methods: {
    throwin() {},
    throwoutMatch(petId) {
      this.$store.commit("ADD_PET_TO_MATCHED", petId);
    },
    throwoutReject(petId) {
      this.$store.commit("ADD_PET_TO_REJECTED", petId);
    },
  },
};
</script>

<style scoped>
</style>
<template>
  <b-container>
    <b-tabs content-class="mt-3">
      <b-tab v-bind:title="pet.name">
        <b-card
          elevation="2"
          bg-variant="light"
          v-bind:title="pet.name"
          tag="article"
          style="max-width: 200rem"
          display="flex"
        >
          <b-row>
            <b-col>
              <b-carousel
                id="carousel-1"
                :interval="8000"
                v-model="slide"
                controls
                indicators
                background="#ababab"
                img-width="1024"
                img-height="480"
                style="text-shadow: 1px 1px 2px #333"
                @sliding-start="onSlideStart"
                @sliding-end="onSlideEnd"
              >
                <b-carousel-slide
                  v-for="picture in pictures"
                  :key="picture.pictureId"
                  v-bind:img-src="picture.url"
                ></b-carousel-slide>
              </b-carousel>
            </b-col>
            <b-col>
              <h3>Details</h3>

              <b-card-text v-if="pet.ageString !== ''"
                >Age: {{ pet.ageString }}</b-card-text
              >
              <b-card-text v-else>Age: {{ pet.ageGroup }}</b-card-text>
              <b-card-text>Sex: {{ pet.sex }}</b-card-text>

              <b-card-text>Size: {{ pet.sizeGroup }}</b-card-text>
              <b-card-text>Breed: {{ pet.breed }}</b-card-text>

              <b-card-text>Exercise Needs: {{ pet.exerciseNeeds }}</b-card-text>
              <b-card-text v-show="pet.vocalLevel !== ''"
                >Vocal Level: {{ pet.vocalLevel }}</b-card-text
              >
              <b-card-text>{{ pet.descriptionText }}</b-card-text>
            </b-col>
          </b-row>
        </b-card>
      </b-tab>

      <b-tab v-bind:title="agency.name">
        <b-card
          elevation="2"
          bg-variant="light"
          v-bind:title="agency.name"
          tag="article"
          style="max-width: 200rem"
          display="flex"
        >
          <b-row>
            <b-col>
              <h6>About</h6>
              <b-card-text>{{ agency.about }}</b-card-text>
              <b-card-text
                >Located in: {{ agency.city }}, {{ agency.state }}</b-card-text
              >
              <b-link v-bind:href="agency.url"
                >Visit {{ agency.name }}'s Website</b-link
              >
            </b-col>
            <b-col>
              <single-instance-map />
            </b-col>
          </b-row>
        </b-card>
      </b-tab>
      <b-tab title="Ask About Adopting!">
        <contact-agency-form :pet="pet" :agency="agency" />
      </b-tab>
    </b-tabs>
  </b-container>
</template>

<script>
import PetService from "@/services/PetService.js";
import AgencyService from "@/services/AgencyService.js";
import ContactAgencyForm from "../components/ContactAgencyForm.vue";


export default {
  name: "pet-details",
  components: { ContactAgencyForm},
  data() {
    return {
      slide: 0,
      sliding: null,
      pictures: [],
      pet: {},
      agency: {},
    };
  },
  created() {
    PetService.getPetPictures(this.$route.params.id).then((response) => {
      this.pictures = response.data;
    });
    PetService.getPet(this.$route.params.id).then((response) => {
      this.pet = response.data;
      this.$store.commit("SET_ACTIVE_PET", this.pet.petId);
    });
    PetService.getPet(this.$route.params.id).then((response) => {
      AgencyService.getAgency(response.data.agencyId).then((response) => {
        this.agency = response.data;
        this.$store.commit("SET_ACTIVE_AGENCY", this.agency);
      });
    });
  },

  methods: {
    onSlideStart(slide) {
      console.log(slide);
      this.sliding = true;
    },
    onSlideEnd(slide) {
      console.log(slide);
      this.sliding = false;
    },
  },
};
</script>

<style>
</style>
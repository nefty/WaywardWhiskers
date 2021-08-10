<template>
  <b-container>
<b-carousel
      id="carousel-1"
      v-model="slide"
      :interval="4000"
      controls
      indicators
      background="#ababab"
      img-width="1024"
      img-height="480"
      style="text-shadow: 1px 1px 2px #333;"
      @sliding-start="onSlideStart"
      @sliding-end="onSlideEnd"
    >
      <!-- Text slides with image -->
      <b-carousel-slide
        v-for="picture in pictures"
        :key="picture.id"
        v-bind:img-src="picture.url"
        caption="First slide"
        text="Nulla vitae elit libero, a pharetra augue mollis interdum."
      ></b-carousel-slide>
      
    </b-carousel>

  </b-container>
</template>

<script>
import PetService from '@/services/PetService.js'
export default {
    name: 'pet-details',
    props: {
        pet: Object,
    },
    computed: {
        pictures(){
            return PetService.getPetPictures(this.pet.id);
        }
    }
}
</script>

<style>

</style>
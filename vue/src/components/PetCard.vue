<template>
    <b-card
      v-bind:title="currentPet.name"
      v-bind:img-src="currentPet.imageUrl"
      img-alt="Image"
      img-top
      tag="article"
      style="max-width: 20rem"
      class="mb-2"
    >
      <b-collapse id="collapse-1">
        <b-card>
          <p class="card-text">{{ currentPet.description }}</p>
        </b-card>
      </b-collapse>
      <b-button v-bind:key="currentPet.id" v-b-toggle.collapse-1 variant="primary"
        >Toggle Collapse
      </b-button>
    </b-card>
</template>

<script>
export default {
  name: "pet-card",
  currentPet: {},
  created(){
    var randomNumber = Math.floor(Math.random() * this.$store.state.pets.length);
    this.currentPet = this.$store.state.pets[randomNumber];
  }
};
</script>

<style>
.mb-2 {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 350px;
  margin: 100px;
  align-items: center;
  justify-content: center;
  margin: auto;
}
.mb-2 img {
  height: 60%;
}
</style>
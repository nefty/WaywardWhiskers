<template>
<vue-swing @throwout="throwout" @throwin="throwin" :config="config">

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
</vue-swing>
</template>

<script>
export default {
  name: "pet-card",
  props: {
    currentPet: Object,
  },
  
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
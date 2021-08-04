<template>
  <div>
    <b-card
      v-bind:title="pet.name"
      v-bind:img="pet.imageUrl"
      img-src="https://media.hswstatic.com/eyJidWNrZXQiOiJjb250ZW50Lmhzd3N0YXRpYy5jb20iLCJrZXkiOiJnaWZcL3B1Zy5qcGciLCJlZGl0cyI6eyJyZXNpemUiOnsid2lkdGgiOjQwMH19fQ=="
      img-alt="Image"
      img-top
      tag="article"
      style="max-width: 20rem"
      class="mb-2"
    >
      <b-collapse id="collapse-1">
        <b-card>
          <p class="card-text">{{ pet.description }}</p>
        </b-card>
      </b-collapse>
      <b-button v-bind:key="pet.id" v-b-toggle.collapse-1 variant="primary"
        >Toggle Collapse</b-button
      >
    </b-card>
  </div>
</template>

<script>
export default {
  name: "pet-card",
  props: {
    pet: Object,
  },
};
</script>

<style>
.card {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 350px;
  margin: 100px;
  align-items: center;
}
</style>
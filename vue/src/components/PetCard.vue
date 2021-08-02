<template>
  <div
    class="card"
    v-bind:class="{ read: book.read }"
    v-on:click="setActiveBook"
  >
    
    
</template>

<script>
export default {
    name: "pet-card",
    props: {
        pet: Object,
    }
}
</script>

<style>

</style>
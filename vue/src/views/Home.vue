<template>
  <div class="home">
    <h1>Wayward Whiskers</h1>
    <p>Welcome to Wayward Whiskers!</p>
    <add-pet />
  </div>
</template>

<script>
import AddPet from '../components/AddPet.vue';
export default {
  components: { AddPet },
  name: "home"
}
</script>

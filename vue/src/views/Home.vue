<template>
  <div class="home">
    <h1>Wayward Whiskers</h1>
    <p>Welcome to Wayward Whiskers!</p>
    <Criteria />
  </div>
</template>

<script>

import Criteria from '@/components/Criteria.vue'

export default {
  name: "home",

components: {Criteria}

}
</script>

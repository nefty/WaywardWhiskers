<template>
  <div id="navbar">
    <b-navbar toggleable="lg" type="light" variant="light" >
      <b-navbar-brand>
        <router-link class="navbar-brand" v-bind:to="{ name: 'home' }">Wayward Whiskers</router-link>
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item>
            <router-link class="nav-link" v-bind:to="{ name: 'pets-list' }">All Pets</router-link>
          </b-nav-item>
          <b-nav-item>
            <router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
             <router-link class="nav-link" v-bind:to="{ name: 'login' }" v-else>Login</router-link>
          </b-nav-item>
          <b-nav-item>
            <router-link class="nav-link" v-bind:to="{ name: 'pet-matcher' }">Pet Matcher</router-link>
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
export default {
  name: "the-navbar",
};
</script>
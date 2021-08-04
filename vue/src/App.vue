<template>
  <div id="app">
    <router-link v-bind:to="{ name: 'home' }">Wayward Whiskers</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <router-link v-bind:to="{ name: 'login' }" v-else>Login</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'pets-list' }">All Pets</router-link>
    <router-view />
  </div>
</template>

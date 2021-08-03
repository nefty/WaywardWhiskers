<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light" id="nav">
      <div class="container-fluid">
        <router-link class="navbar-brand" v-bind:to="{ name: 'home' }">Wayward Whiskers</router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <router-link class="nav-link" v-bind:to="{ name: 'pets-list' }">All Pets</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
          <router-link class="nav-link" v-bind:to="{ name: 'login' }" v-else>Login</router-link>
        </li>
      </ul>
      </div>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<template>
  <b-container>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope ="col">ID</th>
          <th scope="col">Name</th>
          <th scope="col">City/State</th>
          <th scope="col">Description</th>
          <th scope="col">Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(agency) in agencies" v-bind:key="agency.id">
          <td>{{ agency.id }}</td>
          <td>{{ agency.name }}</td>
          <td>{{ agency.city }}, {{agency.state}}</td>
          <td>{{ agency.description }}</td>
          <td>
            <router-link :to="{name: 'edit-agency', params: {id: agency.id}}">
              <button class="btn btn-warning" >Edit</button>
            </router-link>
            <button class="btn btn-danger" v-on:click="deleteAgency(agency.id)" >Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
    <add-agency />
  </b-container>
</template>

<script>
import AgencyService from "@/services/AgencyService.js";
import AddAgency from './AddAgency.vue';

export default {
  name: "agency-list",
  components: { AddAgency },
  computed: {
    agencies() {
      return this.$store.state.agencies;
    },
  },
  created() {
    AgencyService.getAllAgencies().then((response) => {
      this.$store.commit("SET_AGENCIES", response.data);
    });
  },
  methods: {
    deleteAgency(agencyId){
      if(confirm(`Are you sure you want to delete this? This will remove all pets associated as well.`))
      {AgencyService.deleteAgency(agencyId)
      .then(() => this.$store.commit("DELETE_AGENCY", agencyId))
    }
    }
  }
};
</script>

<style>
</style>
<template>
  <b-container>
    <div style="height: 500px; width: 100%">
      <l-map
        :zoom="zoom"
        :center="center"
        :options="mapOptions"
        style="height: 80%"
      >
        <l-tile-layer :url="url" :attribution="attribution" />
        <l-marker v-bind:lat-lng="[agency.lat, agency.lon]">
          <l-popup>
            {{ agency.name }}
          </l-popup>
        </l-marker>
      </l-map>
    </div>
  </b-container>
</template>

<script>
export default {
  name: "single-instance-map",
  data() {
    return {
      zoom: 4,
      center: {lat: agency.lat.number, lng: agency.lon.number},
      url: "https://api.mapbox.com/styles/v1/mapbox/light-v10/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw",
      attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors | Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      mapOptions: {
        zoomSnap: 0.5,
      },
    }
  },
  computed: {
    agency: function() {
      return this.$store.state.activeAgency;
    }
  }
  
};
</script>

<style>
</style>
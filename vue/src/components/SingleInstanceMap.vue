<template>
  <b-container >
    <div style="height: 500px; width: 100%" @shown="containerShown" class="activeAgencyMap">
      <l-map
        :zoom="zoom"
        :center="this.center"
        :options="mapOptions"
        style="height: 80%"
        ref="myMap"
      >
        <l-tile-layer :url="url" :attribution="attribution" />
        <l-marker v-bind:lat-lng="this.center">
          <l-popup>
            {{ this.$store.state.activeAgency.name }}
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
      zoom: 9,
      url: "https://api.mapbox.com/styles/v1/mapbox/light-v10/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw",
      attribution:
        '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors | Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      mapOptions: {
        zoomSnap: 0.5,
      },
    };
  },
  computed: {
    center() {
      return [ this.$store.state.activeAgency.lat, this.$store.state.activeAgency.lon ];
    },
  },
  methods:{
    containerShown(){
      setTimeout(() => {
        console.log(this.$refs.myMap.data);
        this.$refs.myMap.mapObject.invalidateSize();
      }, 100);
    }
  }
};
</script>

<style lang="scss" scoped>
.activeAgencyMap {
  width: 100%;
    height: 400px;
}
</style>
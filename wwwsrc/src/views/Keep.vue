<template>
  <div class="container-fluid bg-size">
    <navbar></navbar>
    <div class="row">
      <div class="col-1"></div>
      <div class="col-10 d-flex justify-content-center">
        <div class="card mt-3 activeKeepImg">
          <div class="card-header">
            <h5>{{activeKeep.name}}</h5>
          </div>
          <img :src="activeKeep.img" class="card-img-top">
          <div class="card-body">
            <p>{{activeKeep.description}}</p>
          </div>
        </div>
      </div>
      <div class="col-1"></div>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/NavBar.vue";
export default {
  name: "Keep",
  data() {
    return {};
  },
  props: ["keepId"],
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {},
  components: {
    Navbar
  }
};
</script>

<style>
.activeKeepImg {
  max-width: 75vw;
  max-width: 75vh;
}
</style>
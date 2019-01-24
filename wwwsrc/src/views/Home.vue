<template>
  <div class="home bg-color container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>Welcome To Keepr!</h1>
      </div>
    </div>
    <div class="row d-flex justify-content-around">
      <div class="col-12"></div>
      <div v-for="keep in keeps" :key="keep.id">
        <div class="card mb-2" style="width: 16rem">
          <div class="card-header d-flex justify-content-start">
            <h5>{{keep.name}}</h5>
          </div>
          <img class="card-img-top hover card-images" :src="keep.img">
          <div class="card-body d-flex justify-content-center">
            <i class="far fa-eye">: {{keep.views}}</i>
            <i class="fas fa-camera-retro ml-3">: {{keep.vaultAdds}}</i>
            <i class="fas fa-plus-square ml-3"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/NavBar.vue";
export default {
  name: "home",
  mounted() {
    //blocks users not logged in
    // if (!this.$store.state.user.id) {
    //   this.$router.push({ name: "home" });
    // }
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Navbar
  }
};
</script>
<style>
.card-header {
  background-color: #7de2d1;
}
.bg-color {
  background-color: white;
  size: 100vh;
}
.hover {
  cursor: pointer;
}
.card-images {
  min-height: 14rem;
}
</style>
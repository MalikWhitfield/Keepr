<template>
  <div class="home container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>Welcome To Keepr!</h1>
      </div>
    </div>
    <div class="row d-flex justify-content-around">
      <div v-for="keep in keeps" :key="keep">
        <div class="card" style="width: 15rem">
          <div class="card-header d-flex justify-content-between">
            <h1>{{keep.name}}</h1>
          </div>
          <img class="card-img-top" :src="keep.img">
          <div class="card-body">
            <i class="far fa-eye">{{keep.views}}</i>
            <h6>Vault Adds: {{keep.vaultAdds}}</h6>
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
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
    this.$store.dispatch("getKeeps");
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
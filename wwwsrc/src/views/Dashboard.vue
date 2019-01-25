<template>
  <div class="container-fluid">
    <navbar></navbar>
    <div class="row mt-3">
      <div class="col-6 align-items-center">
        <div class="card hover" @click="$router.push({name: 'UserVaults'})">
          <h5 class="mt-1">My Vaults</h5>
        </div>
      </div>
      <div class="col-6 align-items-center">
        <div class="card hover" @click="$router.push({name: 'UserKeeps'})">
          <h5 class="mt-1">My Keeps</h5>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/NavBar.vue";
export default {
  name: "Dashboard",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.store.state.vaults;
    }
  },
  methods: {},
  components: {
    Navbar
  }
};
</script>

<style>
</style>
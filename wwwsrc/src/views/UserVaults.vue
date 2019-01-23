<template>
  <div class="container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>My Vaults:</h1>
        <div class="row">
          <div class="col-12 d-flex justify-content-center">
            <div v-for="vault in vaults" :key="vault.id">
              <div class="card mb-2 mr-5" style="width:16rem">
                <router-link
                  :to="{name: 'Vault', params: {vaultId: vault.id}}"
                  class="card-header d-flex justify-content-center"
                >
                  <h5>{{vault.name}}</h5>
                </router-link>
                <img class="card-img-top hover" :src="vault.img">
                <div class="card-body">{{vault.description}}</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/NavBar.vue";
export default {
  name: "UserVaults",
  data() {
    return {
      newVault: {
        name: "",
        description: "",
        img: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.viewedUser;
    }
  },
  methods: {},
  components: {
    Navbar
  }
};
</script>

<style>
.card-style {
  width: 16rem;
  height: 16rem;
}
</style>
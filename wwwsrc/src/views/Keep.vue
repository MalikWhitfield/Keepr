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
          <!-- ADD TO VAULT MODAL -->
          <div class="dropdown col-1-sm ml-2">
            <button
              class="btn btn-secondary dropdown-toggle"
              type="button"
              id="addToVaultDrop"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Add</button>
            <div class="dropdown-menu" aria-labelledby="addToVaultDrop">
              <a
                v-for="vault in vaults"
                :key="vault.id"
                class="dropdown-item hover"
                @click="$store.dispatch('addKeepToVault', {keepId: keep.id, vaultId: vault.id})"
              >{{vault.name}}</a>
            </div>
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
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
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
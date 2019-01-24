<template>
  <div class="container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>Your Vault</h1>
        <!-- <h1>{{vault.name}}</h1> -->
      </div>
    </div>
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
          <div class="card mb-2 mr-4" style="width: 16rem">
            <div class="card-header d-flex">
              <div class="d-flex justify-content-start">
                <h5>{{vaultKeep.name}}</h5>
              </div>
              <div class="d-flex justify-content-end">
                <i class="fas fa-trash hover" @click="deleteVaultKeep(vaultKeep.id)"></i>
              </div>
            </div>
            <img class="card-img-top hover" :src="vaultKeep.img">
            <div class="card-body d-flex justify-content-center">
              <i class="far fa-eye">: {{vaultKeep.views}}</i>
              <i class="fas fa-camera-retro ml-3">: {{vaultKeep.vaultAdds}}</i>
              <i class="fas fa-plus-square ml-3"></i>
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
  name: "Vault",
  data() {
    return {};
  },
  props: ["vaultId"],
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.vaultId);
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    deleteVaultKeep(keepId) {
      this.$store.dispatch("deleteVaultKeep", {
        keepId,
        vaultId: this.vaultId
      });
    }
  },
  components: {
    Navbar
  }
};
</script>

<style>
</style>
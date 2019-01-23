<template>
  <div class="container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>My Vaults:</h1>
      </div>
    </div>

    <!-- ADD VAULT BUTTON -->
    <div class="row d-flex justify-content-center mb-2">
      <div class="col-12">
        <button type="button" class="btn" data-toggle="modal" data-target="#add-vault">Add Vault</button>
      </div>
    </div>

    <!-- ADD VAULT MODAL -->
    <div
      class="modal fade"
      tabindex="-1"
      id="add-vault"
      role="dialog"
      aria-labelledby="add-vault-label"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header text-center align-items-center">
            <h4>Add vault</h4>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body mx-3">
            <form @submit.prevent="addVault">
              <div class="md-form mb-2">
                <i class="fas fa-tag"></i>
                <input
                  type="text"
                  id="vaultForm-name"
                  class="form-control validate"
                  placeholder="Name"
                  v-model="newVault.name"
                >
              </div>
              <div class="md-form mb-2">
                <i class="fas fa-align-justify"></i>
                <input
                  type="text"
                  id="vaultForm-desc"
                  class="form-control validate"
                  placeholder="Description"
                  v-model="newVault.description"
                >
              </div>
              <div class="md-form mb-2">
                <i class="fas fa-image"></i>
                <input
                  type="text"
                  id="vaultForm-url"
                  class="form-control validate"
                  placeholder="Image URL"
                  v-model="newVault.img"
                >
              </div>
              <button class="btn" type="submit">Add vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>

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
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
    }
  },
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
<template>
  <div class="container-fluid bg-size">
    <navbar></navbar>
    <!-- TITLE ROW -->
    <div class="row">
      <div class="col-12 mb-1">
        <h1>My Keeps:</h1>
      </div>
    </div>

    <!-- ADD FORM BUTT -->
    <div class="row mb-3">
      <div class="col-12 d-flex justify-content-center">
        <button type="button" class="btn" data-toggle="modal" data-target="#add-keep">Add Keep</button>
      </div>
    </div>

    <!-- ADD KEEP MODAL -->
    <div
      class="modal fade"
      tabindex="-1"
      id="add-keep"
      role="dialog"
      aria-labelledby="add-keep-label"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header text-center align-items-center">
            <h4>Add Keep</h4>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body mx-3">
            <form @submit.prevent="addKeep">
              <div class="md-form mb-2">
                <i class="fas fa-tag"></i>
                <input
                  type="text"
                  id="keepForm-name"
                  class="form-control validate"
                  placeholder="Name"
                  v-model="newKeep.name"
                >
              </div>
              <div class="md-form mb-2">
                <i class="fas fa-align-justify"></i>
                <input
                  type="text"
                  id="keepForm-desc"
                  class="form-control validate"
                  placeholder="Description"
                  v-model="newKeep.description"
                >
              </div>
              <div class="md-form mb-2">
                <i class="fas fa-image"></i>
                <input
                  type="text"
                  id="keepForm-url"
                  class="form-control validate"
                  placeholder="Image URL"
                  v-model="newKeep.img"
                >
              </div>
              <div>
                <p class="mb-0">Private</p>
                <input type="checkbox" v-model="newKeep.isPrivate">
              </div>
              <button class="btn" type="submit">Add Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- USER KEEPS -->
    <div class="row">
      <div
        v-for="userKeep in userKeeps"
        class="col-3-lg col-12-sm d-flex justify-content-center"
        :key="userKeep.id"
      >
        <div class="card mb-2 mr-2" style="width: 16rem">
          <div class="card-header d-flex justify-content-start">
            <h4>{{userKeep.name}}</h4>
            <i class="fas fa-trash hover" @click="deleteKeep(userKeep.id)"></i>
          </div>
          <img class="card-img-top hover" :src="userKeep.img">
          <div class="card-body d-flex justify-content-center">
            <i class="far fa-eye hover">: {{userKeep.views}}</i>
            <i class="fas fa-camera-retro ml-3">: {{userKeep.vaultAdds}}</i>
            <!-- <i class="fas fa-plus-square ml-3 hover" onclick="showAddToVault"></i> -->
            <!-- ADD TO VAULT DROPDOWN -->
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
                  @click="addKeepToVault(vault.id, userKeep)"
                >{{vault.name}}</a>
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
  name: "UserKeeps",
  data() {
    return {
      showAddKeep: false,
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: 0
      },
      showAddToVault: false
      // creator:{
      //   if(userKeep.userId == user.id)
      // },
    };
  },
  mounted() {
    this.$store.dispatch("getKeepsByUserId");
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addKeep() {
      if (this.newKeep.isPrivate) {
        this.newKeep.isPrivate = 1;
      }
      this.$store.dispatch("addKeep", this.newKeep);
    },
    deleteKeep(userKeepId) {
      this.$store.dispatch("deleteKeep", userKeepId);
    },
    addKeepToVault(vaultId, keep) {
      debugger;
      let payload = {
        vk: {
          vaultId,
          keepId: keep.id
        },
        keep
      };
      this.$store.dispatch("addKeepToVault", payload);
    }
  },
  components: {
    Navbar
  }
};
</script>

<style>
.btn {
  background-color: #7de2d1;
}
</style>
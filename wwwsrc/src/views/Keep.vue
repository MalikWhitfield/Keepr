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
            <!-- SHOWN ON HOVER -->
            <div class="hover-wrapper">
              <i class="far fa-eye hover-show img-info bottom-left">: {{activeKeep.views}}</i>
              <i
                class="fas fa-camera-retro ml-3 hover-show img-info bottom-right"
              >: {{activeKeep.keeps}}</i>
              <!-- END OF SHOW ON HOVER -->
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
                  @click="addKeepToVault(vault.id)"
                >{{vault.name}}</a>
              </div>
            </div>
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
  methods: {
    addKeepToVault(vaultId) {
      let payload = {
        vk: {
          vaultId,
          keepId: this.activeKeep.id
        },
        keep: this.activeKeep
      };
      this.$store.dispatch("addKeepToVault", payload);
    },
    editKeepViews() {
      let payload = {
        id: this.activeKeep.id,
        img: this.activeKeep.img,
        isPrivate: this.activeKeep.isPrivate,
        userId: this.activeKeep.userId,
        shares: this.activeKeep.shares,
        views: this.activeKeep.views + 1,
        keeps: this.activeKeep.keeps
      };
      this.$store.dispatch("editKeep", payload);
    },
    editKeepKeeps() {
      let payload = {
        id: this.activeKeep.id,
        img: this.activeKeep.img,
        isPrivate: this.activeKeep.isPrivate,
        userId: this.activeKeep.userId,
        shares: this.activeKeep.shares,
        views: this.activeKeep.views,
        keeps: this.activeKeep.keeps + 1
      };
      this.$store.dispatch("editKeep", payload);
    }
  },
  components: {
    Navbar
  }
};
</script>

<style>
.activeKeepImg {
  max-width: 75vw;
  max-height: 75vh;
}

.hover-wrapper:hover .hover-show {
  display: block;
}
.hover-wrapper .hover-show {
  display: none;
}
</style>
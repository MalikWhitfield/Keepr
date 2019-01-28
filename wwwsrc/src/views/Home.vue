<template>
  <div class="home bg-color bg-size container-fluid">
    <navbar></navbar>
    <div class="row">
      <div class="col-12">
        <h1>Welcome To Keepr!</h1>
      </div>
    </div>

    <!-- KEEPs -->
    <div class="d-flex justify-content-center">
      <div class="card-columns" style="width: 95%">
        <!-- <div class="col-12"></div> -->
        <div v-for="keep in keeps" :key="keep.id">
          <div class="col pl-0 pr-0">
            <div class="card">
              <!-- <div class="card-header d-flex justify-content-start">
                <h6>{{keep.name}}</h6>
              </div>-->
              <div class="hover-wrapper">
                <img
                  class="card-img-top hover card-images"
                  @click="$router.push({name: 'Keep', params: {keepId: keep.id}})"
                  :src="keep.img"
                >
                <!-- <div class="card-body d-flex justify-content-center"> -->
                <i class="far fa-eye hover-show img-info bottom-left">: {{keep.views}}</i>
                <i
                  class="fas fa-camera-retro ml-3 hover-show img-info bottom-right"
                >: {{keep.keeps}}</i>
              </div>
              <!-- ADD TO VAULT DROPDOWN-->
              <!-- <div class="dropdown col-1-sm ml-2">
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
                      @click="addKeepToVault(vault.id, keep)"
                    >{{vault.name}}</a>
                  </div>
              </div>-->
              <!-- </div> -->
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
  name: "home",
  mounted() {
    this.$store.dispatch("getAllKeeps");
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addKeepToVault(vaultId, keep) {
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
.bottom-left {
  position: absolute;
  bottom: 8px;
  left: 16px;
}
.bottom-right {
  position: absolute;
  bottom: 8px;
  right: 16px;
}
.bg-size {
  height: 100vh;
}

.img-info {
  background-color: rgba(255, 255, 255, 0.452);
  border-radius: 2px;
  color: black;
}

.hover-wrapper:hover .hover-show {
  display: block;
}
.hover-wrapper .hover-show {
  display: none;
}

@media (min-width: 580px) {
  .card-columns {
    -webkit-column-count: 2;
    -moz-column-count: 2;
    column-count: 2;
  }
}
@media (min-width: 48em) {
  .card-columns {
    -webkit-column-count: 3;
    -moz-column-count: 3;
    column-count: 3;
  }
}
@media (min-width: 62em) {
  .card-columns {
    -webkit-column-count: 4;
    -moz-column-count: 4;
    column-count: 4;
  }
}
@media (min-width: 75em) {
  .card-columns {
    -webkit-column-count: 5;
    -moz-column-count: 5;
    column-count: 5;
  }
}
</style>
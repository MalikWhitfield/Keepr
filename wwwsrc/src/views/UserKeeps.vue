<template>
  <div class="container-fluid">
    <navbar></navbar>
    <!-- TITLE ROW -->
    <div class="row">
      <div class="col-12">
        <h1>My Keeps:</h1>
      </div>
    </div>

    <!-- ADD FORM BUTT -->
    <div class="row d-flex justify-content-center mb-2">
      <div class="col-12">
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
              <button class="btn" type="submit">Add Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- USER KEEPS -->
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <div v-for="userKeep in userKeeps" :key="userKeep.id">
          <div class="card mb-2 mr-2" style="width: 16rem">
            <div class="card-header d-flex justify-content-start">
              <h1>{{userKeep.name}}</h1>
            </div>
            <img class="card-img-top hover" :src="userKeep.img">
            <div class="card-body d-flex justify-content-center">
              <i class="far fa-eye">: {{userKeep.views}}</i>
              <i class="fas fa-camera-retro ml-3">: {{userKeep.vaultAdds}}</i>
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
  name: "",
  data() {
    return {
      showAddKeep: false,
      newKeep: {
        name: "",
        descripton: "",
        img: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getKeepsByUserId");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
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
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
        <button class="btn" onclick="showAddKeep">Add Keep</button>
      </div>
    </div>

    <!-- ADD KEEP FORM -->
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
      showAddKeep: false
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
  methods: {},
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
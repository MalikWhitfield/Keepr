<template>
  <div class>
    <div class="row nav-background d-flex justify-content-space-between justify-content-end">
      <nav class="navbar col-12-sm col-12-lg navbar navbar-expand-lg navbar-light">
        <a class="btn" href="home">Home</a>
        <router-link class="btn" :to="{name: 'userprofile', params: {userId: user._id}}">My Profile</router-link>
        <button v-if="user._id">Login</button>
        <button v-if="!user._id" class="btn hover" @click="logout">Logout</button>
      </nav>
    </div>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      loggedIn: false
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style>
.btn {
  color: #fffafb;
}

.nav-background {
  background-color: #339989;
}
</style>
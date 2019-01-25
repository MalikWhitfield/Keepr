<template>
  <div class>
    <div class="row nav-background">
      <div class="col-12">
        <nav
          class="navbar navbar navbar-expand-lg navbar-light align-items-center d-flex justify-content-between"
        >
          <!-- KEEPR BUTTON -->
          <div class="col-2">
            <a class="nav-btn">Keepr</a>
          </div>
          <!-- ALL BUTTONS BESIDES KEEPR -->
          <div class="col-10 d-flex justify-content-end">
            <router-link class="nav-btn mr-3" :to="{name: 'home'}">Home</router-link>
            <router-link class="nav-btn mr-3" :to="{name: 'Dashboard'}">{{user.name}}Dashboard</router-link>
            <router-link v-if="!user.id" class="nav-btn hover" :to="{name: 'login'}">Login</router-link>
            <a v-if="user.id" class="nav-btn hover" @click="logout">Logout</a>
          </div>
        </nav>
      </div>
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
.nav-btn {
  color: #fffafb;
}

.nav-background {
  background-color: #339989;
}
</style>
<template>
  <div class>
    <div class="row nav-background">
      <div class="col-12">
        <nav
          class="navbar nav-position navbar navbar-expand-lg navbar-light align-items-center d-flex justify-content-between"
        >
          <!-- KEEPR BUTTON -->
          <div class="col-2">
            <a
              class="nav-btn logo-font hover"
              style="color: white"
              @click="$router.push({name: 'home'})"
            >Keepr</a>
          </div>

          <!-- COLLAPSE CONTENT-->
          <div class="collapse navbar-collapse" id="navBarContent"> 
            <ul class="navbar">
            <li class="nav-item active">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navBarContent" aria-expanded="false" aria-label="Toggle navbar" @click="$router.push({name: 'home'})">Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navBarContent" aria-expanded="false" aria-label="Toggle navbar" @click="$router.push({name: 'Dashboard'})">Dashboard</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navBarContent" aria-expanded="false" aria-label="Toggle navbar" @click="$router.push({name: 'login'})">Login</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navBarContent" aria-expanded="false" aria-label="Toggle navbar" @click="logout" v-if="user.id">Logout</a>
            </li>
            </ul>
          </div>
          <!-- ALL BUTTONS BESIDES KEEPR -->
          <!-- <div class="col-10 d-flex justify-content-end">
            <router-link class="nav-btn mr-3" :to="{name: 'home'}">Home</router-link>
            <router-link class="nav-btn mr-3" :to="{name: 'Dashboard'}">{{user.username}} Dashboard</router-link>
            <router-link v-if="!user.id" class="nav-btn hover" :to="{name: 'login'}">Login</router-link>
            <a v-if="user.id" class="nav-btn hover" style="color: white" @click="logout">Logout</a>
          </div> -->
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

.logo-font {
  font-family: "Permanent Marker", cursive;
  color: white;
}

.nav-background {
  background-color: #339989;
}
</style>
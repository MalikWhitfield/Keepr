<template>
  <div>
    <div class="row nav-background">
      <div class="col-12">
        <nav
          class="navbar navbar-expand-lg navbar-light align-items-center d-flex justify-content-between"
          fixed="top"
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
          <!-- <button
            class="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navBarContent"
            aria-controls="navBarContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          ></button>
          <div class="collapse navbar-collapse d-flex justify-content-end" id="navBarContent">
            <ul class="navbar-nav">
              <li class="nav-item">
                <a class="nav-link nav-btn" href="#" @click="$router.push({name: 'home'})">Home</a>
              </li>
              <li class="nav-item">
                <a
                  class="nav-link nav-btn"
                  href="#"
                  @click="$router.push({name: 'Dashboard'})"
                >Dashboard</a>
              </li>
              <li class="nav-item">
                <a class="nav-link nav-btn" href="#" @click="$router.push({name: 'login'})">Login</a>
              </li>
              <li class="nav-item">
                <a class="nav-link nav-btn" href="#" @click="logout" v-if="user.id">Logout</a>
              </li>
            </ul>
          </div>-->
          <!-- ALL BUTTONS BESIDES KEEPR -->
          <div class="col-10 d-flex justify-content-end">
            <a
              class="nav-btn mr-3 hover"
              @click="$router.push({name: 'home'})"
              style="color: white"
            >Home</a>
            <a
              class="nav-btn mr-3 hover"
              @click="$router.push({name: 'Dashboard'})"
              style="color: white"
            >{{user.username}} Dashboard</a>
            <a v-if="!user.id" class="nav-btn hover" @click="$router.push({name: 'login'})">Login</a>
            <a v-if="user.id" class="nav-btn hover" style="color: white" @click="logout">Logout</a>
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

.logo-font {
  font-family: "Permanent Marker", cursive;
  color: white;
}

.nav-background {
  background-color: #00927c;
}
</style>
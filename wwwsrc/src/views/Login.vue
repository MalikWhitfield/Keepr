<template>
  <div class="login">
    <navbar></navbar>
    <form v-if="loginForm" @submit.prevent="loginUser" class="mt-2">
      <div>
        <input type="email" v-model="creds.email" placeholder="Email">
      </div>
      <div>
        <input type="password" v-model="creds.password" placeholder="Password">
      </div>
      <button class="btn btn-secondary mt-1" type="submit">Login</button>
    </form>
    <form v-else @submit.prevent="register" class="mt-2">
      <div>
        <input type="text" v-model="newUser.username" placeholder="Name">
      </div>
      <div>
        <input type="email" v-model="newUser.email" placeholder="Email">
      </div>
      <div>
        <input type="password" v-model="newUser.password" placeholder="Password">
      </div>
      <button class="btn btn-secondary mt-1" type="submit">Create Account</button>
    </form>
    <div @click="loginForm = !loginForm">
      <p v-if="loginForm">No account Click to Register</p>
      <p v-else>Already have an account click to Login</p>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/NavBar.vue";
export default {
  name: "login",
  mounted() {
    //checks for valid session
  },
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    }
  },
  components: {
    Navbar
  }
};
</script>
<template>
  <div class="container-fluid bg-size">
    <navbar></navbar>
    <img :src="activeKeep.img">
    <h3>{{activeKeep.name}}</h3>
    <p>{{activeKeep.description}}</p>
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
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {},
  components: {
    Navbar
  }
};
</script>

<style>
</style>
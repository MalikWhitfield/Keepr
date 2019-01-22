<template>
    <div class="">
        <div class="row navbar nav-background justify-content-space-between">
            <nav class="col-12-sm col-12-lg navbar navbar-expand-lg navbar-light bg-light">
                <a href="">Navbar</a>
                <a class="ml-3" href="">My Vaults</a>
                <button v-if="user._id">Login</button>
                <button v-if="!user._id" class="btn btn-outline-light hover" @click="logout">Logout</button>
            </nav>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Navbar',
        data() {
            return {
                loggedIn: false
            }
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
    }

</script>

<style>


</style>
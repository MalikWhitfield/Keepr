<template>
    <div class="container fluid">
        <nav class="navbar navbar-expand-lg navbar-light nav-background">
            <a href="#" @click="$router.push({name: 'home'})">Home</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent"
                aria-controls="navbarContent" aria-expanded="false" aria-label="Toggle navbar"></button>
            <div class="collapse navbar-collapse" id="navbarContent">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link nav-btn" href="#" @click="$router.push({name: 'home'})">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link nav-btn" href="#" @click="$router.push({name: 'Dashboard'})">Dashboard</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link nav-btn" href="#" @click="$router.push({name: 'login'})">Login</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link nav-btn" href="#" @click="logout" v-if="user.id">Logout</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</template>

<script>
    export default {
        name: 'Nav',
        data() {
            return {

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
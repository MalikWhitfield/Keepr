<template>
    <div class="navbar">
        <div class="row nav-background justify-content-space-between">
            <div class="col-12 navbar navbar-expand-lg navbar-light bg-light">
                <a href="">Navbar</a>
                <a class="ml-3" href="">My Vaults</a>
            </div>
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
                this.$store.state.user;
            }
        },
        methods: {}
    }

</script>

<style>


</style>
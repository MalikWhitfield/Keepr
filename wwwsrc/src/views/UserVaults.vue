<template>
    <div class="">
        <navbar></navbar>
        <div class="row">
            <div class="col-12">
                <div v-for="vault in vaults" :key="vault.id">
                    <h5>
                        {{vault.name}}
                    </h5>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from "@/components/NavBar.vue"
    export default {
        name: "UserVaults",
        data() {
            return {

            }
        },
        props: ['userId'],
        mounted() {
            // if (!this.keeps.length) {
            //     this.$store.dispatch()
            // }
        },
        computed: {
            vaults() {
                return this.$store.state.vaults
            },
            user() {
                return this.$store.state.viewedUser
            }
        },
        methods: {},
        components: {
            Navbar
        }
    }

</script>

<style>


</style>
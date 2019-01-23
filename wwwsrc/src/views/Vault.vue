<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
                    <div class="card mb-2" style="width: 16rem">
                        <div class="card-header d-flex justify-content-start">
                            <h1>{{vaultKeep.name}}</h1>
                        </div>
                        <img class="card-img-top hover" :src="vaultKeep.img">
                        <div class="card-body d-flex justify-content-center">
                            <i class="far fa-eye">: {{vaultKeep.views}}</i>
                            <i class="fas fa-camera-retro ml-3">: {{vaultKeep.vaultAdds}}</i>
                            <i class="fas fa-plus-square ml-3"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from "@/components/NavBar.vue"
    export default {
        name: '',
        data() {
            return {
                vaultId: this.$route.params.vaultId
            }
        },
        props: ["vaultId"],
        mounted() {
            this.$store.dispatch('getKeepsByVaultId', this.vaultId)
        },
        computed: {
            vaultKeeps() {
                this.$store.state.vaultkeeps
            },

        },
        methods: {
            deleteVaultKeep(vaultKeepId) {
                this.$store.dispatch('deleteVaultKeep', vaultKeepId)
            }
        },
        components: {
            Navbar
        }
    }

</script>

<style>


</style>
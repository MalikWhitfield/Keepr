<template>
    <div class="container-fluid">
        <navbar></navbar>
        <div class="row">
            <div class="col-12">
                <h1 @click="keepstuff">My Keeps:</h1>
            </div>
            <div class="row">
                <div class="col-12 d-flex justify-content-center">
                    <div v-for="keep in keeps" :key="keep.id">
                        <div class="card mb-2" style="width: 16rem">
                            <div class="card-header d-flex justify-content-start">
                                <h1>{{keep.name}}</h1>
                            </div>
                            <img class="card-img-top hover" :src="keep.img">
                            <div class="card-body d-flex justify-content-center">
                                <i class="far fa-eye">: {{keep.views}}</i>
                                <i class="fas fa-camera-retro ml-3">: {{keep.vaultAdds}}</i>
                                <i class="fas fa-plus-square ml-3"></i>
                            </div>
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

            }
        },
        mounted() {
            this.$store.dispatch('getKeepsByUserId')
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            }
        },
        methods: {
            keepstuff() {
                console.log(this.keeps)
            }
        },
        components: {
            Navbar
        }
    }

</script>

<style>


</style>
import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import UserVaults from './views/UserVaults.vue'
import Vault from './views/Vault.vue'
import UserKeeps from './views/UserKeeps.vue'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/myvaults',
      name: 'UserVaults',
      component: UserVaults
    },
    {
      path: '/vault/:vaultId',
      name: 'Vault',
      component: Vault
    },
    {
      path: '/myKeeps',
      name: 'UserKeeps',
      component: UserKeeps
    }
  ]
})

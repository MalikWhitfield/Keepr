import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 10000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    viewedUser: {},
    vaults: [],
    keeps: [],
    userKeeps: [],
    vaultKeeps: [],
    activeVault: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault
    },
    setViewedUser(state, viewedUser) {
      state.viewedUser = viewedUser
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'home' })
          commit('setUser', {})
        })
    },

    //KEEPS
    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    addKeep({ commit, dispatch }, newKeep) {
      api.post('keeps', newKeep)
        .then(server => {
          // dispatch('getKeeps')
          dispatch('getKeepsByUserId')
        })
    },
    getKeepsByUserId({ commit, dispatch }, userId) {
      api.get('keeps/user')
        .then(res => {
          commit('setUserKeeps', res.data)
        })
    },
    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get('vaultkeeps/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    deleteVaultKeep({ commit, dispatch }, vaultKeepId) {
      api.delete('keeps/' + vaultKeepId)
        .then(res => {
          dispatch('getKeeps')
        })
    },

    //VAULTS
    getUserVaults({ commit, dispatch }, userId) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    addVault({ commit, dispatch }, newVault) {
      api.post('vaults', newVault)
        .then(res => {
          dispatch('getUserVaults', res.data)
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      debugger
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getUserVaults', res.data)
        })
    }

  }
})
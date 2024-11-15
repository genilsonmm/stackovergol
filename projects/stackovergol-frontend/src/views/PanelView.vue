<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light shadow p-3 mb-5 bg-body rounded">
    <div class="container-fluid">
      <img src="@/assets/logo.jpg" alt="logo" width="60" />
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <RouterLink class="nav-link active" to="/panel">Início</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink class="nav-link active" to="/players">Jogadores</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink class="nav-link active" to="/events">Partidas</RouterLink>
          </li>
          <li class="nav-item">
            <a href="#" @click="logOut" class="nav-link active" to="/events">Sair</a>
          </li>
        </ul>
        <label class="user-info">Olá<br>{{utils.userSession().name}}</label>
        <img class="user-photo" src="@/assets/default-user.png" width="60" alt="user photo" />
      </div>
    </div>
  </nav>
  <div class="container">
    <RouterView />
  </div>

</template>

<script setup>
import { useRouter } from 'vue-router'
import utils from '@/utils/utils'
const router = useRouter()

function logOut(){
  localStorage.removeItem('user')
  router.push('/')
}

</script>

<style scoped>
.user-info{
  font-size: 13px;
}
</style>
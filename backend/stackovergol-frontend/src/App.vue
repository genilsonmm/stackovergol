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
            <RouterLink class="nav-link active" to="/">Início</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink class="nav-link active" to="/players">Jogadores</RouterLink>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
              aria-expanded="false">
              Jogos
            </a>
            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
              <li><a class="dropdown-item" href="#">Action</a></li>
              <li><a class="dropdown-item" href="#">Another action</a></li>
              <li>
                <hr class="dropdown-divider">
              </li>
              <li><a class="dropdown-item" href="#">Something else here</a></li>
            </ul>
          </li>
        </ul>
        <img class="user-photo" src="@/assets/default-user.png" width="60" alt="user photo" />
      </div>
    </div>
  </nav>

  <Loading :visibility="false"/>

  <div class="container">
    <RouterView />
    <notifications />
  </div>



</template>
<script setup lang="ts">
  import { RouterLink, RouterView } from 'vue-router'
  import Loading from '@/components/common/Loading.vue'

</script>

<style scoped>
nav {
  background-color: red
}

.user-photo {
  border: 1px solid #00000000;
}
</style>

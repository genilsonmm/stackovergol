<template>

  <main class="form-signin w-100 m-auto">
    <form>
      <img src="@/assets/logo.jpg" alt="logo" width="60" />
      <h1 class="h3 mb-3 fw-normal">StackOverGol - Login</h1>

      <div class="form-floating">
        <input type="email" class="form-control" v-model="user.username"  id="floatingInput" placeholder="name@example.com">
        <label for="floatingInput">Usuário</label>
      </div>
      <div class="form-floating">
        <input type="password" class="form-control" v-model="user.password" id="floatingPassword" placeholder="Password">
        <label for="floatingPassword">Senha</label>
      </div>
      <!--
      <div class="form-check text-start my-3">
        <input class="form-check-input" type="checkbox" value="remember-me" id="flexCheckDefault">
        <label class="form-check-label" for="flexCheckDefault">
          Remember me
        </label>
      </div>-->
      <button @click="signIn" class="btn btn-primary w-100 py-2" type="button">Acessar</button>
      <p class="mt-5 mb-3 text-body-secondary">© 2024–2024</p>
    </form>
  </main>

</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'

import authService from "@/services/authService"
import notification from "@/services/notificationService";

const user = ref({ username: '', password: '' })
const router = useRouter()

function signIn() {
  authService.authenticate(user.value)
    .then((response) => {
      if (response.data.token) {
        localStorage.setItem('user', JSON.stringify(response.data))
        router.push('/panel')
      }
    })
    .catch((error) => {
      console.log(error)
      notification.error(
        "Error",
        "Falha ao autenticar usuário"
      );
    })
}

onMounted(() => {
  const authenticatedUser = localStorage.getItem('user')
  if (authenticatedUser) {
    router.push('/panel')
  }
})

</script>
<style scoped>
form{
  margin-top: 80px;
}
.form-signin {
  max-width: 330px;
  padding: 1rem;
}

.form-signin .form-floating:focus-within {
  z-index: 2;
}

.form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}

.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>

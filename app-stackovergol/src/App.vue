<script setup>
import { RouterLink, RouterView } from 'vue-router'

const onConfirmRefresh = function (event) {
  event.preventDefault();
  return event.returnValue = "Se você confirmar os dados serão perdidos. Deseja confirmar?";
}

window.addEventListener("beforeunload", onConfirmRefresh, { capture: true });
</script>

<template>
  <header class="center">
    <img alt="Vue logo" class="logo" src="@/assets/logo.jpg" width="125" height="125" />

    <div class="wrapper">
      <nav>
        <RouterLink to="/">StackOverGol</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
.center {
  text-align: center;
}
</style>

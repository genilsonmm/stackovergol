<template>
  <h1>Dashboard</h1>
  <div class="container">
    <div class="row">
      <div class="col">
        <div class="card text-center">
          <div class="card-header">
            Próxima partida
          </div>
          <div class="card-body">
            <h5 class="card-title">{{ nextEvent }}</h5>
            <p class="card-text">Confirme sua participação até às 16h do dia {{ nextEvent }}</p>
            <div>
              <a href="#" class="btn btn-success">Estou dentro</a>
              <a href="#" class="btn btn-danger ml-5">Estou fora</a>
            </div>
          </div>
          <div class="card-footer text-body-secondary">
            Falta(m) {{ remainingDate }} dia(s)
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col" style="text-align: center;">
        <button class="btn btn-outline-warning">Adicionar manualmente</button>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-6">
        <div class="card">
          <div class="card-header">
            Confirmados
          </div>
          <div class="card-body">
            Confirmados
          </div>
        </div>
      </div>
      <div class="col-6">
        <div class="card">
          <div class="card-header">
            Fora
          </div>
          <div class="card-body">
            Fora
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script setup>
import { ref, onMounted } from 'vue'
import eventService from '@/services/eventService'
import utils from '@/utils/utils'
import notification from "@/services/notificationService";
const nextEvent = ref()
const remainingDate = ref()

onMounted(() => {
  eventService.getNext()
    .then((response) => {
      if(response.data != ""){
      const fullDate = response.data.date
      remainingDate.value = utils.remainingDate(fullDate)
      const date = utils.formatterdDate(fullDate)
      nextEvent.value = date
      } else {
        notification.error(
            "Eventos",
            "Sem eventos disponíveis"
          );
      }
    })
    .catch((error) => {
      console.log('error', error)
    })
})

</script>
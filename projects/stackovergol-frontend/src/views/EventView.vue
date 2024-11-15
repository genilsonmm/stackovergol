<template>
  <div id="header">
    <h3>Eventos</h3>
  </div>

  <hr />

  <div class="card">
    <div class="card-body">
      <h5>Novo evento</h5>
      <div class="date-button-container">
        <input class="form-control" type="date" v-model="event" />
        <button class="btn btn-success" @click="create">Criar</button>
      </div>
    </div>
  </div>

  <hr />
  <h5>Eventos anteriores</h5>
  <table class="table table-striped table-hover">
    <thead>
      <th>#</th>
      <th>Data do evento</th>
      <th></th>
    </thead>
    <tbody>
      <tr v-for="(item, index) in events" :key="item.eventId">
        <td>{{ index + 1 }}</td>
        <td>{{ getFormattedDate(item.date) }}</td>
        <td>
          <button class="btn btn-outline-warning">
            <i class="bi bi-person-gear"></i>
            Ver detalhes
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
import { ref, onMounted } from "vue";
import eventService from "@/services/eventService";
import notification from "@/services/notificationService";
import utils from '@/utils/utils'

const events = ref(null);
const event = ref('')

onMounted(() => {
  getAllEvents()
});

function getAllEvents(){
  eventService
    .getAll()
    .then((response)=>{
      events.value = response.data
    })
    .catch((error)=>{
        console.log('error', error)
    })
}

function getFormattedDate(date) {
  return utils.formatterdDate(date)
}

function create() {
  if (event.value) {
    eventService
      .add({ date: event.value })
      .then((response) => {
        getAllEvents()
        notification.success("Partida", "Partida criada com sucesso!");
      })
      .catch((error) => {
        if (error.detail) {
          notification.error(
            "Error",
            "Falha ao enviar os dados. " + error.detail
          );
        }
      });
  } else {
    notification.error("Erro", "Selecione uma data válida");
  }
}
</script>

<style>
.date-button-container {
  display: flex;
}

.date-button-container button {
  margin-left: 5px;
}
</style>

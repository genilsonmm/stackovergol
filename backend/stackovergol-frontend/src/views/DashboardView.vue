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
              <a href="#" @click="iamIn(userSession.id)" class="btn btn-success">Estou dentro</a>
              <a href="#" @click="iamOut(userSession.id)" class="btn btn-danger ml-5">Estou fora</a>
            </div>
          </div>
          <div class="card-footer text-body-secondary">
            Falta(m) {{ remainingDate }} dia(s)
          </div>
        </div>
      </div>
    </div>
    <div v-if="userSession?.role == utils.ROLES.ADMIN" class="row mt-2">
      <div class="col" style="text-align: center;">
        <button @click="openPlayerSelection" class="btn btn-outline-warning">Adicionar manualmente</button>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-6">
        <div class="card">
          <div class="card-header">
            Confirmados
          </div>
          <div class="card-body">
            <ul class="list-group">
              <li v-for="item in event?.players.in" :key="item.playerId" class="list-group-item">
                <div class="player-container" data-bs-toggle="dropdown" aria-expanded="false">
                  <div>
                    <i class="bi bi-emoji-sunglasses-fill in"></i>
                    {{ item.name }}
                  </div>
                  <span class="badge text-bg-primary rounded-pill">{{ item.rating }}</span>
                </div>
                <ul class="dropdown-menu">
                  <li><a v-if="userSession.id == item.playerId || userSession.role == utils.ROLES.ADMIN" @click="iamOut(item.playerId)" class="dropdown-item" href="#"><i class="bi bi-emoji-dizzy-fill"></i> Estou fora</a></li>
                  <li><a class="dropdown-item" href="#"><i class="bi bi-person-lines-fill"></i> Ver Perfil</a></li>
                  <li><a v-if="userSession.role == utils.ROLES.ADMIN" @click="removePlayer(item.playerId)" class="dropdown-item" href="#"><i class="bi bi-trash3"></i> Remover</a></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-6">
        <div class="card">
          <div class="card-header">
            Fora
          </div>
          <div class="card-body">
            <ul class="list-group">
              <li v-for="item in event?.players.out" :key="item.playerId" class="list-group-item">
                <div class="player-container" data-bs-toggle="dropdown" aria-expanded="false">
                  <div>
                    <i class="bi bi-emoji-dizzy-fill out"></i>
                    {{ item.name }}
                  </div>
                  <span class="badge text-bg-primary rounded-pill">{{ item.rating }}</span>
                </div>
                <ul class="dropdown-menu">
                  <li><a @click="iamIn(item.playerId)" class="dropdown-item" href="#"><i class="bi bi-emoji-sunglasses-fill"></i> Estou dentro</a></li>
                  <li><a class="dropdown-item" href="#"><i class="bi bi-person-lines-fill"></i> Ver Perfil</a></li>
                  <li v-if="userSession.role == utils.ROLES.ADMIN"><a @click="removePlayer(item.playerId)" class="dropdown-item" href="#"><i class="bi bi-trash3"></i> Remover</a></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <SelectPlayerModal ref="selectPlayerModal" @updateListInAndOutEvent="addPlayersManually" />
  </div>

</template>

<script setup>
import { ref, onMounted } from 'vue'
import eventService from '@/services/eventService'
import utils from '@/utils/utils'
import notification from "@/services/notificationService"
import SelectPlayerModal from "@/components/modal/SelectPlayerModal.vue"

const nextEvent = ref()
const remainingDate = ref()
const event = ref()
const userSession = ref()

//exposed
const selectPlayerModal = ref(null)

onMounted(() => {
  getMatch()
  userSession.value = utils.userSession()
})

function openPlayerSelection(){
  selectPlayerModal.value.open(event.value.players)
}

function getMatch() {
  eventService.getNext()
    .then((response) => {
      if (response.data != "") {
        event.value = response.data
        remainingDate.value = utils.remainingDate(event.value.date)
        const date = utils.formatterdDate(event.value.date)
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
}

function iamIn(playerId) {
  const playerEvent = getPlayerEvent(true, playerId)
  register(playerEvent)
}

function iamOut(playerId) {
  const playerEvent = getPlayerEvent(false, playerId)
  register(playerEvent)
}

function addPlayersManually(player){
  iamIn(player.playerId)
}

function register(playerEvent) {
  eventService.registerPlayerInEvent(playerEvent)
    .then((response) => {
      const msg = playerEvent.iAmIn ? 'Participação registrada com sucesso!' : 'Registro de não participação registrado com sucesso!'
      getMatch()
      notification.success('Eventos', msg)
    })
    .catch((error) => {
      notification.error(
        "Eventos",
        "Não foi possível registrar no evento"
      );
    })
}

function removePlayer(playerId){
  eventService.removePlayerInEvent(playerId)
  .then((response)=>{
      getMatch()
      notification.success('Eventos', 'Jogador removido da partida com sucesso!')
  })
  .catch((error)=>{
    console.log(error)
    if(error.response.status == 403){
      notification.error(
        "Eventos",
        "Você não tem permissão para remover o jogador da partida"
      );
    } else {
      notification.error(
        "Eventos",
        "Não foi possível remover o jogador da partida: " + error
      );
    }

  })
}

function getPlayerEvent(inOrOut, playerId) {
  const eventId = event.value.eventId
  return {
    playerId,
    eventId,
    iAmIn: inOrOut
  }
}

</script>
<style scoped>
.player-container {
  display: flex;
  justify-content: space-between;
}

.list-group-item:hover {
  cursor: pointer;
  background-color: #ecf0ee;
}

.in {
  color: #39a379;
}

.out {
  color: #fd0101;
}
</style>
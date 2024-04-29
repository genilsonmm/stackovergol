<template>
  <div id="header">
    <h3>Jogadores</h3>
    <button class="btn btn-success" @click="openNewPlayerModal">
      <i class="bi bi-person-fill-add"></i>
      Adicionar
    </button>
  </div>

  <hr>
  <table class="table table-striped table-hover">
    <thead>
      <tr>
        <th></th>
        <th>Nível</th>
        <th>Nome</th>
        <th>Tipo</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(player, index) in players" :key="index">
        <td></td>
        <td>
          <span class="badge rounded-pill bg-danger">
            {{ player.rating }}
            <span class="visually-hidden">unread messages</span>
          </span>
        </td>
        <td>{{ player.name }}</td>
        <td v-if="player.isMember">
          <i class="bi bi-person-heart"></i>
          Mensalista
        </td>
        <td v-else>
          <i class="bi bi-person-fill-lock"></i>
          Convidado
        </td>
        <td>
          <button class="btn btn-outline-warning" @click="openEditModal(player)">
            <i class="bi bi-person-gear"></i>
            Editar
          </button>
        </td>
      </tr>
    </tbody>
  </table>
  <EditPlayerModal ref="editPlayerModal" :selectedPlayer="selectedPlayer" @updatePlayerEvent="updatePlayer" />
  <NewPlayerModal ref="newPlayerModal" @createPlayerEvent="createPlayer" />
</template>

<script setup>
import { onMounted, ref } from 'vue';
import playerService from '@/services/playerService'

import EditPlayerModal from '@/components/modal/EditPlayerModal.vue'
import NewPlayerModal from '@/components/modal/NewPlayerModal.vue'

import notification from '@/services/notificationService'

const players = ref([])
const selectedPlayer = ref({
  name: '',
  username: '',
  password: '',
  email: '',
  phone: '',
  rating: 0,
  isMember: false,
  isAdmin: false
})

//Exposed
const editPlayerModal = ref(null)
const newPlayerModal = ref(null)

onMounted(() => {
  getAllPlayers()
})

function getAllPlayers() {
  playerService.getAll()
    .then((response) => {
      players.value = response.data
    })
    .catch(error => console.log(error))
}

function updatePlayer(player) {

  console.log(player)

  playerService.update(player)
    .then((response) => {
      console.log(response)
      if (response.status === 200) {
        notification.success("Atualização", "Jogador atualizado com sucesso")
        editPlayerModal.value.close()
        getAllPlayers()
      } else {
        alert('Não foi possível atualizar os dados do usuário. ' + response.data)
      }
    })
    .catch(error => alert('Falha ao enviar os dados. ' + error))
}

function createPlayer(player) {
  playerService.add(player)
    .then((response) => {
      if (response.status === 200) {
        if (response.data > 0) {
          notification.success("Cadastro", "Jogador cadastrado com sucesso")
          newPlayerModal.value.close()
          getAllPlayers()
        }
      } else {
        alert('Não foi possível cadastrar o usuário. ' + response.data)
      }
    })
    .catch(error => alert('Falha ao enviar os dados. ' + error))
}

function openEditModal(player) {
  selectedPlayer.value = { ...player }
  editPlayerModal.value.open()
}

function openNewPlayerModal() {
  newPlayerModal.value.open()
}
</script>

<style scoped>
#header {
  display: flex;
  justify-content: space-between;
}
</style>

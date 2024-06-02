<template>
    <div id="selectPlayerModal" class="modal fade">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Selecionar jogador</h5>
                    <button type="button" @click="close" class="btn-close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <ul class="list-group">
                        <li v-for="item in players" :key="item.playerId" class="list-group-item">
                            <div class="player-container" data-bs-toggle="dropdown" aria-expanded="false">
                                <div>
                                    <i class="bi bi-emoji-dizzy-fill out"></i>
                                    {{ item.name }}
                                </div>
                                <span class="badge text-bg-primary rounded-pill">4</span>
                            </div>                       
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" @click="close">Fechar</button>
                    <button type="button" class="btn btn-primary" @click="add">Adicionar</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script setup>
import { Modal } from 'bootstrap'
import { ref, onMounted, defineExpose } from 'vue'
import playerService from "@/services/playerService";

const modalInstance = ref(null)
const isOpen = ref(false)
const playersSelected = ref([])
const players = ref([])

defineExpose({ open, close })
const emitEvent = defineEmits(['updateListInAndOutEvent'])

onMounted(() => {
    modalInstance.value = new Modal(document.getElementById("selectPlayerModal"), {
        target: 'selectPlayerModal',
        backdrop: "static",
    });

    if (modalInstance.value) {
        close()
    }

    players.value = playerService.getAll()
        .then((response)=>{
            players.value = response.data
        })
        .catch((error)=>{

        })
})

function close() {
    isOpen.value = false
    modalInstance.value.hide()
}

function open() {
    isOpen.value = true
    modalInstance.value.show()
}

function add() {
    emitEvent('updateListInAndOutEvent', playersSelected.value)
}

</script>

<style scoped>
.player-container {
  display: flex;
  justify-content: space-between;
}

.list-group-item{
    margin-top: 5px;
}

.list-group-item:hover {
  background-color: #ecf0ee;
}
</style>
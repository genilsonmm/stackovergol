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
                            <div class="player-container" aria-expanded="false">
                                <div>
                                    <span class="badge text-bg-primary rounded-pill">{{ item.rating }}</span>
                                    {{ item.name }}
                                </div>
                                <button type="button" class="btn btn-success" @click="add(item)">
                                    <i class="bi bi-plus"></i>
                                </button>
                            </div>                       
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" @click="close">Fechar</button>
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
})

function close() {
    isOpen.value = false
    modalInstance.value.hide()
}

function open(playersInAndOut) {
    isOpen.value = true
    modalInstance.value.show()

    const inS = playersInAndOut.in.map(p => {
        return p.playerId
    })

    const outS = playersInAndOut.out.map(p => {
        return p.playerId
    })

    const ids = [...inS, ...outS]

    players.value = playerService.getAllExcept(ids)
        .then((response)=>{
            players.value = response.data
        })
        .catch((error)=>{

        })
}

function add(player) {
    players.value = players.value.filter(p=>p.playerId != player.playerId)
    emitEvent('updateListInAndOutEvent', player)
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
<template>
    <div id="editPlayerModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Configurações do jogador</h5>
                    <button type="button" @click="close" class="btn-close"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <label for="exampleInputEmail1">Nome</label>
                            <input type="email" class="form-control" v-model="props.selectedPlayer.name"
                                aria-describedby="emailHelp" placeholder="Enter email">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <label for="exampleInputPassword1">Login</label>
                            <input type="text" class="form-control" v-model="props.selectedPlayer.username"
                                placeholder="Login">
                        </div>
                        <div class="col-6">
                            <label for="exampleInputPassword1">Password</label>
                            <input type="password" class="form-control" v-model="props.selectedPlayer.password" placeholder="Password">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <label for="exampleInputPassword1">E-mail</label>
                            <input type="text" class="form-control" v-model="props.selectedPlayer.email"
                                placeholder="E-mail">
                        </div>
                        <div class="col-6">
                            <label for="exampleInputPassword1">Telefone</label>
                            <input type="phone" class="form-control" v-model="props.selectedPlayer.phone" v-mask-phone.br placeholder="Telefone">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label for="exampleInputPassword1">Rating
                                <span class="badge rounded-pill bg-danger">
                                    {{ props.selectedPlayer?.rating }}
                                    <span class="visually-hidden">unread messages</span>
                                </span>

                            </label>
                            <input type="range" class="form-range" min="1" max="5" step="1"
                                v-model="props.selectedPlayer.rating">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <input type="checkbox" v-model="props.selectedPlayer.isMember" class="form-check-input">
                            <label class="form-check-label" for="exampleCheck1">&nbsp Membro</label>
                        </div>
                        <div class="col-4">
                            <input type="checkbox" v-model="props.selectedPlayer.isAdmin" class="form-check-input">
                            <label class="form-check-label" for="exampleCheck1">&nbsp Administrador</label>
                        </div>
                        <div class="col-4">
                            <input type="checkbox" v-model="props.selectedPlayer.isGoalkeeper" class="form-check-input">
                            <label class="form-check-label label" for="exampleCheck1">&nbsp Goleiro</label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" @click="close">Fechar</button>
                    <button type="button" class="btn btn-primary" @click="update">Atualizar</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>

import { ref, defineProps, defineEmits, onMounted, defineExpose  } from 'vue'
import { Modal } from 'bootstrap';

const emitEvent = defineEmits(['updatePlayerEvent'])
const props = defineProps(['selectedPlayer'])
const modalInstance = ref(null);
const isOpen = ref(false)

onMounted(() => {
    modalInstance.value = new Modal(document.getElementById("editPlayerModal"), {
        target: 'editPlayerModal',
        backdrop: "static",
    });

    if (modalInstance.value) {
        close()
    }
})

function close(){
    isOpen.value = false
    modalInstance.value.hide()
}

function open(){
    isOpen.value = true
    modalInstance.value.show()
}

function update(){
    const playerToUpdate = {...props.selectedPlayer}
    if(playerToUpdate.password == undefined){
        playerToUpdate.password = ''
    }
    emitEvent('updatePlayerEvent', playerToUpdate)
}

defineExpose({
    open,
    isOpen,
    close
})

</script>

<style scoped>
@media screen and (max-width: 510px) {
    .label{
        font-size: 14px;
    }
}
</style>
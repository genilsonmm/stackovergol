<template>
    <div id="newPlayerModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Adicionar novo jogador</h5>
                    <button type="button" @click="close" class="btn-close"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <label for="exampleInputEmail1">Nome*</label>
                            <input type="email" class="form-control" v-model="playerData.name"
                                aria-describedby="emailHelp" placeholder="Enter email">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <label for="exampleInputPassword1">Login*</label>
                            <input type="text" class="form-control" v-model="playerData.username"
                                placeholder="Login">
                        </div>
                        <div class="col-6">
                            <label for="exampleInputPassword1">Password*</label>
                            <input type="password" class="form-control" v-model="playerData.password"
                                placeholder="Password">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <label for="exampleInputPassword1">E-mail</label>
                            <input type="text" class="form-control" v-model="playerData.email"
                                placeholder="E-mail">
                        </div>
                        <div class="col-6">
                            <label for="exampleInputPassword1">Telefone</label>
                            <input type="phone" class="form-control" v-model="playerData.phone" v-mask-phone.br placeholder="Telefone">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <label for="exampleInputPassword1">Rating
                                <span class="badge rounded-pill bg-danger">
                                    {{ playerData.rating }}
                                    <span class="visually-hidden">unread messages</span>
                                </span>

                            </label>
                            <input type="range" class="form-range" min="1" max="5" step="1"
                                v-model="playerData.rating">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <input type="checkbox" v-model="playerData.isMember" class="form-check-input">
                            <label class="form-check-label" for="exampleCheck1">Membro</label>
                        </div>
                        <div class="col-6">
                            <input type="checkbox" v-model="playerData.isAdmin" class="form-check-input">
                            <label class="form-check-label" for="exampleCheck1">Administrador</label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" @click="close">Fechar</button>
                    <button type="button" class="btn btn-primary" @click="save">Adicionar</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>

import { ref, defineEmits, onMounted, defineExpose } from 'vue'
import { Modal } from 'bootstrap';

const emitEvent = defineEmits(['createPlayerEvent'])
const modalInstance = ref(null);
const playerData = ref(getClearPlayerData())
const isOpen = ref(false)

onMounted(() => {
    modalInstance.value = new Modal(document.getElementById("newPlayerModal"), {
        target: 'newPlayerModal',
        backdrop: "static",
    });

    if (modalInstance.value) {
        close()
    }
})

function close(){
    playerData.value = getClearPlayerData()
    isOpen.value = false
    modalInstance.value.hide()
}

function open(){
    isOpen.value = true
    modalInstance.value.show()
}

function save(){
    emitEvent('createPlayerEvent', playerData.value)
}

defineExpose({
    open,
    isOpen,
    close
})


function getClearPlayerData(){
    return {
        playerId: 0,
        name: '',
        username: '',
        password: '',
        email: '',
        phone: '',
        rating: 1,
        isMember: false,
        isAdmin: false
    }
}
</script>
<template>
    <div v-if="visibility" id="loading-content">
        <div class="d-flex justify-content-center">
            <span class="loader"></span>
        </div>
    </div>
</template>
<script setup>
import { onMounted, ref } from 'vue'
import EventBus from '@/conf/EventBus'

const visibility = ref(false)

onMounted(()=>{
    EventBus.$on('loading', (isOpen) => {
        visibility.value = isOpen      
    });
})

</script>
<style scoped> 

#loading-content{
    position: fixed;
    background-color: #999797;
    opacity: .7;
    top: 0; 
    width: 100%; 
    height: 100%;
    z-index: 200;
    overflow: hidden;
}

.loader{
    display: block;
    position: absolute;
    top:50%;
    height: 30px;
    width: 140px;
    background-image: 
    linear-gradient(#FFF 20px, transparent 0), 
    linear-gradient(#FFF 20px, transparent 0), 
    linear-gradient(#FFF 20px, transparent 0), 
    linear-gradient(#FFF 20px, transparent 0);
    background-repeat: no-repeat;
    background-size: 20px auto;
    background-position: 0 0, 40px 0, 80px 0, 120px 0;
    animation: pgfill 1s linear infinite;
  }
  @keyframes pgfill {
    0% {   background-image: linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0); }
    25% {   background-image: linear-gradient(#FF3D00 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0); }
    50% {   background-image: linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FF3D00 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0); }
    75% {   background-image: linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FF3D00 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0); }
    100% {   background-image: linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FFF 20px, transparent 0), linear-gradient(#FF3D00 20px, transparent 0); }
  }
  
</style>
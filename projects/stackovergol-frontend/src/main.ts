import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import VueMask from '@devindex/vue-mask'; 
import Notifications from '@kyvg/vue3-notification'

import App from './App.vue'
import router from './router'

import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-icons/font/bootstrap-icons.min.css"
import "bootstrap/dist/js/bootstrap.bundle.min.js"
import "bootstrap/dist/js/bootstrap.min.js"
import "bootstrap"


const app = createApp(App)


app.use(createPinia())
app.use(router)

app.use(VueMask); 
app.use(Notifications); 

app.mount('#app')

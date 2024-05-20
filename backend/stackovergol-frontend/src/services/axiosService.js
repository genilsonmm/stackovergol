import axios from 'axios'
import EventBus from '../conf/EventBus'
import notification from '@/services/notificationService'

axios.defaults.baseURL = "http://localhost:5079/api"

function init() {
    let authenticatedUser = localStorage.getItem('user')
    console.log('authenticatedUser', authenticatedUser)

    if (authenticatedUser) {
        let token = JSON.parse(authenticatedUser).token
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    }
}

// Mais exemplos
//https://medium.com/@rodin.dev/making-the-most-of-axios-in-vue-js-interceptors-request-cancellation-and-more-fa40dbc44b55
// Request interceptor
axios.interceptors.request.use((config) => {
    // Modify the request config here
    //console.log('Request: ', config)
    init()
    EventBus.$emit('loading', true);
    return config
})

// Response interceptor
axios.interceptors.response.use((response) => {
    // Handle the response here
    console.log('Response: ', response)
    EventBus.$emit('loading', false);

    if (response.data.status && (response.data.status !== 200 || response.data.status !== 201)) {
        return Promise.reject(response.data)
    }
    return response
}, (error) => {
    // Handle errors here
    //console.log('Response error: ', error)
    EventBus.$emit('loading', false);
    if (error.code === 'ERR_NETWORK') {
        notification.error("Conexão", "Falha de conexão com o servidor")
    }

    if (error.response.status == 401) {
        let authenticatedUser = localStorage.getItem('user')
        if (!authenticatedUser) {
            notification.error("Autorização", "Usuário sem autorização")
            setInterval(() => {
                window.location.href = "/sign-in"
            }, 5)
        } else {
            window.location.href = "/sign-in"
        }
    }

    return Promise.reject(error)
})
init()
export default { axios: axios }
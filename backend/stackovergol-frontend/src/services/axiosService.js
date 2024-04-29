import axios from 'axios'
import EventBus from '../conf/EventBus'

// Mais exemplos
//https://medium.com/@rodin.dev/making-the-most-of-axios-in-vue-js-interceptors-request-cancellation-and-more-fa40dbc44b55
// Request interceptor
axios.interceptors.request.use((config) => {
    // Modify the request config here
    console.log('Request: ', config)
    EventBus.$emit('loading', true);
    return config
})

// Response interceptor
axios.interceptors.response.use((response) => {
    // Handle the response here
    console.log('Response: ', response)
    EventBus.$emit('loading', false);
    return response
}, (error) => {
    // Handle errors here
    console.error(error)
    EventBus.$emit('loading', false);
    return Promise.reject(error)
})

export default axios
import service from './axiosService.js'
const uri = `/event`

export default {

    async getAll() {
        return await service.axios.get(uri)
    },
    async getNext(){
        return await service.axios.get(`${uri}/next`)
    },
    async add(event) {
        return await service.axios.post(`${uri}/next`, event)
    },
    async update(event) {
        return await service.axios.put(uri, event)
    }
}
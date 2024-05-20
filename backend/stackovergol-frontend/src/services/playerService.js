import service from './axiosService.js'
const uri = `/player`

export default {

    async getAll() {
        return await service.axios.get(uri)
    },
    async add(player) {
        return await service.axios.post(uri, player)
    },
    async update(player) {
        return await service.axios.put(uri, player)
    }
}
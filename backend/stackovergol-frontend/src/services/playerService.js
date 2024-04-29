import axios from './axiosService.js'
const uri = "http://localhost:5079/api/player"

export default {

    async getAll() {
        return await axios.get(uri)
    },
    async add(player) {
        return await axios.post(uri, player)
    },
    async update(player) {
        return await axios.put(uri, player)
    }
}
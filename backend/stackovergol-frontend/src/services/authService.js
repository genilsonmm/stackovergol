import service from './axiosService.js'
const uri = `/auth`

export default {
    
    async authenticate(user){
        return await service.axios.post(uri, user)
    }
}
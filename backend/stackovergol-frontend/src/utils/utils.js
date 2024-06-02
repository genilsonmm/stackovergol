const USER_LOCAL_STORAGE_KEY = 'user'

function formatterdDate(date){
    return (date.toLocaleString('pt-BR')).split(' ')[0]
}

function getUserSession(){
    let authenticatedUser = localStorage.getItem(USER_LOCAL_STORAGE_KEY)
    if(authenticatedUser){
        return JSON.parse(authenticatedUser)
    } else {
        return authenticatedUser
    }
}

export default{
    userSession: getUserSession,
    formatterdDate: formatterdDate,
    remainingDate(date){
        const dataArray = formatterdDate(date).split('/')
        const nextDate = new Date(`${dataArray[2]}-${dataArray[1]}-${dataArray[0]}`)
        const today = new Date()
        const timeDiff = Math.abs(nextDate.getTime() - today.getTime())
        const remaining = Math.ceil(timeDiff / (1000 * 3600 * 24))
        return nextDate.getTime() > today.getTime() ? remaining : 0 
    },
    ROLES: {
        ADMIN:'ADMIN',
        MEMBER:'MEMBER',
        GUEST:'GUEST'
    }
}
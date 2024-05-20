function formatterdDate(date){
    return (date.toLocaleString('pt-BR')).split(' ')[0]
}

export default{
    formatterdDate: formatterdDate,
    remainingDate(date){
        const dataArray = formatterdDate(date).split('/')
        const nextDate = new Date(`${dataArray[2]}-${dataArray[1]}-${dataArray[0]}`)
        const today = new Date()
        const timeDiff = Math.abs(nextDate.getTime() - today.getTime())
        const remaining = Math.ceil(timeDiff / (1000 * 3600 * 24))
        return remaining < 0 ? 0 : remaining 
    }
}
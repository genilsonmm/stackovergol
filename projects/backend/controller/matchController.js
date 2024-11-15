const playerRepository = require('../models/playerModel')

module.exports = (router) => {
    const name = '/match'
    router.get(name, (req, res)=>{
        const players = playerRepository.findAll()
        res.json(players)
    })
}
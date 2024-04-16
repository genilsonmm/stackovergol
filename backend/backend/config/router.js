const express = require('express')
const router = express.Router()

const footballMatch = require('../controller/matchController')
footballMatch(router)

module.exports = router
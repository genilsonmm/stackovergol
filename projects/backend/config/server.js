require('dotenv').config()
const express = require('express')
const db = require("../config/db");

const server = express()

const cors = require('cors')
server.use(cors())
server.use(express.json())

db.sync(() => console.log(`Banco de dados conectado: ${process.env.DB_NAME}`));

const PORT = process.env.PORT || 3000
server.listen(PORT, ()=>{console.log('Server running...')})

module.exports = server
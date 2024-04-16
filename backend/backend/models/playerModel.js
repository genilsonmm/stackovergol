const sequelize = require("sequelize")
const db = require('../config/db')

module.exports = db.define("player", {
  id: {
    type: sequelize.INTEGER.UNSIGNED,
    primaryKey: true,
    autoIncrement: true,
    allowNull: false,
  },
  name: {
    type: sequelize.STRING(100),
    allowNull: false,
  },
  email: {
    type: sequelize.STRING(60),
    allowNull: false,
    unique: true,
  },
  phone: {
    type: sequelize.STRING(60),
    allowNull: true,
    unique: true,
  },
  member: {
    type: sequelize.BOOLEAN,
    allowNull: false
  },
});
const _ = require('lodash');
const fs = require("fs");

function initPlayers() {
    const playersString = fs.readFileSync('./players.json')
    const players = JSON.parse(playersString)
    return players.sort(function (a, b) { return a.rating - b.rating })
}

function createTeams(numberOfTeams){
    let teams = []
    for(let i=0; i < numberOfTeams; i++){
        teams.push({team: i+1, sum: 0, players: []})
    }
    return teams
}

function createMatch(numberOfTeams, playerPerTeam, players){
    const teams = createTeams(numberOfTeams)
    const matchPlayer = [...players]
    console.log(teams)

    for (let i = 0; i < (numberOfTeams*playerPerTeam); i++) {

        for(let j=0; j < teams.length; j++){

            if(teams[j].players.length > 0){                
                teams[j].sum = _.sumBy(teams[j].players, 'rating')
            } 
            
            let player = matchPlayer.pop()
            if(player == undefined && teams[j].players.length === playerPerTeam){
                break;
            } else if(player == undefined){
                player = {
                    name: 'Jogador',
                    rating: 1    
                }
            }

            teams[j].players.push(player)
            teams[j].sum = _.sumBy(teams[j].players, 'rating')
        }
    }

    for(let t of teams){
        console.log(t)
    }

   labance(teams)

    for(let t of teams){
        t.sum = _.sumBy(t.players, 'rating')
        console.log(t)
    }
}

function labance(teams){
    let max = 0
    let min = 0
    let gap = 0
    for(let i=0; i<teams.length; i++){
        if(i==0){
            max = teams[i].sum
            min = max
        } else {

            if(teams[i].sum > max){
                min = max
                max = teams[i].sum
            } else {
                min = teams[i].sum
            }
        }
    }

    gap = (max - min) - 1

    const strongTeam = teams.find(t=>t.sum == max)
    const weakTeam = teams.find(t=>t.sum == min)
    let theBestGap = false 

    while(!theBestGap){
        const found = strongTeam.players.find(p=>p.rating == gap)
        if(found == null){
            gap += 1
        } else {
            theBestGap = true
        }
    }

    let indexPlayertToSwitchFromStrongTeam = strongTeam.players.findIndex(p=>p.rating == gap)
    const playertToSwitchFromWeakTeam = {...weakTeam.players.pop()}
    weakTeam.players.push({...strongTeam.players[indexPlayertToSwitchFromStrongTeam]});
    strongTeam.players[indexPlayertToSwitchFromStrongTeam] = playertToSwitchFromWeakTeam

    console.log('-------------Após o labance-------------------------------')
}

const shuffle = (array) => { 
    for (let i = array.length - 1; i > 0; i--) { 
      const j = Math.floor(Math.random() * (i + 1)); 
      [array[i], array[j]] = [array[j], array[i]]; 
    } 
    return array; 
  };


function createMatch2(numberOfTeams, playerPerTeam, players){
    const teams = createTeams(numberOfTeams)
    let matchPlayer = shuffle(players)
    console.log(matchPlayer)

    for (let i = 0; i < (numberOfTeams*playerPerTeam); i++) {
        for(let j=0; j < teams.length; j++){

            if(teams[j].players.length > 0){                
                teams[j].sum = _.sumBy(teams[j].players, 'rating')
            } 
            
            let player = matchPlayer.pop()
            
            if(player == undefined || teams[j].players.length === playerPerTeam){
                break;
            } else if(player == undefined){
                player = {
                    name: 'Jogador',
                    rating: 1    
                }
            }

            teams[j].players.push(player)
            teams[j].sum = _.sumBy(teams[j].players, 'rating')
        }
    }

    for(let t of teams){
        console.log(t)
    }
    console.log(matchPlayer)
}


const players = initPlayers()
createMatch(4,6,players)





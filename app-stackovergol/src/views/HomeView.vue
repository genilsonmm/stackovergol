<template>

  <div class="container">
    <div class="row mt-2">
      <div class="col center">
        <button @click="cleanData" class="btn btn-danger">Reiniciar Campeonato</button>
      </div>
    </div>
    <hr>
    <div class="row center">
      <h4>Campeonato</h4>
      <p>{{ new Date().toDateString('pt-BR') }}</p>
    </div>
    <div class="row">
      <div class="mt-2 match-table" v-for="(match, index) in teams" :key="index">
        <div v-if="index < 6" class="card shadow-lg p-4 mb-4 bg-white" style="width: 40rem">
          <span class="position-absolute top-0  translate-middle badge rounded-pill bg-danger">
            Jogo {{ index + 1 }}
          </span>
          <div class="card-body">
            <div>
              <button @click="registerMatch(match.id, match.team1.id, 1)" class="btn btn-success mr-5">+</button>
              <button @click="registerMatch(match.id, match.team1.id, -1)" class="btn btn-danger mr-5">-</button>
              <span class="team-name mr-5"> {{ match.team1.name }}</span>
              <span class="gol ml-5">{{ match.team1.gol }}</span>

              <span class="mr-5">x</span>

              <span class="gol ml-5">{{ match.team2.gol }}</span>
              <span class="team-name mr-5">{{ match.team2.name }}</span>
              <button @click="registerMatch(match.id, match.team2.id, 1)" class="btn btn-success mr-5">+</button>
              <button @click="registerMatch(match.id, match.team2.id, -1)" class="btn btn-danger">-</button>
            </div>
          </div>
          <div class="crono">
            <div><button class="btn btn-primary" @click="startCrono(match.id)">Iniciar</button></div>
            <div>
              <h4 v-if="crono.matchId === match.id">{{ crono.time }}</h4>
              <h4 v-else>{{ match.time }}</h4>
            </div>
            <div><button class="btn btn-warning" @click="stopCrono(match.id)">Parar</button></div>
          </div>
        </div>
      </div>
      <h4 class="mt-2">Finais</h4>
      <div class="mt-2 match-table">
        <div class="card shadow-lg p-4 mb-4 bg-white" style="width: 40rem">
          <span class="position-absolute top-0  translate-middle badge rounded-pill bg-danger">
            Final
          </span>
          <div class="card-body">
            <div>
              <button @click="registerMatch(teams[6].id, teams[6].team1.id, 1, false)"
                class="btn btn-success mr-5">+</button>
              <button @click="registerMatch(teams[6].id, teams[6].team1.id, -1, false)"
                class="btn btn-danger mr-5">-</button>
              <span class="team-name mr-5"> {{ teams[6].team1.name }}</span>
              <span class="gol ml-5">{{ teams[6].team1.gol }}</span>

              <span class="mr-5">x</span>

              <span class="gol ml-5">{{ teams[6].team2.gol }}</span>
              <span class="team-name mr-5">{{ teams[6].team2.name }}</span>
              <button @click="registerMatch(teams[6].id, teams[6].team2.id, 1)" class="btn btn-success mr-5">+</button>
              <button @click="registerMatch(teams[6].id, teams[6].team2.id, -1)" class="btn btn-danger">-</button>
            </div>
          </div>
          <div class="crono">
              <div><button class="btn btn-primary" @click="startCrono(8)">Iniciar</button></div>
              <div>
                <h4 v-if="crono.matchId === 8">{{ crono.time }}</h4>
                <h4 v-else>{{ JSON.parse(JSON.stringify(crono.time)) }}</h4>
              </div>
              <div><button class="btn btn-warning" @click="stopCrono(8)">Parar</button></div>
            </div>
        </div>
      </div>
      <div class="mt-2 match-table">
        <div class="card shadow-lg p-4 mb-4 bg-white" style="width: 40rem">
          <span class="position-absolute top-0  translate-middle badge rounded-pill bg-danger">
            Terceiro Lugar
          </span>
          <div class="card-body">
            <button @click="registerMatch(teams[7].id, teams[7].team1.id, 1)" class="btn btn-success mr-5">+</button>
            <button @click="registerMatch(teams[7].id, teams[7].team1.id, -1)" class="btn btn-danger mr-5">-</button>
            <span class="team-name mr-5"> {{ teams[7].team1.name }}</span>
            <span class="gol ml-5">{{ teams[7].team1.gol }}</span>

            <span class="mr-5">x</span>

            <span class="gol ml-5">{{ teams[7].team2.gol }}</span>
            <span class="team-name mr-5">{{ teams[7].team2.name }}</span>
            <button @click="registerMatch(teams[7].id, teams[7].team2.id, 1)" class="btn btn-success mr-5">+</button>
            <button @click="registerMatch(teams[7].id, teams[7].team2.id, -1)" class="btn btn-danger">-</button>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col center">
        <button @click="updateStatistics" class="btn btn-primary">Atualizar Estatísticas</button>
      </div>
    </div>
    <hr>
    <h4 class="mt-2">Goleiros</h4>
    <div class="mt-2 match-table">
      <div class="card shadow-lg p-4 mb-4 bg-white" style="width: 40rem">
        <span class="position-absolute top-0  translate-middle badge rounded-pill bg-danger">
          Gols sofridos
        </span>
        <div class="card-body">
          <div class="row mx-auto">
            <div style="text-align: center;">
              <button @click="updateGoalkeeper(goalkeeper1.id, 1)" class="btn btn-success mr-5">+</button>
              <button @click="updateGoalkeeper(goalkeeper1.id, -1)" class="btn btn-danger mr-5">-</button>
              <input v-model="goalkeeper1.name" class="mr-5" placeholder="Goleiro 1" type="text">
              <span class="gol ml-5">{{ goalkeeper1.gols }}</span>
            </div>
            <div style="text-align: center;">
              <span class="gol ml-5">{{ goalkeeper2.gols }}</span>
              <input v-model="goalkeeper2.name" class="mr-5" placeholder="Goleiro 2" type="text">
              <button @click="updateGoalkeeper(goalkeeper2.id, 1)" class="btn btn-success mr-5">+</button>
              <button @click="updateGoalkeeper(goalkeeper2.id, -1)" class="btn btn-danger">-</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <hr>
    <h4 class="mt-2">Estatísticas</h4>
    <div class="row mt-2">
      <div class="col-md-6">
        <div class="card p-2" style="background-color: #6a7ff7;">
          <h5>{{ statistics[0].name }}</h5>
          <div class="container text-center">
            <div class="row">
              <div class="col">
                Vitórias
                <h6>{{ statistics[0].win }}</h6>
              </div>
              <div class="col">
                Empates
                <h6>{{ statistics[0].draw }}</h6>
              </div>
              <div class="col">
                Derrotas
                <h6>{{ statistics[0].loss }}</h6>
              </div>
              <div class="col">
                Gol Pro
                <h6>{{ statistics[0].gols_pro }}</h6>
              </div>
              <div class="col">
                Gol Cont
                <h6>{{ statistics[0].gols_con }}</h6>
              </div>
              <div class="col">
                Balanço
                <h6>{{ statistics[0].gols_pro - statistics[0].gols_con }}</h6>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-6">
        <div class="card p-2 card-mt" style="background-color: #95f4c5;">
          <h5>{{ statistics[1].name }}</h5>
          <div class="container text-center">
            <div class="row">
              <div class="col">
                Vitórias
                <h6>{{ statistics[1].win }}</h6>
              </div>
              <div class="col">
                Empates
                <h6>{{ statistics[1].draw }}</h6>
              </div>
              <div class="col">
                Derrotas
                <h6>{{ statistics[1].loss }}</h6>
              </div>
              <div class="col">
                Gol Pro
                <h6>{{ statistics[1].gols_pro }}</h6>
              </div>
              <div class="col">
                Gol Cont
                <h6>{{ statistics[1].gols_con }}</h6>
              </div>
              <div class="col">
                Balanço
                <h6>{{ statistics[1].gols_pro - statistics[1].gols_con }}</h6>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-md-6">
        <div class="card p-2" style="background-color: #f9b877;">
          <h5>{{ statistics[2].name }}</h5>
          <div class="container text-center">
            <div class="row">
              <div class="col">
                Vitórias
                <h6>{{ statistics[2].win }}</h6>
              </div>
              <div class="col">
                Empates
                <h6>{{ statistics[2].draw }}</h6>
              </div>
              <div class="col">
                Derrotas
                <h6>{{ statistics[2].loss }}</h6>
              </div>
              <div class="col">
                Gol Pro
                <h6>{{ statistics[2].gols_pro }}</h6>
              </div>
              <div class="col">
                Gol Cont
                <h6>{{ statistics[2].gols_con }}</h6>
              </div>
              <div class="col">
                Balanço
                <h6>{{ statistics[2].gols_pro - statistics[2].gols_con }}</h6>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-6">
        <div class="card p-2 card-mt" style="background-color: #aaa9a9;">
          <h5>{{ statistics[3].name }}</h5>
          <div class="container text-center">
            <div class="row">
              <div class="col">
                Vitórias
                <h6>{{ statistics[3].win }}</h6>
              </div>
              <div class="col">
                Empates
                <h6>{{ statistics[3].draw }}</h6>
              </div>
              <div class="col">
                Derrotas
                <h6>{{ statistics[3].loss }}</h6>
              </div>
              <div class="col">
                Gol Pro
                <h6>{{ statistics[3].gols_pro }}</h6>
              </div>
              <div class="col">
                Gol Cont
                <h6>{{ statistics[3].gols_con }}</h6>
              </div>
              <div class="col">
                Balanço
                <h6>{{ statistics[3].gols_pro - statistics[3].gols_con }}</h6>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <hr>
    <h4>Ranking</h4>
    <div class="card">
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Pontos</th>
            <th scope="col">Time</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(team, index) in ranking" :key="index">
            <td>{{ team.points }}</td>
            <td>{{ team.name }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref, onMounted } from 'vue'
import _ from 'lodash'

const teams = reactive(getInitialTable())
let statistics = reactive([...getStatistics()])
let ranking = ref([])
const goalkeeper1 = ref({ id: 1, name: '', gols: 0 })
const goalkeeper2 = ref({ id: 2, name: '', gols: 0 })
const crono = reactive({ matchId: 0, time: "00:00:00" })
let timer = false
let minute = 0;
let second = 0;
let count = 0;

onMounted(() => {
  const data = localStorage.getItem('teams')
  const goalkeeper1Data = localStorage.getItem('goalkeeper1')
  const goalkeeper2Data = localStorage.getItem('goalkeeper2')
  if (data) {
    Object.assign(teams, JSON.parse(data))
  }

  if (goalkeeper1Data) {
    Object.assign(goalkeeper1.value, JSON.parse(goalkeeper1Data))
    Object.assign(goalkeeper2.value, JSON.parse(goalkeeper2Data))
  }
})

function startCrono(matchId) {
  timer = true
  crono.matchId = matchId
  stopWatch()
}

function stopCrono(matchId) {
  timer = false
  const match = teams.find(m => m.id === matchId)
  match.time = crono.time
  crono.matchId = 0
  minute = 0;
  second = 0;
  count = 0;
  localStorage.setItem('teams', JSON.stringify(teams))
}

function stopWatch() {
  if (timer) {
    count++;

    if (count == 100) {
      second++;
      count = 0;
    }

    if (second == 60) {
      minute++;
      second = 0;
    }

    if (minute == 60) {
      hour++;
      minute = 0;
      second = 0;
    }

    let minString = minute;
    let secString = second;
    let countString = count;


    if (minute < 10) {
      minString = "0" + minString;
    }

    if (second < 10) {
      secString = "0" + secString;
    }

    if (count < 10) {
      countString = "0" + countString;
    }

    crono.time = `${minString}:${secString}:${countString}`
    setTimeout(stopWatch, 10);
  }
}

function updateGoalkeeper(id, gol) {
  if (id === 1) {
    goalkeeper1.value.gols += gol
  } else {
    goalkeeper2.value.gols += gol
  }
  localStorage.setItem("goalkeeper1", JSON.stringify(goalkeeper1.value))
  localStorage.setItem("goalkeeper2", JSON.stringify(goalkeeper2.value))
}

function cleanData() {
  localStorage.clear('teams')
  window.location.reload()
}

function registerMatch(idMatch, idTeam, gol) {

  const match = teams.find(t => t.id == idMatch)
  const values = Object.keys(match)

  values.forEach(element => {
    const team = match[element]
    if (team.id == idTeam) {
      team.gol = team.gol + gol
    }
  });

  localStorage.setItem('teams', JSON.stringify(teams))
  updateStatistics()
}

function updateStatistics() {
  //Copia as propriedade de um obj para outro
  Object.assign(statistics, [...getStatistics()]);

  teams.forEach(match => {
    if (match.id !== 7 && match.id !== 8) {
      let team1 = match['team1']
      let team2 = match['team2']

      const statistics_t1 = statistics.find(t => t.id == team1.id)
      statistics_t1.gols_pro += team1.gol
      statistics_t1.gols_con += team2.gol

      const statistics_t2 = statistics.find(t => t.id == team2.id)
      statistics_t2.gols_pro += team2.gol
      statistics_t2.gols_con += team1.gol

      if (team1.gol > team2.gol) {
        statistics_t1.win += 1
        statistics_t2.loss += 1
      } else if (team2.gol > team1.gol) {
        statistics_t1.loss += 1
        statistics_t2.win += 1
      } else {
        statistics_t1.draw += 1
        statistics_t2.draw += 1
      }
    }
  })

  setRanking()
  setFinals()
}

function setRanking() {
  const rankingTemp = [...statistics]
  rankingTemp.forEach(t => {
    t['gol_balance'] = t.gols_pro - t.gols_con
    t['points'] = t.win * 3
    t['points'] += t.draw
  })

  ranking.value = _.sortBy(rankingTemp, ['win', 'draw', 'gol_balance', 'gols_pro']).reverse()
}

function setFinals() {
  const final = teams[6]
  const third = teams[7]

  //Final
  final.team1.id = ranking.value[0].id
  final.team1.name = ranking.value[0].name

  final.team2.id = ranking.value[1].id
  final.team2.name = ranking.value[1].name

  //Third
  third.team1.id = ranking.value[2].id
  third.team1.name = ranking.value[2].name

  third.team2.id = ranking.value[3].id
  third.team2.name = ranking.value[3].name
}

function getStatistics() {
  return [
    {
      id: 1,
      name: 'Time A',
      win: 0,
      loss: 0,
      draw: 0,
      gols_pro: 0,
      gols_con: 0
    },
    {
      id: 2,
      name: 'Time V',
      win: 0,
      loss: 0,
      draw: 0,
      gols_pro: 0,
      gols_con: 0
    },
    {
      id: 3,
      name: 'Time L',
      win: 0,
      loss: 0,
      draw: 0,
      gols_pro: 0,
      gols_con: 0
    },
    {
      id: 4,
      name: 'Time P',
      win: 0,
      loss: 0,
      draw: 0,
      gols_pro: 0,
      gols_con: 0
    }
  ]
}

function getInitialTable() {
  return [
    {
      id: 1,
      team1: { id: 1, name: 'Time A', gol: 0 },
      team2: { id: 2, name: 'Time V', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 2,
      team1: { id: 3, name: 'Time L', gol: 0 },
      team2: { id: 4, name: 'Time P', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 3,
      team1: { id: 1, name: 'Time A', gol: 0 },
      team2: { id: 4, name: 'Time P', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 4,
      team1: { id: 2, name: 'Time V', gol: 0 },
      team2: { id: 3, name: 'Time L', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 5,
      team1: { id: 2, name: 'Time V', gol: 0 },
      team2: { id: 4, name: 'Time P', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 6,
      team1: { id: 1, name: 'Time A', gol: 0 },
      team2: { id: 3, name: 'Time L', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 7,
      team1: { id: 1, name: 'Time 1', gol: 0 },
      team2: { id: 3, name: 'Time 2', gol: 0 },
      time: '00:00:00', ended: false
    },
    {
      id: 8,
      team1: { id: 1, name: 'Time 3', gol: 0 },
      team2: { id: 3, name: 'Time 4', gol: 0 },
      time: '00:00:00', ended: false
    }
  ]
}
</script>

<style scoped>
.center {
  text-align: center;
}

.match-table {
  display: flex;
  justify-content: center;
}

.team-name {
  font-size: 1.3rem;
}

.gol {
  font-size: 1.8rem;
  font-weight: 600;
}

.card-body {
  display: flex;
  justify-content: center;
  align-items: center;
}

.crono {
  display: flex;
  justify-content: space-between;
}

@media (max-width: 768px) {
  .card-mt {
    margin-top: 8px;
  }

  .team-name {
    font-size: .8rem;
  }
}
</style>

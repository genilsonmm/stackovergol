<template>
  <main>
    <div class="next-match">
      <div class="card w-100">
        <div class="card-body">
          <div class="button-container">
            <div class="next-match-info">
              <h4>Próximo jogo</h4>
              <h6>06/05/2024 às 19h</h6>
            </div>
            <button class="btn btn-success">Estou dentro</button>
            <button class="btn btn-danger">Estou fora</button>
          </div>
        </div>
      </div>
    </div>
    <div class="row-container">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Jogo anterior</h5>
          <h6>29/04/2024 às 19h</h6>
          <div>
            <div>
              <h5>Torneio</h5>
              <h6>Primeira fase</h6>
              <h6>A 3 X 1 B</h6>
              <h6>C 3 X 1 D</h6>
              <h6>Segunda fase</h6>
              <h6>A 3 X 1 D</h6>
              <h6>B 3 X 1 C</h6>
              <h6>Terceira fase</h6>
              <h6>B 3 X 1 D</h6>
              <h6>A 3 X 1 C</h6>
              <h6>Terceiro Lugar</h6>
              <h6>B 3 X 1 D</h6>
              <h6>Final</h6>
              <h6>A 3 X 1 C</h6>
            </div>
            <div></div>
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Últimas estatísticas</h5>
          <h6>Time campeão</h6>
          <h6>Vice campeão</h6>
          <h6>Terceiro lugar</h6>
          <h6>Artilheiro</h6>
          <h6>Melhor goleiro</h6>
        </div>
      </div>
    </div>
  </main>
</template>

<style scoped>
main {
  padding: 15px;
}
.card {
  width: 49%;
}
.next-match{
  margin-bottom: 10px;

}

.next-match .card{
  background-color: #f0c29d;
}

.row-container {
  width: 100%;
  border: 0px solid #000;
  margin: auto;

  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}

h5 {
  color: #e88026;
}

.button-container {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 0px;
  height: 40px;
}

.button-container button{
  margin-left: 5px;
}


@media (max-width: 900px) {
  .card {
    width: 100%;
    margin-top: 10px;
  }
  .next-match-info h4{
    font-size: 14px;
  }
  .next-match-info h6{
    font-size: 14px;
  }
}
</style>

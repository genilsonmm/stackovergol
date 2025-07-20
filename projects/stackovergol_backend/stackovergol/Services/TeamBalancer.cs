using stackovergol.Data.Entity;
using stackovergol.Dto;

namespace stackovergol.Services
{
    /// <summary>
    /// Algoritmo Heurísticas Genéticas
    /// </summary>
    public class TeamBalancer
    {
        private static readonly Random _rand = new();
        private List<List<PlayerTest>> _history = new();

        private const int PopulationSize = 50;
        private const int Generations = 200;
        private const double MutationRate = 0.1;

        public List<TeamTest> DrawTeams(List<PlayerTest> players)
        {
            if (players.Count != 24)
                throw new ArgumentException("É necessário fornecer exatamente 24 jogadores.");

            var population = GenerateInitialPopulation(players);
            for (int gen = 0; gen < Generations; gen++)
            {
                var scored = population.Select(p => (Teams: p, Score: Evaluate(p))).OrderBy(x => x.Score).ToList();
                var newPopulation = new List<List<TeamTest>>();

                // Elitismo: mantém os 2 melhores
                newPopulation.Add(scored[0].Teams);
                newPopulation.Add(scored[1].Teams);

                while (newPopulation.Count < PopulationSize)
                {
                    var parent1 = TournamentSelection(scored);
                    var parent2 = TournamentSelection(scored);
                    var child = Crossover(parent1, parent2);
                    if (_rand.NextDouble() < MutationRate)
                    {
                        child = Mutate(child);
                    }
                    newPopulation.Add(child);
                }

                population = newPopulation;
            }

            var best = population.OrderBy(p => Evaluate(p)).First();
            _history.AddRange(best.Select(t => t.Players));
            return best;
        }

        private List<List<TeamTest>> GenerateInitialPopulation(List<PlayerTest> players)
        {
            var population = new List<List<TeamTest>>();
            for (int i = 0; i < PopulationSize; i++)
            {
                var shuffled = players.OrderBy(_ => _rand.Next()).ToList();
                var teams = Enumerable.Range(0, 4)
                    .Select(j => new TeamTest
                    {
                        Name = $"Time {GetTeamName(j + 1)}",
                        Players = shuffled.Skip(j * 6).Take(6).ToList()
                    }).ToList();
                population.Add(teams);
            }
            return population;
        }

        private string GetTeamName(int index)
        {
            switch (index)
            {
                case 1:
                    return "A (Azul)";
                case 2:
                    return "V (Verde)";
                case 3:
                    return "L (Laranja)";
                case 4:
                    return "P (Preto)";
            }
            return "";
        }

        private List<TeamTest> TournamentSelection(List<(List<TeamTest> Teams, int Score)> population)
        {
            var tournament = new List<(List<TeamTest>, int)>();
            for (int i = 0; i < 5; i++)
            {
                var random = population[_rand.Next(population.Count)];
                tournament.Add(random);
            }
            return tournament.OrderBy(x => x.Item2).First().Item1;
        }

        private List<TeamTest> Crossover(List<TeamTest> parent1, List<TeamTest> parent2)
        {
            var players1 = parent1.SelectMany(t => t.Players).ToList();
            var players2 = parent2.SelectMany(t => t.Players).ToList();

            var childPlayers = new List<PlayerTest>();
            var used = new HashSet<string>();

            foreach (var p in players1)
            {
                if (!used.Contains(p.Name))
                {
                    childPlayers.Add(p);
                    used.Add(p.Name);
                }
            }

            foreach (var p in players2)
            {
                if (!used.Contains(p.Name))
                {
                    childPlayers.Add(p);
                    used.Add(p.Name);
                }
            }

            var finalPlayers = childPlayers.Take(24).OrderBy(_ => _rand.Next()).ToList();

            return Enumerable.Range(0, 4)
                .Select(i => new TeamTest
                {
                    Name = $"Time {i + 1}",
                    Players = finalPlayers.Skip(i * 6).Take(6).ToList()
                }).ToList();
        }

        private List<TeamTest> Mutate(List<TeamTest> teams)
        {
            var clone = teams.Select(t => new TeamTest
            {
                Name = t.Name,
                Players = t.Players.ToList()
            }).ToList();

            int teamAIndex = _rand.Next(4);
            int teamBIndex = (teamAIndex + _rand.Next(1, 4)) % 4;

            var teamA = clone[teamAIndex];
            var teamB = clone[teamBIndex];

            int playerAIndex = _rand.Next(6);
            int playerBIndex = _rand.Next(6);

            (teamA.Players[playerAIndex], teamB.Players[playerBIndex]) =
                (teamB.Players[playerBIndex], teamA.Players[playerAIndex]);

            return clone;
        }

        private int Evaluate(List<TeamTest> teams)
        {
            var ratings = teams.Select(t => t.TotalRating).ToList();
            int max = ratings.Max();
            int min = ratings.Min();
            int diversityPenalty = HasRepetition(teams) ? 20 : 0;
            return (max - min) + diversityPenalty;
        }

        public bool HasRepetition(List<TeamTest> teams)
        {
            foreach (var pastTeam in _history)
            {
                foreach (var team in teams)
                {
                    int overlap = team.Players.Count(p => pastTeam.Any(p2 => p2.Name == p.Name));
                    if (overlap >= 4) return true;
                }
            }
            return false;
        }
    }
    /// <summary>
    /// Algoritmo Simulated Annealing (SA)
    /// </summary>
    /// 
    /// 
    /*
    public class TeamBalancer
    {
        private static readonly Random _rand = new();
        private List<List<PlayerTest>> _history = new();

        public List<TeamTest> DrawTeams(List<PlayerTest> players)
        {
            if (players.Count != 24)
                throw new ArgumentException("É necessário fornecer exatamente 24 jogadores.");

            var bestSolution = InitialRandomTeams(players);
            int bestScore = Evaluate(bestSolution);

            double temperature = 1000;
            double coolingRate = 0.99;

            while (temperature > 0.1)
            {
                var newSolution = Mutate(bestSolution);
                int newScore = Evaluate(newSolution);

                if (newScore < bestScore || AcceptWorseSolution(bestScore, newScore, temperature))
                {
                    bestSolution = newSolution;
                    bestScore = newScore;
                }

                temperature *= coolingRate;
            }

            _history.AddRange(bestSolution.Select(t => t.Players));
            return bestSolution;
        }

        private List<TeamTest> InitialRandomTeams(List<PlayerTest> players)
        {
            var shuffled = players.OrderBy(_ => _rand.Next()).ToList();
            return Enumerable.Range(0, 4)
                .Select(i => new TeamTest
                {
                    Name = $"Time {i + 1}",
                    Players = shuffled.Skip(i * 6).Take(6).ToList()
                })
                .ToList();
        }

        private List<TeamTest> Mutate(List<TeamTest> teams)
        {
            var clone = teams.Select(t => new TeamTest
            {
                Name = t.Name,
                Players = t.Players.ToList()
            }).ToList();

            int teamAIndex = _rand.Next(4);
            int teamBIndex = (teamAIndex + _rand.Next(1, 4)) % 4;

            var teamA = clone[teamAIndex];
            var teamB = clone[teamBIndex];

            int playerAIndex = _rand.Next(6);
            int playerBIndex = _rand.Next(6);

            (teamA.Players[playerAIndex], teamB.Players[playerBIndex]) =
                (teamB.Players[playerBIndex], teamA.Players[playerAIndex]);

            return clone;
        }

        private int Evaluate(List<TeamTest> teams)
        {
            var ratings = teams.Select(t => t.TotalRating).ToList();
            int max = ratings.Max();
            int min = ratings.Min();
            int diversityPenalty = HasRepetition(teams) ? 20 : 0;
            return (max - min) + diversityPenalty;
        }

        private bool AcceptWorseSolution(int currentScore, int newScore, double temperature)
        {
            double probability = Math.Exp((currentScore - newScore) / temperature);
            return _rand.NextDouble() < probability;
        }

        public bool HasRepetition(List<TeamTest> teams)
        {
            foreach (var pastTeam in _history)
            {
                foreach (var team in teams)
                {
                    int overlap = team.Players.Count(p => pastTeam.Any(p2 => p2.Name == p.Name));
                    if (overlap >= 4) return true;
                }
            }
            return false;
        }
    }*/
}


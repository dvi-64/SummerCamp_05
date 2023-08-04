using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Statistic
    {
        private List<GameResult> _gameResults = new List<GameResult>();
        public Statistic()
        {

        }

        /// <summary>
        /// Загружает предварительно подготовленные результаты игр из задания (можно масштабировать на другие источники)
        /// </summary>
        public void LoadDefaultValues()
        {
            //Лузианна, поражение, победа, победа
            _gameResults.Add(new GameResult() { Hero = "Лузианна", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Лузианна", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Лузианна", Result = ResultType.Win });

            //Коркес, победа, победа, победа, поражение, победа
            _gameResults.Add(new GameResult() { Hero = "Коркес", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Коркес", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Коркес", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Коркес", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Коркес", Result = ResultType.Win });

            //Нова, победа, победа, поражение, победа, победа, победа, поражение
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Нова", Result = ResultType.Lose });

            //Юн Джин победа, поражение, поражение
            //_gameResults.Add(new GameResult() { Hero = "Юн Джин", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Юн Джин", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Юн Джин", Result = ResultType.Lose });

            //Рэйко поражение, поражение, победа, победа, поражение
            _gameResults.Add(new GameResult() { Hero = "Рэйко", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Рэйко", Result = ResultType.Lose });
            _gameResults.Add(new GameResult() { Hero = "Рэйко", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Рэйко", Result = ResultType.Win });
            _gameResults.Add(new GameResult() { Hero = "Рэйко", Result = ResultType.Lose });
        }

        /// <summary>
        /// Очищает все результаты
        /// </summary>
        public void ClearValues()
        {
            _gameResults.Clear();
        }

        /// <summary>
        /// Добавление результатов игры
        /// </summary>
        /// <param name="gameResult">Результат игры</param>
        public void AddValue(GameResult gameResult)
        {
            if (!string.IsNullOrEmpty(gameResult.Hero))
                _gameResults.Add(gameResult);
        }

        public List<HeroStatistic> GetMaxRate(ResultType resultType)
        {
            var heroesStatistic = _gameResults.Where(w => w.Result == resultType)
                        .GroupBy(h => h.Hero)
                        .Select(x => new HeroStatistic() { Hero = x.Key, Count = x.Count() });

            if (heroesStatistic.Count() == 0)
                return null;

            int maxAmount = heroesStatistic.Max(x => x.Count);
            return heroesStatistic.Where(x => x.Count == maxAmount).ToList();
        }

        public List<HeroStatistic> GetMinRate(ResultType resultType)
        {
            var heroesStatistic = _gameResults.Where(w => w.Result == resultType)
                        .GroupBy(h => h.Hero)
                        .Select(x => new HeroStatistic() { Hero = x.Key, Count = x.Count() });

            if (heroesStatistic.Count() == 0)
                return null;

            int minAmount = heroesStatistic.Min(x => x.Count);
            return heroesStatistic.Where(x => x.Count == minAmount).ToList();
        }

        private List<string> GetUnicHeroes()
        {
            return _gameResults.Select(g => g.Hero).Distinct().ToList();
        }
    }
}

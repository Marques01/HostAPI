﻿using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Game
    {
        private Guid
            _gameId = default;

        private string
            _name = string.Empty;

        public Guid GameId { get => _gameId; set => _gameId = value; }

        public string Name { get => _name; set => _name = value; }

        public ICollection<GameCapacity> GamesCapacities { get; set; }

        public Game()
        {
            GamesCapacities = new Collection<GameCapacity>();
        }
    }
}
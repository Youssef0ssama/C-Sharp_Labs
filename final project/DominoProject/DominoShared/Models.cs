using System;
using System.Collections.Generic;

namespace DominoShared
{
    public class DominoCard
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public override string ToString() => $"[{Side1}|{Side2}]";
    }

    public class Player
    {
        public string Name { get; set; }
        public int AccumulatedPoints { get; set; }
        public List<DominoCard> Hand { get; set; } = new List<DominoCard>();
        public bool IsActive { get; set; }
    }

    public class Room
    {
        public string RoomName { get; set; }
        public int LimitScore { get; set; }
        public int MaxPlayers { get; set; }
        public List<Player> CurrentPlayers { get; set; } = new List<Player>();
        public List<string> Watchers { get; set; } = new List<string>();
        public bool IsGameRunning { get; set; }
        public List<DominoCard> Boneyard { get; set; } = new List<DominoCard>();
        public List<DominoCard> Board { get; set; } = new List<DominoCard>();
        public int ActivePlayerIndex { get; set; } = 0;
        public int BoardLeft { get; set; } = -1;
        public int BoardRight { get; set; } = -1;
    }
}
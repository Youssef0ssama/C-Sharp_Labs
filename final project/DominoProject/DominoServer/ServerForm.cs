using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;
using DominoShared;

namespace DominoServer
{
    public partial class ServerForm : Form
    {
        private TcpListener _listener;
        private List<ClientWrapper> _connectedClients = new List<ClientWrapper>();
        private List<Room> _activeRooms = new List<Room>();
        private ListBox lstLogs;
        private Button btnStartServer;

        public ServerForm()
        {
            this.Text = "Domino Server";
            this.Size = new Size(450, 400);

            btnStartServer = new Button { Text = "Start Server", Location = new Point(10, 10), Width = 150 };
            btnStartServer.Click += BtnStartServer_Click;

            lstLogs = new ListBox { Location = new Point(10, 50), Size = new Size(400, 300) };

            this.Controls.Add(btnStartServer);
            this.Controls.Add(lstLogs);
        }

        private async void BtnStartServer_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Any, 5500);
            _listener.Start();
            Log("Server running on port 5500...");
            btnStartServer.Enabled = false;

            while (true)
            {
                TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
                ClientWrapper newClient = new ClientWrapper(tcpClient);
                newClient.MessageReceived += HandleMessage;
                newClient.Disconnected += (c) => { _connectedClients.Remove(c); Log($"{c.PlayerName} left."); };

                _connectedClients.Add(newClient);
                _ = newClient.ListenAsync();
            }
        }

        private void HandleMessage(ClientWrapper sender, string message)
        {
            string[] parts = message.Split('|');
            string cmd = parts[0];

            if (cmd == "LOGIN")
            {
                sender.PlayerName = parts[1];
                Log($"{sender.PlayerName} logged in.");
                BroadcastRooms();
            }
            else if (cmd == "CREATEROOM")
            {
                var room = new Room { RoomName = parts[1], LimitScore = int.Parse(parts[2]), MaxPlayers = int.Parse(parts[3]) };
                room.CurrentPlayers.Add(new Player { Name = sender.PlayerName });
                _activeRooms.Add(room);
                Log($"Room {room.RoomName} created by {sender.PlayerName}.");
                BroadcastRooms();
            }
            else if (cmd == "JOINROOM")
            {
                var room = _activeRooms.FirstOrDefault(r => r.RoomName == parts[1]);
                if (room != null && !room.IsGameRunning && room.CurrentPlayers.Count < room.MaxPlayers)
                {
                    room.CurrentPlayers.Add(new Player { Name = sender.PlayerName });
                    if (room.CurrentPlayers.Count >= 2)
                    {
                        StartGame(room);
                    }
                    BroadcastRooms();
                }
            }
            else if (cmd == "PLAYCARD")
            {
                var room = _activeRooms.FirstOrDefault(r => r.CurrentPlayers.Any(p => p.Name == sender.PlayerName));
                if (room == null || !room.IsGameRunning) return;

                Player p = room.CurrentPlayers[room.ActivePlayerIndex];
                if (p.Name != sender.PlayerName) return;

                int s1 = int.Parse(parts[1]);
                int s2 = int.Parse(parts[2]);
                var card = p.Hand.FirstOrDefault(c => c.Side1 == s1 && c.Side2 == s2);
                if (card == null) return;

                bool validMove = false;

                if (room.Board.Count == 0)
                {
                    room.BoardLeft = card.Side1; room.BoardRight = card.Side2;
                    room.Board.Add(card); validMove = true;
                }
                else if (card.Side2 == room.BoardLeft)
                {
                    room.BoardLeft = card.Side1; room.Board.Insert(0, card); validMove = true;
                }
                else if (card.Side1 == room.BoardLeft)
                {
                    int temp = card.Side1; card.Side1 = card.Side2; card.Side2 = temp;
                    room.BoardLeft = card.Side1; room.Board.Insert(0, card); validMove = true;
                }
                else if (card.Side1 == room.BoardRight)
                {
                    room.BoardRight = card.Side2; room.Board.Add(card); validMove = true;
                }
                else if (card.Side2 == room.BoardRight)
                {
                    int temp = card.Side1; card.Side1 = card.Side2; card.Side2 = temp;
                    room.BoardRight = card.Side2; room.Board.Add(card); validMove = true;
                }

                if (validMove)
                {
                    p.Hand.Remove(card);
                    if (p.Hand.Count == 0) EndRound(room, p);
                    else { NextTurn(room); BroadcastRoomState(room); }
                }
            }
            else if (cmd == "WITHDRAW")
            {
                var room = _activeRooms.FirstOrDefault(r => r.CurrentPlayers.Any(p => p.Name == sender.PlayerName));
                Player p = room.CurrentPlayers[room.ActivePlayerIndex];

                if (p.Name == sender.PlayerName && room.Boneyard.Count > 0)
                {
                    p.Hand.Add(room.Boneyard[0]);
                    room.Boneyard.RemoveAt(0);
                    BroadcastRoomState(room);
                }
            }
            else if (cmd == "PASS")
            {
                var room = _activeRooms.FirstOrDefault(r => r.CurrentPlayers.Any(p => p.Name == sender.PlayerName));
                Player p = room.CurrentPlayers[room.ActivePlayerIndex];

                if (p.Name == sender.PlayerName && room.Boneyard.Count == 0)
                {
                    NextTurn(room);
                    BroadcastRoomState(room);
                }
            }
        }

        private void StartGame(Room room)
        {
            room.IsGameRunning = true;
            GenerateCards(room);
            room.CurrentPlayers[0].IsActive = true;
            BroadcastRoomState(room);
            Log($"Game started in {room.RoomName}");
        }

        private void GenerateCards(Room room)
        {
            var deck = new List<DominoCard>();
            for (int i = 0; i <= 6; i++)
                for (int j = i; j <= 6; j++)
                    deck.Add(new DominoCard { Side1 = i, Side2 = j });

            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (var player in room.CurrentPlayers)
            {
                player.Hand = deck.Take(7).ToList();
                deck.RemoveRange(0, 7);
            }
            room.Boneyard = deck;
        }

        private void NextTurn(Room room)
        {
            room.CurrentPlayers[room.ActivePlayerIndex].IsActive = false;
            room.ActivePlayerIndex = (room.ActivePlayerIndex + 1) % room.CurrentPlayers.Count;
            room.CurrentPlayers[room.ActivePlayerIndex].IsActive = true;
        }

        private void BroadcastRoomState(Room room)
        {
            string json = JsonSerializer.Serialize(room);
            foreach (var p in room.CurrentPlayers)
            {
                var client = _connectedClients.FirstOrDefault(c => c.PlayerName == p.Name);
                client?.Send("GAMESTATE|" + json);
            }
        }

        private void EndRound(Room room, Player roundWinner)
        {
            int pointsGained = 0;
            foreach (var p in room.CurrentPlayers)
            {
                if (p != roundWinner) pointsGained += p.Hand.Sum(c => c.Side1 + c.Side2);
            }
            roundWinner.AccumulatedPoints += pointsGained;

            if (roundWinner.AccumulatedPoints >= room.LimitScore)
            {
                room.IsGameRunning = false;
                SaveGameResult(room);
                Log($"Game Over! {roundWinner.Name} won Room {room.RoomName}.");
                foreach (var c in _connectedClients) c.Send($"MSG|Game Over! {roundWinner.Name} won the game!");
            }
            else
            {
                GenerateCards(room);
                room.Board.Clear();
                room.BoardLeft = -1; room.BoardRight = -1;
                room.ActivePlayerIndex = room.CurrentPlayers.IndexOf(roundWinner);
                foreach (var p in room.CurrentPlayers) p.IsActive = (p == roundWinner);
                BroadcastRoomState(room);
            }
        }

        private void BroadcastRooms()
        {
            string json = JsonSerializer.Serialize(_activeRooms);
            foreach (var c in _connectedClients) c.Send("ROOMLIST|" + json);
        }

        private void SaveGameResult(Room room)
        {
            string result = $"Game Room_Name = \"{room.RoomName}\", ";
            foreach (var p in room.CurrentPlayers)
            {
                result += $"Player Name = \"{p.Name}\", Player Points = \"{p.AccumulatedPoints}\", ";
            }
            File.AppendAllText("GameResults.txt", result + Environment.NewLine);
        }

        private void Log(string msg) => this.Invoke((MethodInvoker)delegate { lstLogs.Items.Add(msg); });
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominoShared;

namespace DominoClient
{
    public partial class ClientForm : Form
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        private string _playerName;
        private Room _currentRoom;

        private Panel pnlLogin, pnlLobby, pnlGame;
        private TextBox txtName, txtRoomName;
        private ListBox lstRooms;
        private NumericUpDown numLimit, numPlayers;
        private FlowLayoutPanel flpHand, flpBoard;
        private Button btnWithdraw, btnPass;

        public ClientForm()
        {
            this.Text = "Domino Game";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            SetupLogin();
            SetupLobby();
            SetupGame();

            pnlLogin.Visible = true; pnlLobby.Visible = false; pnlGame.Visible = false;
        }

        private void SetupLogin()
        {
            pnlLogin = new Panel { Dock = DockStyle.Fill };
            txtName = new TextBox { Location = new Point(300, 200), Width = 200 };
            Button btnLogin = new Button { Text = "Connect", Location = new Point(300, 240), Width = 200 };
            btnLogin.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text)) return;
                _playerName = txtName.Text;
                _client = new TcpClient();
                try
                {
                    await _client.ConnectAsync("127.0.0.1", 5500);
                    var stream = _client.GetStream();
                    _reader = new StreamReader(stream);
                    _writer = new StreamWriter(stream) { AutoFlush = true };
                    _writer.WriteLine("LOGIN|" + _playerName);
                    _ = ListenAsync();
                    pnlLogin.Visible = false; pnlLobby.Visible = true;
                    this.Text = "Lobby - " + _playerName;
                }
                catch { MessageBox.Show("Failed to connect to server."); }
            };
            pnlLogin.Controls.Add(new Label { Text = "Name:", Location = new Point(300, 180) });
            pnlLogin.Controls.Add(txtName); pnlLogin.Controls.Add(btnLogin);
            this.Controls.Add(pnlLogin);
        }

        private void SetupLobby()
        {
            pnlLobby = new Panel { Dock = DockStyle.Fill };
            lstRooms = new ListBox { Location = new Point(20, 20), Size = new Size(300, 400) };
            Button btnJoin = new Button { Text = "Join Room", Location = new Point(20, 430) };
            btnJoin.Click += (s, e) =>
            {
                if (lstRooms.SelectedItem != null)
                {
                    string rName = lstRooms.SelectedItem.ToString().Split(' ')[0];
                    _writer.WriteLine("JOINROOM|" + rName);
                }
            };

            txtRoomName = new TextBox { Location = new Point(350, 40) };
            numLimit = new NumericUpDown { Location = new Point(350, 90), Value = 100, Maximum = 500 };
            numPlayers = new NumericUpDown { Location = new Point(350, 140), Value = 2, Maximum = 4, Minimum = 2 };
            Button btnCreate = new Button { Text = "Create Room", Location = new Point(350, 180) };
            btnCreate.Click += (s, e) => _writer.WriteLine($"CREATEROOM|{txtRoomName.Text}|{numLimit.Value}|{numPlayers.Value}");

            pnlLobby.Controls.Add(lstRooms); pnlLobby.Controls.Add(btnJoin);
            pnlLobby.Controls.Add(new Label { Text = "Room Name:", Location = new Point(350, 20) });
            pnlLobby.Controls.Add(txtRoomName);
            pnlLobby.Controls.Add(new Label { Text = "Limit Score:", Location = new Point(350, 70) });
            pnlLobby.Controls.Add(numLimit);
            pnlLobby.Controls.Add(new Label { Text = "Max Players:", Location = new Point(350, 120) });
            pnlLobby.Controls.Add(numPlayers);
            pnlLobby.Controls.Add(btnCreate);
            this.Controls.Add(pnlLobby);
        }

        private void SetupGame()
        {
            pnlGame = new Panel { Dock = DockStyle.Fill, BackColor = Color.DarkGreen };
            flpBoard = new FlowLayoutPanel { Location = new Point(20, 20), Size = new Size(740, 200), BackColor = Color.LightGreen };
            flpHand = new FlowLayoutPanel { Location = new Point(20, 250), Size = new Size(740, 150), BackColor = Color.SeaGreen };

            btnWithdraw = new Button { Text = "Withdraw", Location = new Point(20, 420), Height = 40 };
            btnPass = new Button { Text = "Pass", Location = new Point(120, 420), Height = 40, Enabled = false };

            btnWithdraw.Click += (s, e) => _writer.WriteLine("WITHDRAW|");
            btnPass.Click += (s, e) => _writer.WriteLine("PASS|");

            pnlGame.Controls.Add(flpBoard); pnlGame.Controls.Add(flpHand);
            pnlGame.Controls.Add(btnWithdraw); pnlGame.Controls.Add(btnPass);
            this.Controls.Add(pnlGame);
        }

        private async Task ListenAsync()
        {
            while (true)
            {
                string msg = await _reader.ReadLineAsync();
                if (msg == null) break;

                string[] parts = msg.Split('|');
                if (parts[0] == "ROOMLIST")
                {
                    var rooms = JsonSerializer.Deserialize<List<Room>>(parts[1]);
                    this.Invoke((MethodInvoker)delegate
                    {
                        lstRooms.Items.Clear();
                        foreach (var r in rooms) lstRooms.Items.Add($"{r.RoomName} ({r.CurrentPlayers.Count}/{r.MaxPlayers})");
                    });
                }
                else if (parts[0] == "GAMESTATE")
                {
                    _currentRoom = JsonSerializer.Deserialize<Room>(parts[1]);
                    this.Invoke((MethodInvoker)delegate { RenderGame(); });
                }
                else if (parts[0] == "MSG")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(parts[1]);
                        pnlGame.Visible = false; pnlLobby.Visible = true; // Return to lobby after game over
                    });
                }
            }
        }

        private void RenderGame()
        {
            pnlLobby.Visible = false; pnlGame.Visible = true;
            flpHand.Controls.Clear();
            flpBoard.Controls.Clear();

            foreach (var card in _currentRoom.Board)
            {
                Button btnBoardCard = new Button { Text = $"[{card.Side1}|{card.Side2}]", Size = new Size(60, 40), BackColor = Color.LightGray, Enabled = false };
                flpBoard.Controls.Add(btnBoardCard);
            }

            Player me = _currentRoom.CurrentPlayers.Find(p => p.Name == _playerName);
            this.Text = $"Game: {_currentRoom.RoomName} | Player: {me.Name} | Points: {me.AccumulatedPoints} | Turn: {(me.IsActive ? "YOUR TURN" : "Wait...")}";

            foreach (var card in me.Hand)
            {
                Button btnCard = new Button { Text = $"[{card.Side1}]\n |\n[{card.Side2}]", Size = new Size(50, 90), BackColor = Color.Ivory, Font = new Font("Arial", 12, FontStyle.Bold) };
                btnCard.Enabled = me.IsActive;
                btnCard.Click += (s, e) => _writer.WriteLine($"PLAYCARD|{card.Side1}|{card.Side2}");
                flpHand.Controls.Add(btnCard);
            }

            btnWithdraw.Enabled = me.IsActive && _currentRoom.Boneyard.Count > 0;
            btnPass.Enabled = me.IsActive && _currentRoom.Boneyard.Count == 0;
        }
    }
}
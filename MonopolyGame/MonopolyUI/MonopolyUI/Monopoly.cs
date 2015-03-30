using MonopolyGame.Model.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonopolyUI
{
    public enum PlayerTurn { P1, P2, P3 }


    public partial class Monopoly : Form
    {
        /// <summary>
        /// Below is the custom method which prepares our game by (re)setting everything, and getting it ready for play
        /// </summary>
        public static Player player1 = new Player(null);

        public static Player player2 = new Player(null);

        public static Player player3 = new Player(null);

        public static PlayerTurn PlayerTurn = PlayerTurn.P1;

        public void BeginNewGame()
        {
            //Hides the tab headers
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            //Shows the first tab - Menu
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabPage1);
        }

        public string GetNames()
        {
            Form prompt = new Form();
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label lbl = new Label();
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.Text = "Please enter player name: ";
            lbl.MinimumSize = new Size(200, 100);

            TextBox textBox = new TextBox() { Left = 4, Top = 60, Width = 272 };
            Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 100, Top = 85 };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(lbl);

            confirmation.Click += (sender, e) => { prompt.Close(); };
            confirmation.Click += (sender, e) =>
            {
                ParseName((String.IsNullOrWhiteSpace(textBox.Text) ? "anonymous" : textBox.Text));
            };

            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();

            return textBox.Text;
        }

        public string ParseName(string text)
        {
            return text;
        }

        public void UpdatePlayerInfo2(Player p1, Player p2)
        {
            player1Prop.Text = p1.Properties.Count.ToString();
            player1Cash.Text = p1.Money.ToString();
            player2Prop.Text = p2.Properties.Count.ToString();
            player2Cash.Text = p2.Money.ToString();
        }

        public void UpdatePlayerInfo3(Player p1, Player p2, Player p3)
        {
            label13.Text = p1.Properties.Count.ToString();
            label12.Text = p1.Money.ToString();
            label5.Text = p2.Properties.Count.ToString();
            label4.Text = p2.Money.ToString();
            label18.Text = p3.Properties.Count.ToString();
            label17.Text = p3.Money.ToString();
        }

        public Monopoly()
        {
            InitializeComponent();
            BeginNewGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (playerCount1.Checked)
            {
                player1.Name = GetNames();
                label1.Text = player1.Name;
                player2.Name = GetNames();
                label10.Text = player2.Name;

                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage2);

                UpdatePlayerInfo2(player1, player2);

                button6.Hide();
            }
            else if (playerCount3.Checked)
            {
                player1.Name = GetNames();
                label16.Text = player1.Name;
                player2.Name = GetNames();
                label11.Text = player2.Name;
                player3.Name = GetNames();
                label21.Text = player3.Name;

                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage3);

                UpdatePlayerInfo3(player1, player2, player3);

                button7.Hide();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 2-PLAYER-GAME METHODS

        private void button1_Click(object sender, EventArgs e)
        {
            BeginNewGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BeginNewGame();
        }

        //Roll button-2players

        private void button4_Click(object sender, EventArgs e)
        {
            int dice1 = Dice.Roll();
            int dice2 = Dice.Roll();
            int moves = dice1 + dice2;
            bool Pair = dice1 == dice2;
            label22.Text = string.Format("{0} + {1} = {2}", dice1.ToString(), dice2.ToString(), moves.ToString());

            switch (PlayerTurn)
            {
                case PlayerTurn.P1:
                    player1.Move(moves, 40);
                    //DetermineTile();
                    break;
                case PlayerTurn.P2:
                    player2.Move(moves, 40);
                    //DetermineTile();
                    break;
            }

            if (Pair) return;
            button4.Hide();
            button6.Show();
        }

        private void EndOfTurn2p()
        {
            switch (PlayerTurn)
            {
                case PlayerTurn.P1:
                    PlayerTurn = PlayerTurn.P2;
                    break;
                case PlayerTurn.P2:
                    PlayerTurn = PlayerTurn.P1;
                    break;
            }
            button4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EndOfTurn2p();
            button6.Hide();
        }
        #endregion

        #region 3-PLAYER-GAME METHODS
        //Roll button-3players
        private void button9_Click(object sender, EventArgs e)
        {
            int dice1 = Dice.Roll();
            int dice2 = Dice.Roll();
            int moves = dice1 + dice2;
            bool Pair = dice1 == dice2;
            label23.Text = string.Format("{0} + {1} = {2}", dice1.ToString(), dice2.ToString(), moves.ToString());

            switch (PlayerTurn)
            {
                case PlayerTurn.P1:
                    player1.Move(moves, 40);
                    //DetermineTile();
                    break;
                case PlayerTurn.P2:
                    player2.Move(moves, 40);
                    //DetermineTile();
                    break;
                case PlayerTurn.P3:
                    player3.Move(moves, 40);
                    //DetermineTile();
                    break;
            }

            if (Pair) return;
            button9.Hide();
            button7.Show();
        }

        private void EndOfTurn3p()
        {
            switch (PlayerTurn)
            {
                case PlayerTurn.P1:
                    PlayerTurn = PlayerTurn.P2;
                    break;
                case PlayerTurn.P2:
                    PlayerTurn = PlayerTurn.P3;
                    break;
                case PlayerTurn.P3:
                    PlayerTurn = PlayerTurn.P1;
                    break;
            }
            button9.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EndOfTurn3p();
            button7.Hide();
        }
        #endregion

    }
}

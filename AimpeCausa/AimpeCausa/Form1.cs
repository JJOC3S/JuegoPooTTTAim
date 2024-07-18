using System;
using System.Drawing;
using System.Windows.Forms;

namespace AimpeCausa
{
    public partial class Form1 : Form
    {
        private Button[,] aimGrid;
        private Button restartButton;
        private Panel ticTacToePanel;
        private Button[,] ticTacToeButtons;
        private bool aimGameActive = true;
        private Random random;
        private PictureBox arrowPictureBox;
        private PictureBox winnerPictureBox;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.Size = new Size(800, 800);
            random = new Random();

            // Crear panel de Tic Tac Toe
            ticTacToePanel = new Panel
            {
                Size = new Size(150, 150),
                Location = new Point(10, 10),
                Enabled = false
            };
            this.Controls.Add(ticTacToePanel);

            ticTacToeButtons = new Button[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacToeButtons[i, j] = new Button
                    {
                        Size = new Size(50, 50),
                        Location = new Point(i * 50, j * 50)
                    };
                    ticTacToeButtons[i, j].Click += TicTacToeButton_Click;
                    ticTacToePanel.Controls.Add(ticTacToeButtons[i, j]);
                }
            }

            // Crear la cuadrícula de aim
            Panel aimPanel = new Panel
            {
                Size = new Size(625, 625),
                Location = new Point(175, 10)
            };
            this.Controls.Add(aimPanel);

            aimGrid = new Button[25, 25];
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    aimGrid[i, j] = new Button
                    {
                        Size = new Size(25, 25),
                        Location = new Point(i * 25, j * 25),
                        BackColor = Color.Black
                    };
                    aimGrid[i, j].Click += AimGridButton_Click;
                    aimPanel.Controls.Add(aimGrid[i, j]);
                }
            }

            SetRandomAimTarget();

            // Crear botón de reinicio
            restartButton = new Button
            {
                Size = new Size(100, 50),
                Location = new Point(350, 650),
                Text = "Reiniciar",
                Visible = false
            };
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);

            arrowPictureBox = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(750, 10),
                Image = Image.FromFile("arrow.png"), 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
                BackColor = Color.Transparent
            };
            this.Controls.Add(arrowPictureBox);
            arrowPictureBox.BringToFront();
            winnerPictureBox = new PictureBox
            {
                Size = this.ClientSize,
                Location = new Point(0, 0),
                Image = Image.FromFile("ganador.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
                BackColor = Color.Transparent
            };
            this.Controls.Add(winnerPictureBox);
            winnerPictureBox.BringToFront();
        }

        private void TicTacToeButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Text == "")
            {
                clickedButton.Text = "X";
                if (CheckTicTacToeWin("X"))
                {
                    ShowWinnerImage();
                    return;
                }

                ComputerMove();
                if (CheckTicTacToeWin("O"))
                {
                    EndGame("Perdiste en el Tic Tac Toe. ¡Reinicia el juego!");
                }
            }
        }

        private void ComputerMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ticTacToeButtons[i, j].Text == "")
                    {
                        ticTacToeButtons[i, j].Text = "O";
                        return;
                    }
                }
            }
        }

        private bool CheckTicTacToeWin(string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (ticTacToeButtons[i, 0].Text == player && ticTacToeButtons[i, 1].Text == player && ticTacToeButtons[i, 2].Text == player)
                    return true;
                if (ticTacToeButtons[0, i].Text == player && ticTacToeButtons[1, i].Text == player && ticTacToeButtons[2, i].Text == player)
                    return true;
            }
            if (ticTacToeButtons[0, 0].Text == player && ticTacToeButtons[1, 1].Text == player && ticTacToeButtons[2, 2].Text == player)
                return true;
            if (ticTacToeButtons[2, 0].Text == player && ticTacToeButtons[1, 1].Text == player && ticTacToeButtons[0, 2].Text == player)
                return true;

            return false;
        }

        private void AimGridButton_Click(object sender, EventArgs e)
        {
            if (!aimGameActive) return;

            Button clickedButton = sender as Button;
            if (clickedButton.BackColor == Color.Red)
            {
                clickedButton.BackColor = Color.Black;
                SetRandomAimTarget();
            }
            else
            {
                aimGameActive = false;
                ticTacToePanel.Enabled = true;
                MessageBox.Show("Perdiste en el aim. Ahora juega Tic Tac Toe.");
            }
        }

        private void SetRandomAimTarget()
        {
            int i = random.Next(0, 25);
            int j = random.Next(0, 25);
            aimGrid[i, j].BackColor = Color.Red;
        }

        private void EndGame(string message)
        {
            MessageBox.Show(message);
            restartButton.Visible = true;
            arrowPictureBox.Visible = true;
            arrowPictureBox.BringToFront();
        }

        private void ShowWinnerImage()
        {
            winnerPictureBox.Visible = true;
            winnerPictureBox.BringToFront();
            restartButton.Visible = true;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

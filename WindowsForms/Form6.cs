using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form6 : Form
    {
        private System.Media.SoundPlayer player;
        private Form2 previousForm;
        private PictureBox[] puzzlePieces;
        private Bitmap puzzleImage;
        private Point mouseDownLocation;
        private PictureBox draggedPiece;
        private int tolerance = 10; // Погрешность в пикселях
        private int[,] correctPositions; // Массив для хранения правильных позиций кусочков
        private bool isPuzzleSolved = false;

        public Form6(Form2 form2)
        {
            InitializeComponent();
            InitializePuzzle();
            previousForm = form2;
            pictureBox1.Visible = false;
            ShufflePuzzlePieces();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "puzzle.wav";
            player.PlayLooping();
        }

        private void ShufflePuzzlePieces()
        {
            Random random = new Random();
            foreach (PictureBox piece in puzzlePieces)
            {
                int newX = random.Next(0, this.Width - piece.Width);
                int newY = random.Next(0, this.Height - piece.Height);
                piece.Location = new Point(newX, newY);
                piece.BringToFront();
            }
        }

        private void PuzzlePiece_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox puzzlePiece = sender as PictureBox;
                draggedPiece = puzzlePiece;
                mouseDownLocation = e.Location;
                puzzlePiece.BringToFront();
            }
        }

        private void PuzzlePiece_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && draggedPiece != null)
            {
                int newX = e.X - mouseDownLocation.X + draggedPiece.Location.X;
                int newY = e.Y - mouseDownLocation.Y + draggedPiece.Location.Y;

                // Ограничения по горизонтали
                newX = Math.Max(0, newX);
                newX = Math.Min(this.Width - draggedPiece.Width, newX);

                // Ограничения по вертикали
                newY = Math.Max(0, newY);
                newY = Math.Min(this.Height - draggedPiece.Height, newY);

                draggedPiece.Location = new Point(newX, newY);
            }
        }

        private void PuzzlePiece_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggedPiece != null)
            {
                if (IsPuzzleSolved())
                {
                    MessageBox.Show("Вы разблокировали воспоминание!");
                    previousForm.ContinueFromForm4(); // Вызываем метод для продолжения
                    this.Hide();
                    previousForm.Show();
                }
                draggedPiece = null;
                mouseDownLocation = Point.Empty;
            }
        }

        private bool IsPieceInPlace(PictureBox piece, int tolerance)
        {
            int targetX = (piece.Location.X / piece.Width) * piece.Width;
            int targetY = (piece.Location.Y / piece.Height) * piece.Height;
            return Math.Abs(piece.Location.X - targetX) <= tolerance &&
                   Math.Abs(piece.Location.Y - targetY) <= tolerance;
        }

        private void InitializePuzzle()
        {
            puzzleImage = (Bitmap)pictureBox1.Image;
            puzzlePieces = new PictureBox[16];
            int pieceWidth = puzzleImage.Width / 4;
            int pieceHeight = puzzleImage.Height / 4;

            // Создаем массив для хранения правильных позиций
            correctPositions = new int[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    puzzlePieces[i * 4 + j] = new PictureBox();
                    puzzlePieces[i * 4 + j].Width = pieceWidth;
                    puzzlePieces[i * 4 + j].Height = pieceHeight;
                    Rectangle sourceRect = new Rectangle(j * pieceWidth, i * pieceHeight, pieceWidth, pieceHeight);
                    puzzlePieces[i * 4 + j].Image = puzzleImage.Clone(sourceRect, puzzleImage.PixelFormat);
                    puzzlePieces[i * 4 + j].MouseDown += PuzzlePiece_MouseDown;
                    puzzlePieces[i * 4 + j].MouseMove
+= PuzzlePiece_MouseMove;
                    puzzlePieces[i * 4 + j].MouseUp += PuzzlePiece_MouseUp;
                    Controls.Add(puzzlePieces[i * 4 + j]);

                    // Заполняем массив правильных позиций
                    correctPositions[i, j] = i * 4 + j;
                }
            }
        }

        private bool IsPuzzleSolved()
        {
            if (isPuzzleSolved)
            {
                return true;
            }

            // Проверяем правильную комбинацию кусочков относительно друг друга
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int currentPieceIndex = i * 4 + j;
                    if (!IsPieceInCorrectPosition(puzzlePieces[currentPieceIndex], i, j, tolerance))
                    {
                        return false;
                    }
                }
            }

            // Если все кусочки на своих местах, пазл собран
            isPuzzleSolved = true;
            return true;
        }


        // Проверяем, находится ли кусочек в правильной позиции относительно других
        private bool IsPieceInCorrectPosition(PictureBox piece, int targetRow, int targetColumn, int tolerance)
        {
            int targetX = targetColumn * piece.Width;
            int targetY = targetRow * piece.Height;

            return Math.Abs(piece.Location.X - targetX) <= tolerance &&
                   Math.Abs(piece.Location.Y - targetY) <= tolerance;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Перемешать кусочки
            ShufflePuzzlePieces();

            // Удалить старые обработчики событий и переустановить новые для каждого кусочка
            foreach (PictureBox piece in puzzlePieces)
            {
                piece.MouseDown -= PuzzlePiece_MouseDown;
                piece.MouseMove -= PuzzlePiece_MouseMove;
                piece.MouseUp -= PuzzlePiece_MouseUp;

                piece.MouseDown += PuzzlePiece_MouseDown;
                piece.MouseMove += PuzzlePiece_MouseMove;
                piece.MouseUp += PuzzlePiece_MouseUp;
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
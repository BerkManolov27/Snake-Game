using System.Text;
using System.Xml.Linq;
using static SnakeGame.Directions;

namespace SnakeGame
{
    internal class SnakeGame
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            const int boardWidth = 80;
            const int boardHeight = 30;

            const int scorePanelTextPosition = 2;
            const int boardersOffset = 4;



            SetWindowProperties();

            Position[] directions = new Position[]
            {
                new Position(0, 2),
                new Position(0, -2),
                new Position(1, 0),
                new Position(-1, 0),
            };

            int playerPoints = 0;
            int startingDirection = (int)Direction.Right;

            DrawBorders();
            Food food = null;

            Snake snake = new Snake(boardersOffset, boardHeight, boardWidth);

            //DrawNewFood();
            //PlayGame();

            void SetWindowProperties()
            {
                Console.CursorVisible = false;

                Console.BufferHeight = Console.WindowHeight = boardHeight;
                Console.BufferWidth = Console.WindowWidth = boardWidth;
            }

            void DrawBorders()
            {
                StringBuilder stringBuilder = new StringBuilder();

                Console.ForegroundColor = ConsoleColor.Cyan;

                char horizontalBorderPiece = ' ';
                string verticalBorderPiece = " ";

                string horizontalSlide = new string(horizontalBorderPiece, count: boardWidth - boardersOffset + 2);
                string emptyHorizontalSlide = new string(c: ' ', count: boardWidth - boardersOffset);

                stringBuilder.AppendLine($"{horizontalBorderPiece}{horizontalSlide}{horizontalBorderPiece}");

                for (int row = 0; row < boardHeight - boardersOffset; row++)
                {
                    stringBuilder.AppendLine($"{verticalBorderPiece}{emptyHorizontalSlide}{verticalBorderPiece}");
                }

                stringBuilder.AppendLine($"{boardersOffset}{horizontalSlide}");

                string borders = stringBuilder.ToString().TrimEnd();

                Console.WriteLine(borders);



            }
        }
    }
}

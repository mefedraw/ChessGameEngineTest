using ChessEngineTest;

public class Program
{
    static void Main(string[] args)
    {
        var game1 = new Game();

        while (true)
        {
            // Выводим текущую доску
            Console.WriteLine("Текущая доска:");
            PrintBoard(game1.Board);

            // Чтение хода
            Console.Write("Введите ход (например, e2e4) или 'exit' для выхода: ");
            string move = Console.ReadLine();

            if (move.ToLower() == "exit")
            {
                break;
            }

            // Проверяем длину хода (должно быть 4 символа)
            if (move.Length != 4)
            {
                Console.WriteLine("Некорректный формат хода. Попробуйте снова.");
                continue;
            }

            // Выполняем ход
            bool success = game1.DoMove(move);
            if (success)
            {
                Console.WriteLine("Ход выполнен");

            }
            else
            {
                Console.WriteLine("Ход невозможен.");
            }
        }
    }

    // Метод для вывода доски в консоль
    static void PrintBoard(IFigure[][] board)
    {
        Console.WriteLine("  a b c d e f g h"); // Верхняя строка с буквами для колонок

        for (int x = 7; x >= 0; x--) // Начинаем с 7, чтобы выводить сверху вниз
        {
            Console.Write($"{x + 1} "); // Печатаем цифру для строки

            for (int y = 0; y < 8; y++)
            {
                if (board[x][y] == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write($"{GetFigureSymbol(board[x][y])} ");
                }
            }

            Console.WriteLine($"{x + 1}"); // Печатаем цифру для строки с правой стороны
        }

        Console.WriteLine("  a b c d e f g h"); // Нижняя строка с буквами для колонок
    }


    // Метод для отображения символов фигур
    static char GetFigureSymbol(IFigure figure)
    {
        switch (figure.Type)
        {
            case FigureType.Pawn:
                return figure.Color == 'w' ? 'P' : 'p';
            case FigureType.King:
                return figure.Color == 'w' ? 'K' : 'k';
            case FigureType.Queen:
                return figure.Color == 'w' ? 'Q' : 'q';
            case FigureType.Bishop:
                return figure.Color == 'w' ? 'B' : 'b';
            case FigureType.Knight:
                return figure.Color == 'w' ? 'N' : 'n';
            case FigureType.Rook:
                return figure.Color == 'w' ? 'R' : 'r';
            default:
                return '-';
        }
    }
}

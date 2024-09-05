namespace ChessEngineTest;

public class Game
{
    public Game()
    {
        // Инициализация доски
        Board = new Figure[8][];
        for (int i = 0; i < 8; i++)
        {
            Board[i] = new Figure[8];
        }

        // Расстановка белых фигур
        Board[0][0] = new Rook('w'); // Ладья
        Board[0][1] = new Knight('w'); // Конь
        Board[0][2] = new Bishop('w'); // Слон
        Board[0][3] = new Queen('w'); // Ферзь
        Board[0][4] = new King('w'); // Король
        Board[0][5] = new Bishop('w'); // Слон
        Board[0][6] = new Knight('w'); // Конь
        Board[0][7] = new Rook('w'); // Ладья
        for (int i = 0; i < 8; i++)
        {
            Board[1][i] = new Pawn('w'); // Пешки на второй линии
        }

        for (int i = 2; i < 6; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Board[i][j] = null;
            }
        }

        // Расстановка черных фигур
        Board[7][0] = new Rook('b'); // Ладья
        Board[7][1] = new Knight('b'); // Конь
        Board[7][2] = new Bishop('b'); // Слон
        Board[7][3] = new Queen('b'); // Ферзь
        Board[7][4] = new King('b'); // Король
        Board[7][5] = new Bishop('b'); // Слон
        Board[7][6] = new Knight('b'); // Конь
        Board[7][7] = new Rook('b'); // Ладья
        for (int i = 0; i < 8; i++)
        {
            Board[6][i] = new Pawn('b'); // Пешки на седьмой линии
        }

        WhiteToMove = true;
    }

    public IFigure[][] Board;

    public bool WhiteToMove { get; set; }

    public bool DoMove(string move)
    {
        try
        {
            // Преобразуем ход (например, e2e4) в координаты на доске
            (int, int) moveStartCoords = (CharToCoord(move[1]), CharToCoord(move[0]));
            (int, int) moveEndCoords = (CharToCoord(move[3]), CharToCoord(move[2]));

            // Проверяем, есть ли фигура на начальной позиции
            IFigure figure = Board[moveStartCoords.Item1][moveStartCoords.Item2];
            if (figure == null)
            {
                Console.WriteLine("Нет фигуры на начальной позиции.");
                return false;
            }

            // Выполняем ход
            return figure.PossibleMove(ref Board,moveStartCoords, moveEndCoords);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении хода: {ex.Message}");
            return false; // Возвращаем false при любой ошибке
        }
    }

    private int CharToCoord(char c)
    {
        if (char.IsLetter(c))
        {
            var test1 = c - 'a';
            return c - 'a'; // Преобразуем буквы 'a'-'h' в индексы 0-7
        }

        if (char.IsDigit(c))
        {
            var test2 =  (c - '0' - 1);
            return (c - '0' - 1); // Преобразуем цифры '1'-'8' в индексы 7-0
        }

        throw new ArgumentException("Некорректный символ для шахматных координат");
    }
}

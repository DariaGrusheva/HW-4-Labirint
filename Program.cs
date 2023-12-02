namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();
            int[,] l = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 0, 0, 0, 0, 1 },
                {1, 1, 0, 1, 1, 0, 1 },
                {2, 0, 0, 1, 2, 0, 2 },
                {1, 1, 0, 2, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 2, 1, 1, 0 }
            };
            int count = 0;
            int startI = 1;
            int startJ = 2;
            int result = HasExit(startI, startJ, l);
            Console.WriteLine();
            Console.WriteLine($"Количество выходов лабиринта из заданной точки ({startI},{startJ}) равно: {result}.");


             int HasExit(int startI, int startJ, int[,] l)
            {
                if (l[startI, startJ] == 0) _path.Push(new(startI, startJ)); 

                while (_path.Count > 0)
                {
                    var current = _path.Pop(); 

                    if (l[current.Item1, current.Item2] == 2) 
                    {
                        count++;
                        l[current.Item1, current.Item2] = 1;
                        HasExit(startI, startJ, l);
                    }

                    l[current.Item1, current.Item2] = 1; 

                    if (current.Item1 + 1 < l.GetLength(0)
                       && l[current.Item1 + 1, current.Item2] != 1)
                        _path.Push(new(current.Item1 + 1, current.Item2));

                    if (current.Item2 + 1 < l.GetLength(1) &&
                       l[current.Item1, current.Item2 + 1] != 1)
                        _path.Push(new(current.Item1, current.Item2 + 1)); 

                    if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1) 
                        _path.Push(new(current.Item1 - 1, current.Item2));

                    if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] != 1) 
                        _path.Push(new(current.Item1, current.Item2 - 1));
                }

                return count;

            }
        }
    }
}




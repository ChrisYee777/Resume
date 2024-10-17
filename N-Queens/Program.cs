using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queens
{
    public class NQueens
    {
        public List<List<string>> SolveNQueens(int Size)
        {
            List<List<string>> result = new List<List<string>>();

            int[] board = new int[Size]; //大小
            for (int i = 0; i < board.Length; i++) //歸0
            {
                board[i] = -1; // 初始化為-1
            }; 
            Solve(board, 0, result);
            return result;
        }

        private void Solve(int[] board,   int row, List<List<string>> result)
        {
            if (row == board.Length)
            {
                List<string> _BoardPlace = CreateBoard(board);
                result.Add(_BoardPlace);
                return;
            }

            for (int col = 0; col < board.Length; col++)
            {
                if (CheckBoard(board, row, col))
                {
                    board[row] = col;
                    Solve(board, row + 1, result);
                    board[row] = -1; // 回溯
                }
            }
        }

        private bool CheckBoard(int[] board, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i] == col || // 同行
                    board[i] - i == col - row || // 右對角線 
                    board[i] + i == col + row)   // 左對角線
                {
                    return false;
                }
            }
            return true;
        }

        private List<string> CreateBoard(int[] board)
        {
            int _Size = board.Length;
            List<string> _Ans  = new List<string>();
            for (int i = 0; i < _Size; i++)
            {
                char[]row = new char[_Size];
                for (int j = 0; j < _Size; j++)
                {
                    row[j] = '.'; 
                }; 
                row[board[i]] = 'Q';  
                _Ans.Add(new string(row));
            }
            return _Ans;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入隨機數字");
            int _Size = Convert.ToInt32(Console.ReadLine());
            NQueens nQueens = new NQueens();
            List<List<string>> Result = nQueens.SolveNQueens(_Size); 
            foreach (var Data in Result)
            {
                foreach (var row in Data)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine(); 
            }
            Console.ReadKey();
        }
    }
}

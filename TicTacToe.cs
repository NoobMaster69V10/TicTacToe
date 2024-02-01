using System;
using System.Collections.Generic;
using System.Net;

namespace project{
    class TicTacToe{
        string player_1, player_2, result;
        bool status;
        Dictionary<int, char> table = new Dictionary<int, char>{{1, '1'}, {2, '2'}, {3, '3'},
                                                                {4, '4'}, {5, '5'}, {6, '6'},
                                                                {7, '7'}, {8, '8'}, {9, '9'}};
        List<int> occupied_positions = new List<int>();

        void PrintField(){
            Console.WriteLine(table[1] + " | " + table[2] + " | "+ table[3] + "\n" + 
                              table[4] + " | " + table[5] + " | " + table[6] + "\n" + 
                              table[7] + " | " + table[8] + " | " + table[9] );
        }

        void GetInfo(){
            Console.WriteLine("Enter First Player's Name:  ");
            string? player_1 = Console.ReadLine();
            ///
            Console.WriteLine("Enter Second Player's Name:  ");
            string? player_2 = Console.ReadLine();
            ///
            this.player_1 = player_1;
            this.player_2 = player_2;
        }

        
        void PlayerInp1(){
            Console.WriteLine("Input X position: (1-9): ");
            int x_pos = Convert.ToInt32(Console.ReadLine());

            if (occupied_positions.Contains(x_pos)){
                Console.WriteLine("This position is occupied, please enter another one: ");
                PrintField();
                PlayerInp1();
            }
            else{
                occupied_positions.Add(x_pos);
                table[x_pos] = 'X';
            }
            
        }
        

        void PlayerInp2(){
            Console.WriteLine("Input Y position: (1-9): ");
            int y_pos = Convert.ToInt32(Console.ReadLine());

            if (occupied_positions.Contains(y_pos)){
                Console.WriteLine("This position is occupied, please enter another one: ");
                PrintField();
                PlayerInp2();
            }
            else{
                occupied_positions.Add(y_pos);
                table[y_pos] = 'Y';
            }
            
        }

        void CheckResult(string player){
            if (table[1] == table[4] && table[4] == table[7] ||
                table[1] == table[2] && table[2] == table[3] ||
                table[1] == table[5] && table[5] == table[9] ||
                table[2] == table[5] && table[5] == table[8] ||
                table[4] == table[5] && table[5] == table[6] || 
                table[7] == table[8] && table[8] == table[9] ||
                table[3] == table[6] && table[6] == table[9] ||
                table[3] == table[5] && table[5] == table[7])
                {
                    status = true;
                    result = $"{player} won!";
                }

            ///
            if(occupied_positions.Count == 9){
                status = true;
                result = "It's tie!!!";
            }
        }

        public void StartGame(){
            GetInfo();

            while (true){
                PrintField();
                PlayerInp1();
                CheckResult(player_1);
                if(status){
                    PrintField();
                    Console.WriteLine(result);
                    break;
                }

                ///
                PrintField();
                PlayerInp2();
                CheckResult(player_2);
                if(status){
                    PrintField();
                    Console.WriteLine(result);
                    break;
                }
            }
        }
    }
}

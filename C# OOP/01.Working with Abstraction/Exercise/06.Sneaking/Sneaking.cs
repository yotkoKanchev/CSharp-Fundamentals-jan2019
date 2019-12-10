using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        static void Main()
        {
            int RoomRowsCount = int.Parse(Console.ReadLine());
            var room = new Room(RoomRowsCount);

            int[] samPosition = room.GetPosition('S');
            var sam = new Player(samPosition);

            int[] nikoladzePosition = room.GetPosition('N');
            var nikoladze = new Player(nikoladzePosition);

            var moves = Console.ReadLine().ToCharArray();

            foreach (var move in moves)
            {
                room.MoveEnemies();
                room.MoveSam(sam, nikoladze, move);

                if (room.HasToFinishGame == true)
                {
                    Console.WriteLine(room);
                    break;
                }
            }
        }
    }
}

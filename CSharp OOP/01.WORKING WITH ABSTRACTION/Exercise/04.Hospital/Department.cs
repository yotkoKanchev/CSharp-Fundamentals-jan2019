using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }
        public string Name { get; private set; }

        public List<Room> Rooms { get; private set; }

        public void AddPatient(Patient patient)
        {
            if (this.Rooms.Any())
            {
                var currentRoom = this.Rooms[this.Rooms.Count - 1];

                if (!currentRoom.HasEmptyBed())
                {
                    var room = new Room(this.Rooms.Count + 1);
                    room.Add(patient);
                    this.Rooms.Add(room);
                }
                else
                {
                    currentRoom.Add(patient);
                }
            }
            else
            {
                var room = new Room(this.Rooms.Count + 1);
                room.Add(patient);
                this.Rooms.Add(room);
            }

        }
        public bool hasAvailableRoom()
        {
            return (this.Rooms.Count < 20 || this.Rooms[19].HasEmptyBed() == true);
        }
    }
}

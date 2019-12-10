namespace P08.MilitaryElite.Core
{
    using Enumerations;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoldierFactory
    {
        public Soldier Create(string input, List<Private> privates)
        {

            var soldierArguments = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            var type = soldierArguments[0];
            var id = int.Parse(soldierArguments[1]);
            var firstName = soldierArguments[2];
            var lastName = soldierArguments[3];

            switch (type)
            {
                case "Private":
                    var salary = decimal.Parse(soldierArguments[4]);
                    var @private = new Private(id, firstName, lastName, salary);
                    privates.Add(@private);
                    return @private;
                case "LieutenantGeneral":
                    salary = decimal.Parse(soldierArguments[4]);
                    var lGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    var privatesIds = soldierArguments.Skip(5).Select(int.Parse).ToArray();

                    foreach (var privateId in privatesIds)
                    {
                        var currentPrivate = privates.FirstOrDefault(p => p.Id == privateId);
                        if (currentPrivate != null)
                        {
                            lGeneral.AddPrivate(currentPrivate);
                        }
                    }

                    return lGeneral;
                case "Engineer":
                    salary = decimal.Parse(soldierArguments[4]);
                    var corps = Enum.Parse(typeof(Corps), soldierArguments[5]);

                    if (corps == null)
                    {
                        return null;
                    }

                    var engineer = new Engineer(id, firstName, lastName, salary, (Corps)corps);
                    var repairs = soldierArguments.Skip(6).ToArray();

                    for (int i = 0; i < repairs.Length; i += 2)
                    {
                        var name = repairs[i];
                        var hours = int.Parse(repairs[i + 1]);

                        engineer.AddRepair(new Repair(name, hours));
                    }

                    return engineer;

                case "Commando":
                    salary = decimal.Parse(soldierArguments[4]);
                    corps = Enum.Parse(typeof(Corps), soldierArguments[5]);

                    if (corps == null)
                    {
                        return null;
                    }

                    var commando = new Commando(id, firstName, lastName, salary, (Corps)corps);
                    var missions = soldierArguments.Skip(6).ToArray();

                    for (int i = 0; i < missions.Length; i += 2)
                    {
                        var codeName = missions[i];

                        var state = missions[i + 1];

                        if (state != "Finished" && state != "inProgress")
                        {
                            continue;
                        }

                        commando.AddMission(new Mission(codeName, (States)Enum.Parse(typeof(States), state)));
                    }

                    return commando;
                case "Spy":
                    var codeNumber = int.Parse(soldierArguments[4]);
                    return new Spy(id, firstName, lastName, codeNumber);
                default:
                    return null;
            }
        }
    }
}

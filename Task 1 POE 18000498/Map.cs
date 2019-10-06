using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Task_1_POE_18000498
{
    class Map
    {
        public string[,] map = new string[20, 20];

        public List<Button> buttons = new List<Button>();
        
        public List<Unit> units = new List<Unit>();
        public List<Unit> rangedUnits = new List<Unit>();
        public List<Unit> meleeUnits = new List<Unit>();

        public Unit[,] unitMap = new Unit[20, 20];

        Random rd = new Random();

        int unitNum;

        public Map (int unitN = 0)
        {
            unitNum = unitN;
        }

        public void GenerateBattlefield()
        {
            for (int i = 0; i < unitNum; i++)
            {
                if (rd.Next(0, 2) == 0)
                {
                    RangedUnit sniper = new RangedUnit(0, 0, Faction.Overwatch, 15, 1, 3, 3, "︻デ═一", false);
                    rangedUnits.Add(sniper);
                }
                else
                {
                    MeleeUnit Cavalry = new MeleeUnit(0, 0, Faction.Overwatch, 15, 1, 3, 3, "▬===>", false);
                    meleeUnits.Add(Cavalry);
                }
            }
            for (int i = 0; i < unitNum; i++)
            {
                if (rd.Next(0, 2) == 0)
                {
                    RangedUnit sniper = new RangedUnit(0, 0, Faction.Talon, 15, 1, 3, 3, "︻デ═一", false);
                    rangedUnits.Add(sniper);
                }
                else
                {
                    MeleeUnit Cavalry = new MeleeUnit(0, 0, Faction.Talon, 15, 1, 3, 3, "▬===>", false);
                    meleeUnits.Add(Cavalry);
                }
            }

            foreach (Unit u in rangedUnits)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    int xPos = rd.Next(0, 20);
                    int yPos = rd.Next(0, 20);

                    while (xPos == units[i].posX && yPos == meleeUnits[i].posY && xPos == rangedUnits[i].posX && yPos == rangedUnits[i].posY)
                    {
                        xPos = rd.Next(0, 20);
                        yPos = rd.Next(0, 20);
                    }

                    u.posX = xPos;
                    u.posY = yPos;
                    unitMap[u.posY, u.posX] = (Unit)u;
                }

                units.Add(u);
            }

            foreach (Unit u in meleeUnits)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    int xPos = rd.Next(0, 20);
                    int yPos = rd.Next(0, 20);

                    while (xPos == units[i].posX && yPos == meleeUnits[i].posY && xPos == meleeUnits[i].posX && yPos == meleeUnits[i].posY)
                    {
                        xPos = rd.Next(0, 20);
                        yPos = rd.Next(0, 20);
                    }

                    u.posX = xPos;
                    u.posY = yPos;
                    
                }
                unitMap[u.posY, u.posX] = (Unit)u;
                units.Add(u);

            }
            PlaceUnits();
        }

        public void PlaceUnits()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = "";
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    unitMap[i, j] = null;
                }
            }

            foreach(Unit u in units)
            {
                unitMap[u.posY, u.posX] = u;
            }

            foreach(Unit u in rangedUnits)
            {
                map[u.posY, u.posX] = "R";
            }

            foreach (Unit u in meleeUnits)
            {
                map[u.posY, u.posX] = "M";
            }
        }          
    }
}

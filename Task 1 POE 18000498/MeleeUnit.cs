using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_POE_18000498
{
    class MeleeUnit : Unit
    {
       

        public int PosX
        {
            get { return base.posX; }
            set { base.posX = value; }
        }

        public int PosY
        {
            get { return base.posY; }
            set { base.posY = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public int MaxHealth
        {
            get { return base.maxHealth; }
        }

        public int Speed
        {
            get { return base.speed; }
        }

        public int Attack
        {
            get { return base.attack; }
        }

        public int AttackRange
        {
            get { return base.attackRange; }
        }

        public string Symbol
        {
            get { return base.symbol; }
        }

    
        public Faction FactionType
        {
            get { return base.factionType; }
        }

        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        private int speedCounter = 1;
        List<Unit> units = new List<Unit>();
        Random r = new Random();
        Unit closestUnit;

        public MeleeUnit(int x, int y, Faction faction, int hp, int sp, int att, int attRange, string sym, bool isAtt)
            : base(x, y, hp, sp, att, attRange, sym, faction, isAtt)

        {


        }

        public override void Move()
        {
            if (closestUnit.posX > posX && PosX < 20)
            {
                posX++;
            }
            else if (closestUnit.posX > posX && PosX > 0)
            {
                posX--;
            }
            if (closestUnit.posY > posY && PosY < 20)
            {
                posY++;
            }
            else if (closestUnit.posY > posY && PosY > 0)
            {
                posY--;
            }
        }

        public override void Combat()
        {
            foreach (Unit u in units)
            {
                if (closestUnit.posX == u.posX && closestUnit.posY == u.posY)
                {
                    u.health = u.health - Attack;
                    IsAttacking = true;
                    break;
                }
            }
        }

        public override void CheckAttackRange(List<Unit> uni, Unit[,] unitMap)
        {
            units = uni;

            closestUnit = ClosestEnemy();
            int xDis, yDis;
            int distance;

            xDis = Math.Abs((PosX - closestUnit.posX) * (PosX - closestUnit.posX));
            yDis = Math.Abs((PosY - closestUnit.posY) * (PosY - closestUnit.posY));

            distance = (int)Math.Round(Math.Sqrt(xDis + yDis), 0);

            if(distance <= AttackRange)
            {
                Combat();
            }
            else
            {
                Move();
            }
        }

        public override Unit ClosestEnemy()
        {

            int xDis, yDis;
            double distance;
            double temp = 1000;
            Unit target = null;

            foreach (Unit u in units)
            {
                if (FactionType != u.factionType)
                {
                    xDis = Math.Abs((PosX - u.posX) * (PosX - u.posX));
                    yDis = Math.Abs((PosY - u.posY) * (PosY - u.posY));

                    distance = Math.Round(Math.Sqrt(xDis + yDis), 0);

                    if (distance < temp)
                    {

                        temp = distance;
                        target = u;
                    }
                }

            }
            return target;
        }

        public override void Death()
        {
            
        }
        public override string ToString()
        {
            return "Cavelry X" + PosX
                + " Y: " + PosY
                + "\nMax Health: " + MaxHealth
                + "\nHealth: " + Health
                + "\nSpeed: " + Speed
                + "\nAttack Damage: " + Attack
                + "\nAttack Range: " + AttackRange
                + "\nFaction: " + FactionType;
        }


    }
}

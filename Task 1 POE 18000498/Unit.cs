using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_1_POE_18000498
{
    enum Faction
    {
        Overwatch,
        Talon
    }

    abstract class Unit //added the int for poistion, health, speed,etc
    {
        public int posX, posY;
        public int health;
        public int maxHealth;
        public int speed;
        public int attack, attackRange;
        public string symbol;
        public Faction factionType;
        public bool isAttacking;

        public Unit(int x, int y, int hp, int sp, int att, int attRange, string sym, Faction faction, bool isAtt) //gives the value to position, health, speed, attack, etc
        {

            posX = x;
            posY = y;
            health = hp;
            speed = sp;
            attack = att;
            attackRange = attRange;
            symbol = sym;
            factionType = faction;
            isAttacking = isAtt;

            maxHealth = hp;
        }


        public abstract void Move();
        public abstract void Combat();
        public abstract void CheckAttackRange(List<Unit> uni, Unit[,] unitMap);
        public abstract Unit ClosestEnemy();
        public abstract void Death();
        public abstract override string ToString();

        
    }

}

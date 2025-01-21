using System;
using static RPGGame.Interval;

namespace RPGGame
{
    public class Unit
    {
        public string Name { get; }
        private float health;
        public float Health => health;
        public Interval Damage { get; } // Заменяем свойство Damage на Interval
        private float armor = 0.6f;

        public Unit(string name, int minDamage, int maxDamage) : this(name, new Interval(minDamage, maxDamage)) { }

        public Unit(string name, Interval damage)
        {
            Name = name;
            health = 100f; // Устанавливаем здоровье по умолчанию
            Damage = damage;
        }

        public float GetRealHealth()
        {
            return Health * (1f + armor);
        }

        public bool SetDamage(float value)
        {
            health -= value * armor;
            return health <= 0f; // Возвращаем true если юнит погиб
        }
    }
}



//Homework Memory

namespace RPGGame
{
    public class Weapon
    {
        public string Name { get; }
        public Interval Damage { get; }
        public float Durability { get; } = 1f;

        public Weapon(string name, int minDamage, int maxDamage) : this(name, new Interval(minDamage, maxDamage)) { }

        public Weapon(string name, Interval damage)
        {
            Name = name;
            Damage = damage;
        }

        public int GetDamage()
        {
            return (int)Damage.Get(); // Возвращаем случайное значение урона из интервала
        }
    }

    public struct Interval
    {
        private static Random random = new Random();
        private int minValue;
        private int maxValue;

        public int Min => minValue;
        public int Max => maxValue;

        public Interval(int minValue, int maxValue)
        {
            // Проверка допустимости входных значений
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("Некорректные входные данные: minValue больше maxValue. Значения поменяны местами.");
            }

            if (minValue < 0)
            {
                this.minValue = 0;
                Console.WriteLine("Некорректные входные данные: minValue отрицательное. Установлено значение 0.");
            }
            else
            {
                this.minValue = minValue;
            }

            if (maxValue < 0)
            {
                this.maxValue = 0;
                Console.WriteLine("Некорректные входные данные: maxValue отрицательное. Установлено значение 0.");
            }
            else
            {
                this.maxValue = maxValue;
            }

            if (this.minValue == this.maxValue)
            {
                this.maxValue += 10;
                Console.WriteLine("Некорректные входные данные: minValue равен maxValue. maxValue увеличено на 10.");
            }

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public float Get()
        {
            return (float)random.Next(minValue, maxValue + 1);
        }




        public struct Room
        {
            public Unit Unit { get; }
            public Weapon Weapon { get; }

            public Room(Unit unit, Weapon weapon)
            {
                Unit = unit;
                Weapon = weapon;
            }
        }


        public class Dungeon
        {
            private Room[] rooms;

            public Dungeon()
            {
                rooms = new Room[]
                {
                new Room(new Unit("Warrior", 5, 15), new Weapon("Sword", 5, 10)),
                new Room(new Unit("Mage", 3, 8), new Weapon("Staff", 2, 6)),
                new Room(new Unit("Rogue", 4, 12), new Weapon("Dagger", 1, 5)),
                new Room(new Unit("Paladin", 6, 14), new Weapon("Hammer", 4, 9)),
                };
            }
        }
    }
}

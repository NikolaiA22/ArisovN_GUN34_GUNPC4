using System;

namespace RPGGame
{
    public class Unit
    {
        // Открытые свойства
        public string Name { get; }
        private float health;
        public float Health => health;
        public int Damage { get; } = 5;
        private float armor = 0.6f;

        // Конструктор без аргументов
        public Unit() : this("Unknown Unit") { }

        // Конструктор с аргументом
        public Unit(string name)
        {
            Name = name;
            health = 100f; // Устанавливаем здоровье по умолчанию
        }

        // Метод для получения фактического здоровья
        public float GetRealHealth()
        {
            return Health * (1f + armor);
        }

        // Метод для получения урона
        public bool SetDamage(float value)
        {
            health -= value * armor;
            return health <= 0f; // Возвращаем true если юнит погиб
        }
    }

    public class Weapon
    {
        // Открытые свойства
        public string Name { get; }
        private int minDamage;
        private int maxDamage;
        public float Durability { get; } = 1f;

        // Конструктор с одним аргументом
        public Weapon(string name)
        {
            Name = name;
        }

        // Конструктор с двумя аргументами
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        // Метод для задания параметров урона
        private void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                (minDamage, maxDamage) = (maxDamage, minDamage);
                Console.WriteLine("Некорректные данные'{Name}'. Параметры урона поменяны местами.");
            }

            if (minDamage < 1)
            {
                this.minDamage = 1; // Устанавливаем минимальный урон в 1
                Console.WriteLine("Установка минимального урона для оружия '{Name}'.");
            }
            else
            {
                this.minDamage = minDamage;
            }

            if (maxDamage <= 1)
            {
                this.maxDamage = 10; // Устанавливаем максимальный урон в 10
            }
            else
            {
                this.maxDamage = maxDamage;
            }
        }

        // Метод для получения урона
        public int GetDamage()
        {
            return (minDamage + maxDamage) / 2; // Возвращаем среднее значение
        }
    }
}


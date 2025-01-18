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
            health = 100f; // Здоровье по умолчанию
        }

        // Фактическое здоровье
        public float GetRealHealth()
        {
            return Health * (1f + armor);
        }

        // получение урона
        public bool SetDamage(float value)
        {
            health -= value * armor;
            return health <= 0f;
        }
    }
}



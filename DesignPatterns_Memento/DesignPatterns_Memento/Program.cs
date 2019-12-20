using System;
using System.Collections.Generic;

namespace DesignPatterns_Memento
{
    //original source https://metanit.com/sharp/patterns/3.10.php
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Memento!");

            Game game = new Game();
            Hero hero = new Hero("Batman");
            hero.SayHi();

            game.History.Push(hero.SaveState());

            hero.Shoot();
            hero.Shoot();

            hero.RestoreState(game.History.Pop());

            hero.Shoot();

            Console.Read();

        }
    }

    class Hero
    {
        private int _bulletsCount = 10;
        private int _livesCount = 5;
        private string _name;

        public Hero(string name)
        {
            _name = name;
        }

        public void Shoot()
        {
            if (_bulletsCount > 0)
            {
                _bulletsCount--;
                Console.WriteLine($"Bang! {_bulletsCount} bullets left.");
            }
            else
            {
                Console.WriteLine("There are no bullets!");
            }
        }

        public HeroMemento SaveState()
        {
            Console.WriteLine($"State saving... Bullets : {_bulletsCount}, Lives : {_livesCount}");
            return new HeroMemento(_bulletsCount, _livesCount);
        }

        public void RestoreState(HeroMemento memento)
        {
            _bulletsCount = memento.BulletsCount;
            _livesCount = memento.LivesCount;
            Console.WriteLine($"Restoring state... Bullets : {_bulletsCount}, Lives : {_livesCount}");
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi! My name is {_name}");
        }
    }

    class HeroMemento
    {
        public int BulletsCount { get; set; }
        public int LivesCount { get; set; }

        public HeroMemento(int bulletsCount, int livesCount)
        {
            BulletsCount = bulletsCount;
            LivesCount = livesCount;
        }
    }

    class Game
    {
        public Stack<HeroMemento> History { get; private set; }

        public Game()
        {
            History = new Stack<HeroMemento>();
        }
    }
}

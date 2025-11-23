using System;
using System.Collections.Generic;

namespace PokemonCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokémon Combat Demo";
            Console.WriteLine("=== Pokémon Combat ===");

            Pokemon pikachu = new Pokemon("Pikachu", 100, new List<Move>
            {
                new Move("Thunderbolt", 25),
                new Move("Quick Attack", 15),
                new Move("Iron Tail", 20)
            });

            Pokemon charmander = new Pokemon("Charmander", 100, new List<Move>
            {
                new Move("Flamethrower", 25),
                new Move("Scratch", 10),
                new Move("Ember", 15)
            });

            Battle battle = new Battle(pikachu, charmander);
            battle.Start();
        }
    }

    class Pokemon
    {
        public string Name { get; }
        public int HP { get; set; }
        public List<Move> Moves { get; }

        public Pokemon(string name, int hp, List<Move> moves)
        {
            Name = name;
            HP = hp;
            Moves = moves;
        }

        public bool IsFainted => HP <= 0;
    }

    class Move
    {
        public string Name { get; }
        public int Damage { get; }

        public Move(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
    }

    class Battle
    {
        private Pokemon player;
        private Pokemon enemy;
        private Random random = new Random();

        public Battle(Pokemon player, Pokemon enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Start()
        {
            while (!player.IsFainted && !enemy.IsFainted)
            {
                Console.WriteLine($"\n{player.Name} HP: {player.HP} | {enemy.Name} HP: {enemy.HP}");
                Console.WriteLine("Choose your move:");

                for (int i = 0; i < player.Moves.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.Moves[i].Name} (Damage: {player.Moves[i].Damage})");
                }

                int choice;
                while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out choice) || choice < 1 || choice > player.Moves.Count)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

                Move playerMove = player.Moves[choice - 1];
                Attack(player, enemy, playerMove);

                if (enemy.IsFainted)
                {
                    Console.WriteLine($"{enemy.Name} fainted! You win!");
                    break;
                }

                // Enemy turn
                Move enemyMove = enemy.Moves[random.Next(enemy.Moves.Count)];
                Attack(enemy, player, enemyMove);

                if (player.IsFainted)
                {
                    Console.WriteLine($"{player.Name} fainted! You lose!");
                    break;
                }
            }
        }

        private void Attack(Pokemon attacker, Pokemon defender, Move move)
        {
            Console.WriteLine($"{attacker.Name} used {move.Name}!");
            defender.HP -= move.Damage;
            if (defender.HP < 0) defender.HP = 0;
            Console.WriteLine($"{defender.Name} took {move.Damage} damage! Remaining HP: {defender.HP}");
        }
    }
}
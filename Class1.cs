using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik
{
    class Weapon
    {
        public int Damage
        {
            get { return Damage; }
            private set
            {
                if (value < 0)
                    throw new InvalidOperationException();
                else
                    Damage = value;
            }
        }
        public int Bullets { get; private set; }

        public void Fire(Player player)
        {
            if (Bullets <= 0)
                return;

            player.ApplyDamage(this);
            Bullets -= 1;
        }
    }

    class Player
    {
        public int Health { get; private set; }

        public void ApplyDamage(Weapon weapon)
        {
            Health -= weapon.Damage;
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}

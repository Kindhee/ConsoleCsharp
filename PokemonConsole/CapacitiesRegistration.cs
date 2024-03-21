using PokemonConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class CapacitiesRegistration
    {
        Dictionary<string, Capacity> _capacities;

        public CapacitiesRegistration() 
        {

            _capacities = new Dictionary<string, Capacity> {

                {"_bite", new Capacity("Bite", AttributType.Normal, 5, 100)},
                {"_stomp", new Capacity("Stomp", AttributType.Normal, 10, 90)},
                {"_firePunch", new Capacity("Fire Punch", AttributType.Fire, 15, 95)},
                {"_flameThrower", new Capacity("Flame Thrower", AttributType.Fire, 40, 60)},
                {"_waterGun", new Capacity("Water Gun", AttributType.Water, 20, 80)},
                {"_jetPunch", new Capacity("Jet Punch", AttributType.Water, 30, 70)},
                {"_leafBlade", new Capacity("Leaf Blade", AttributType.Plant, 25, 75)},
                {"_bulletSeed", new Capacity("Bullet Speed", AttributType.Plant, 15, 90)},

            };
        }
        public Dictionary<string, Capacity> Capacities { get => _capacities; set => _capacities = value; }


        public List<Capacity> GetCapacities(List<string> listToConvert)
        {
            List < Capacity > capacities = new List < Capacity >();

            for (int i = 0; i < listToConvert.Count; i++)
            {
                capacities.Add(_capacities[listToConvert[i]]);
            }
            return capacities;
        }

    }
}
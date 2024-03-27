using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    internal class TypeManager
    {
        private Dictionary<AttributType, Dictionary<AttributType, double>> _weaknesses = new Dictionary<AttributType, Dictionary<AttributType, double>>();
        public Dictionary<AttributType, Dictionary<AttributType, double>> Weakness { get => _weaknesses; }

        public TypeManager()
        {
            _weaknesses[AttributType.Normal] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 1.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 0.5 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Fire] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 0.5 },
                { AttributType.Plant, 2.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 2.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 0.5 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 2.0 },
                { AttributType.Rock, 0.5 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Water] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 2.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 0.5 },
                { AttributType.Electric, 0.5 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 2.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 2.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Plant] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 0.5 },
                { AttributType.Water, 2.0 },
                { AttributType.Plant, 1.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 0.5 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 0.5 },
                { AttributType.Ground, 2.0 },
                { AttributType.Flying, 0.5 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 0.5 },
                { AttributType.Rock, 2.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Electric] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 2.0 },
                { AttributType.Plant, 1.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 0.5 },
                { AttributType.Flying, 2.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Ice] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 0.5 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 2.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 0.5 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 2.0 },
                { AttributType.Flying, 2.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 0.5 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Fighting] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 2.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 1.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 2.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 0.5 },
                { AttributType.Psychic, 0.5 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 2.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Poison] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 2.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 0.5 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 0.5 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Ground] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 2.0 },
                { AttributType.Water, 0.5 },
                { AttributType.Plant, 0.5 },
                { AttributType.Electric, 2.0 },
                { AttributType.Ice, 0.5 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 2.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 2.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Flying] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 2.0 },
                { AttributType.Electric, 0.5 },
                { AttributType.Ice, 0.5 },
                { AttributType.Fighting, 2.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 2.0 },
                { AttributType.Rock, 0.5 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Psychic] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 0.5 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 2.0 },
                { AttributType.Poison, 2.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 0.5 }
            };
            _weaknesses[AttributType.Bug] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 0.5 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 2.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 0.5 },
                { AttributType.Psychic, 2.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 0.5 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Rock] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 2.0 },
                { AttributType.Water, 0.5 },
                { AttributType.Plant, 0.5 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 2.0 },
                { AttributType.Fighting, 0.5 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 0.5 },
                { AttributType.Flying, 2.0 },
                { AttributType.Psychic, 1.0 },
                { AttributType.Bug, 2.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 1.0 }
            };
            _weaknesses[AttributType.Ghost] = new Dictionary<AttributType, double>
            {
                { AttributType.Normal, 1.0 },
                { AttributType.Fire, 1.0 },
                { AttributType.Water, 1.0 },
                { AttributType.Plant, 1.0 },
                { AttributType.Electric, 1.0 },
                { AttributType.Ice, 1.0 },
                { AttributType.Fighting, 1.0 },
                { AttributType.Poison, 1.0 },
                { AttributType.Ground, 1.0 },
                { AttributType.Flying, 1.0 },
                { AttributType.Psychic, 2.0 },
                { AttributType.Bug, 1.0 },
                { AttributType.Rock, 1.0 },
                { AttributType.Ghost, 1.0 }
            };
        }

        public double GetRatioType(AttributType attackType, AttributType defenseType)
        {
            return _weaknesses[attackType][defenseType];    
        }
    }
}
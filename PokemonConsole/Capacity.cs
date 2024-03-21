using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Capacity
    {
        string _name;

        AttributType _CapacityType;

        int _attack;
        int _accuracy;

        public Capacity(string name, AttributType capacityType, int attack, int accuracy)
        {
            _name = name;

            _CapacityType = capacityType;

            _attack = attack;
            _accuracy = accuracy;
        }

        public string Name { get => _name; set => _name = value; }
        public AttributType Type { get => _CapacityType;  set => _CapacityType = value; }
        public int Attack { get => _attack;  set => _attack = value; }
        public int Accuracy { get => _accuracy;  set => _accuracy = value; }
    }
}
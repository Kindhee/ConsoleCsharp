using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    internal class TypeManager
    {
        private Dictionary<string, Dictionary<string, double>> _weaknesses = new Dictionary<string, Dictionary<string, double>>();
        public Dictionary<string, Dictionary<string, double>> Weakness { get => _weaknesses; }

        public TypeManager()
        {
            _weaknesses["Normal"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 1.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 0.5 },
                { "Poison", 1.0 },
                { "Ground", 1.0 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 1.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Fire"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 0.5 },
                { "Plant", 2.0 },
                { "Electric", 1.0 },
                { "Ice", 2.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 0.5 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 2.0 },
                { "Rock", 0.5 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Water"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 2.0 },
                { "Water", 1.0 },
                { "Plant", 0.5 },
                { "Electric", 0.5 },
                { "Ice", 1.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 2.0 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 2.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Plant"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 0.5 },
                { "Water", 2.0 },
                { "Plant", 1.0 },
                { "Electric", 1.0 },
                { "Ice", 0.5 },
                { "Fighting", 1.0 },
                { "Poison", 0.5 },
                { "Ground", 2.0 },
                { "Flying", 0.5 },
                { "Psychic", 1.0 },
                { "Bug", 0.5 },
                { "Rock", 2.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Electric"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 2.0 },
                { "Plant", 1.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 0.5 },
                { "Flying", 2.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 1.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Ice"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 0.5 },
                { "Water", 1.0 },
                { "Plant", 2.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 0.5 },
                { "Poison", 1.0 },
                { "Ground", 2.0 },
                { "Flying", 2.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 0.5 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Fighting"] = new Dictionary<string, double>
            {
                { "Normal", 2.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 1.0 },
                { "Electric", 1.0 },
                { "Ice", 2.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 1.0 },
                { "Flying", 0.5 },
                { "Psychic", 0.5 },
                { "Bug", 1.0 },
                { "Rock", 2.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Poison"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 2.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 0.5 },
                { "Flying", 1.0 },
                { "Psychic", 0.5 },
                { "Bug", 1.0 },
                { "Rock", 1.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Ground"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 2.0 },
                { "Water", 0.5 },
                { "Plant", 0.5 },
                { "Electric", 2.0 },
                { "Ice", 0.5 },
                { "Fighting", 1.0 },
                { "Poison", 2.0 },
                { "Ground", 1.0 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 2.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Flying"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 2.0 },
                { "Electric", 0.5 },
                { "Ice", 0.5 },
                { "Fighting", 2.0 },
                { "Poison", 1.0 },
                { "Ground", 1.0 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 2.0 },
                { "Rock", 0.5 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Psychic"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 0.5 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 2.0 },
                { "Poison", 2.0 },
                { "Ground", 1.0 },
                { "Flying", 1.0 },
                { "Psychic", 1.0 },
                { "Bug", 1.0 },
                { "Rock", 1.0 },
                { "Ghost", 0.5 }
            };
            _weaknesses["Bug"] = new Dictionary<string, double>
            {
                { "Normal", 0.5 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 2.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 1.0 },
                { "Flying", 0.5 },
                { "Psychic", 2.0 },
                { "Bug", 1.0 },
                { "Rock", 0.5 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Rock"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 2.0 },
                { "Water", 0.5 },
                { "Plant", 0.5 },
                { "Electric", 1.0 },
                { "Ice", 2.0 },
                { "Fighting", 0.5 },
                { "Poison", 1.0 },
                { "Ground", 0.5 },
                { "Flying", 2.0 },
                { "Psychic", 1.0 },
                { "Bug", 2.0 },
                { "Rock", 1.0 },
                { "Ghost", 1.0 }
            };
            _weaknesses["Ghost"] = new Dictionary<string, double>
            {
                { "Normal", 1.0 },
                { "Fire", 1.0 },
                { "Water", 1.0 },
                { "Plant", 1.0 },
                { "Electric", 1.0 },
                { "Ice", 1.0 },
                { "Fighting", 1.0 },
                { "Poison", 1.0 },
                { "Ground", 1.0 },
                { "Flying", 1.0 },
                { "Psychic", 2.0 },
                { "Bug", 1.0 },
                { "Rock", 1.0 },
                { "Ghost", 1.0 }
            };
        }
    }
}
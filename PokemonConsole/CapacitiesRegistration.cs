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

                {"_tailWhip", new Capacity("Tail Whip", AttributType.Normal, 5, 100)},
                {"_bite", new Capacity("Bite", AttributType.Normal, 10, 90)},
                {"_megaPunch", new Capacity("Mega Punch", AttributType.Normal, 10, 90)},
                {"_headButt", new Capacity("Head Butt", AttributType.Normal, 10, 90)},

                {"_firePunch", new Capacity("Fire Punch", AttributType.Fire, 15, 95)},
                {"_flameThrower", new Capacity("Flame Thrower", AttributType.Fire, 40, 60)},

                {"_waterGun", new Capacity("Water Gun", AttributType.Water, 20, 80)},
                {"_bubble", new Capacity("Bubble", AttributType.Water, 30, 70)},

                {"_razorLeaf", new Capacity("Razor Leaf", AttributType.Plant, 25, 75)},
                {"_vineWhip", new Capacity("Vine Whip", AttributType.Plant, 15, 90)},

                {"_thunder", new Capacity("Thunder", AttributType.Electric, 15, 90)},
                {"_thunderPunch", new Capacity("Thunder Punch", AttributType.Electric, 25, 75)},

                {"_iceBeam", new Capacity("Ice Beam", AttributType.Ice, 25, 75)},
                {"_blizzard", new Capacity("Blizzard", AttributType.Ice, 25, 75)},

                {"_lowKick", new Capacity("Low Kick", AttributType.Fighting, 25, 75)},
                {"_submission", new Capacity("Submission", AttributType.Fighting, 25, 75)},

                {"_toxic", new Capacity("Toxic", AttributType.Poison, 25, 75)},
                {"_poisonSting", new Capacity("Poison Sting", AttributType.Poison, 25, 75)},

                {"_earthQuake", new Capacity("Earth Quake", AttributType.Ground, 25, 75)},
                {"_fissure", new Capacity("Fissure", AttributType.Ground, 25, 75)},

                {"_fly", new Capacity("Fly", AttributType.Flying, 25, 75)},
                {"_wingAttack", new Capacity("Wing Attack", AttributType.Flying, 25, 75)},

                {"_psychic", new Capacity("Psychic", AttributType.Psychic, 25, 75)},
                {"_psybeam", new Capacity("Psybeam", AttributType.Psychic, 25, 75)},

                {"_stringShot", new Capacity("String Shot", AttributType.Bug, 25, 75)},
                {"_twinNeedle", new Capacity("Twin Needle", AttributType.Bug, 25, 75)},

                {"_rockSlide", new Capacity("Rock Slide", AttributType.Rock, 25, 75)},
                {"_rockThrow", new Capacity("Rock Throw", AttributType.Rock, 25, 75)},

                {"_lick", new Capacity("Lick", AttributType.Ghost, 25, 75)},
                {"_nightShade", new Capacity("Night Shade", AttributType.Ghost, 25, 75)},
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
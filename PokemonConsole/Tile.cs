using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Tile
    {
        public TileType _tileType;

        public Tile(TileType tileType)
        {
            _tileType = tileType;
        }

        public string GetString()
        {
            switch (_tileType)
            {

                case TileType.Empty:
                    return " ";


                case TileType.Player:
                    return "P";

                case TileType.Bush:
                    return "B";

                case TileType.Tree:
                    return "T";

                case TileType.Wall:
                    return "W";

                case TileType.Roof:
                    return "R";

                case TileType.Door:
                    return "D";

                case TileType.Pokedoor:
                    return "P";

                case TileType.Challenger:
                    return "C";

                case TileType.Pokeball:
                    return "O";
                
                case TileType.DoorH:
                    return "H";

                default:
                    return " ";
                    // or
                    //break;
            }
        }
    }
}

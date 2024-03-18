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

                case TileType.Enemy:
                    return "E";

                case TileType.Tree:
                    return "T";

                default:
                    return " ";
                    // or
                    //break;
            }
        }
    }
}

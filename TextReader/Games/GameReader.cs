using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    abstract class GameReader
    {
        public GameType Type;

        protected GameReader(GameType type)
        {
            Type = type;
        }

    }
}

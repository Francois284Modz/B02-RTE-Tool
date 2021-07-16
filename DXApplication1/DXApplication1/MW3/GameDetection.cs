using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DXApplication1.Connection;
using System.Threading.Tasks;
using PS3Lib;

namespace DXApplication1.MW3
{
    class GameDetection
    {
        public static string CurrentGame;
        public static string CurrentVersion;
        private static PS3API PS3 = new PS3API();

        public static bool CheckGame(string memory, string regions)
        {
            return regions.Contains(memory);
        }

        public static void GetGame()
        {
            if (Connection.IsAttached)
            {
                string MemoryRead = PS3.Extension.ReadString(0x10010251);
                byte MemoryReadMode = PS3.Extension.ReadByte(0x1001D);
                string Regions = "BLUS30838 BLES01428 BLES01429 BLES01430 BLES01431 BLES01432 BLES01433 BLES01434 BLUS30887 BLUS30888";
                CurrentGame = "Unknown";
                CurrentVersion = "Unknown";
                switch (CheckGame(MemoryRead, Regions))
                {
                    case true:
                        CurrentGame = MemoryReadMode == 0x6A ? "Modern Warfare 3 (Special Ops)" : "Modern Warfare 3 (Multiplayer)";
                        CurrentVersion = MemoryRead;
                        break;
                    case false:
                        CurrentGame = "Unknown";
                        CurrentVersion = "Unknown";
                        break;
                    default:
                        CurrentGame = "Unknown";
                        CurrentVersion = "Unknown";
                        break;
                }
            }
            else
            {
                CurrentGame = "Unknown";
                CurrentVersion = "Unknown";
            }
        }
    }
}

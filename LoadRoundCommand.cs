using CommandSystem;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Helpers;
using PluginAPI.Core;
using Utf8Json;

namespace NWAPIBulletHoleVisualizer
{
    //disabled !!!
    //[CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LoadRoundCommand : ICommand
    {
        public string Command { get; } = "bvloadround";

        public string[] Aliases { get; } = new string[] { "bvlr" };

        public string Description { get; } = "Load a previous round's bullets for visualization.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string path = Path.Combine(Plugin.PluginHandler.PluginDirectoryPath, "rounds", arguments.ElementAt(0) + ".json");
            if (!File.Exists(path))
            {
                response = "Round not found";
                return false;
            }

            string json = File.ReadAllText(path);

            Utils.Clear();
            PostData postData = JsonSerializer.Deserialize<PostData>(json);
            Utils.SetBullets(postData.Bullets);
            Utils.LoadedRound = true;
            Utils.RegenMap(postData.Seed);

            response = "Loaded.";
            return true;
        }
    }
}

using CommandSystem;
using PluginAPI.Core;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAPIBulletHoleVisualizer
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class VisualizerCommand : ICommand
    {
        public string Command { get; } = "bulletvisualizer";

        public string[] Aliases { get; } = new string[] { "bv" };

        public string Description { get; } = "Enable/disable bullet hole visualizer.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender plrSender))
            {
                response = "Not a player";
                return false;
            }
            //Player player = Player.Get(plrSender.ReferenceHub);
            if (Utils.IsVisualizing(plrSender.ReferenceHub))
            {
                Utils.StopVisualizing(plrSender.ReferenceHub);
                response = "No longer visualizing";
                return true;
            }
            else
            {
                Utils.StartVisualizing(plrSender.ReferenceHub, true);
                response = "Now visualizing";
                string searching = null;
                if (arguments.Count > 0)
                {
                    searching = string.Join(" ", arguments);
                    response = $"Now visualizing, with filter: '{searching}'";
                }
                Utils.StartVisualizing(plrSender.ReferenceHub, true, searching);
                return true;
            }
        }
    }

    //[CommandHandler(typeof(GameConsoleCommandHandler))]
    //public class VisualizerCommandGameConsole : ICommand
    //{
    //    public string Command { get; } = "bulletvisualizer";

    //    public string[] Aliases { get; } = new string[] { "bv" };

    //    public string Description { get; } = "Enable/disable bullet hole visualizer.";

    //    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    //    {
    //        if (!(sender is PlayerCommandSender plrSender))
    //        {
    //            response = "Not a player";
    //            return false;
    //        }
    //        Player player = Player.Get(plrSender.ReferenceHub);
    //        if (Utils.IsVisualizing(player))
    //        {
    //            Utils.StopVisualizing(player);
    //            response = "No longer visualizing";
    //            return true;
    //        }
    //        else
    //        {
    //            Utils.StartVisualizing(player, false);
    //            response = "Now visualizing";
    //            return true;
    //        }
    //    }
    //}
}

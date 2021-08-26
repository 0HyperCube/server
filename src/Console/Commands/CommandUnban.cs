﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using GameServer.Database;
using GameServer.Server;

namespace GameServer.Logging.Commands
{
    public class CommandUnban : ICommand
    {
        public string Description { get; set; }
        public string Usage { get; set; }
        public string[] Aliases { get; set; }

        public CommandUnban()
        {
            Description = "Pardon a specified player";
            Usage = "<player>";
            Aliases = new string[] { "pardon" };
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.Log("Please provide a player name to pardon");
                return;
            }

            var cmd = new ServerInstructions();
            cmd.Set(ServerInstructionOpcode.PardonPlayer, args[0]);

            ENetServer.ServerInstructions.Enqueue(cmd);
        }
    }
}
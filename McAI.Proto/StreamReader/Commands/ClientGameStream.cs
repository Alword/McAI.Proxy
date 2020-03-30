﻿using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Commands
{
    public class ClientGameStream : ICommand<int, byte[]>
    {
        protected readonly Dictionary<int, Command> commands;
        public ClientGameStream(Dictionary<int, Command> commands)
        {
            this.commands = commands;
        }

        public void Execute(int length, byte[] array)
        {
            Varint.TryParse(ref array, out int compressed);
            Varint.TryParse(ref array, out int packetId);

            if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
            }
            else
            {
                string log = $"->{length}:{compressed}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                Program.Log(log);
            }
        }
    }
}

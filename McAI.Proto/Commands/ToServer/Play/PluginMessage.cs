﻿using McAI.Proto.Packet.ToServer.Play;

namespace McAI.Proto.Commands.ToServer.Play
{
    public class PluginMessage : Command
    {
        public PluginMessage(bool isLogging) : base(isLogging)
        {
        }

        public override void Execute(byte[] array)
        {
            PluginMessagePacket pluginMessagePacket = new PluginMessagePacket();
            pluginMessagePacket.Read(array);
            Debug(pluginMessagePacket.ToString());
        }
    }
}
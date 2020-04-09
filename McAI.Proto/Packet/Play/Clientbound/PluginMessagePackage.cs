﻿using McAI.Proto.Extentions;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class PluginMessagePackage : BasePacket
    {
        public override int PacketId => 0x19;
        public string Channel;
        public byte[] Data;

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Channel);
            Data = array;
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"PluginMessage Channel: {Channel} Data:{Data.ToHexString()}";
        }
    }
}

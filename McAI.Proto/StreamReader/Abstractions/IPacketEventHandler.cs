﻿using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Model;

namespace McAI.Proto.StreamReader.Abstractions
{
    public interface IPacketEventHandler
    {
        public void OnPacket(PacketKey type, BasePacket packet);
    }
}

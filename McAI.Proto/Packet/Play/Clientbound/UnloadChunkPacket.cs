﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class UnloadChunkPacket : BasePacket
    {
        public override int PacketId => 0x1E;
        public int ChunkX;
        public int ChunkZ;

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out ChunkX);
            McInt.TryParse(ref array, out ChunkZ);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"<[UnloadChunk|{base.ToString()}] ChunkX: {ChunkX} ChunkZ: {ChunkZ}";
        }
    }
}
﻿using McAI.Proto.Extentions;
using McAI.Proto.StreamReader.Enum;

namespace McAI.Proto.StreamReader.Model
{
    public class McConnectionContext
    {
        public readonly PacketEventHub packetEventHub;
        public bool IsCompressed { get; set; }
        public bool Encryption { get; set; }
        public string EncryptionPrivatekey { get; set; }
        public string EncryptionPuivatekey { get; set; }


        public int Length;
        public int CompressionLength;
        public int PacketId;
        public ConnectionStates ConnectionState { get; set; }
        public Bounds BoundTo { get; set; }
        public byte[] Data;

        public McConnectionContext(PacketEventHub packetEventHub)
        {
            this.packetEventHub = packetEventHub;
        }

        public override string ToString()
        {
            return $"Error: 0x{PacketId:X02} |{ConnectionState} | {BoundTo} | {CompressionLength} | {Data.ToHexString()}";
        }
    }
}

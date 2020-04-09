﻿using McAI.Proto.Enum;
using McAI.Proto.Types;
using System.Collections.Generic;

namespace McAI.Proto.Packet.Handshaking.Serverbound
{
    public class HandshakePacket : BasePacket
    {
        public int ProtocolVersion;//578; // VarInt See protocol version numbers (currently 578 in Minecraft 1.15.2)  
        public string Address; // String (255) Hostname or IP, e.g. localhost or 127.0.0.1 
        public ushort Port; // Unsigned Short 
        public LoginStates LoginState; // VarInt Enum 1 for status, 2 for login
        public override int PacketId => 0x00;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out ProtocolVersion);

            McString.TryParse(ref array, out Address);

            McUnsignedShort.TryParse(ref array, out Port);

            McVarint.TryParse(ref array, out int loginState);
            LoginState = (LoginStates)loginState;
        }

        public override string ToString()
        {
            return $"Handshake PV: {ProtocolVersion} Address: {Address} Port:{Port} LoginState: {LoginState}";
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(McVarint.ToBytes(ProtocolVersion));
            bytes.AddRange(McString.ToBytes(Address));
            bytes.AddRange(McUnsignedShort.ToBytes(Port));
            bytes.AddRange(McVarint.ToBytes((int)LoginState));
            return bytes.ToArray();
        }
    }
}

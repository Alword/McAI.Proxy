﻿using McAI.Proto.Enum;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class ChangeGameStatePacket : BasePacket
    {
        public override int PacketId => 0x1F;

        public Reasons Reason; //Unsigned Byte
        public float Value;

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out byte reason);
            Reason = (Reasons)reason;
            McFloat.TryParse(ref array, out Value);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[ChangeGameState] Reason:{Reason} Value:{Value}";
        }
    }
}

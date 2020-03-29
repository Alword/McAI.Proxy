﻿using McAI.Proto.Model.Packet.ToServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.Client
{
    public class LoginStart : Command
    {
        private readonly LoginStartPacket loginStartPacket;
        public LoginStart(bool isLogging = false) : base(isLogging)
        {
            loginStartPacket = new LoginStartPacket();
        }
        public override void Execute(byte[] array)
        {
            loginStartPacket.Read(array);
            Debug($"[Login] {loginStartPacket.Name}");
        }
    }
}

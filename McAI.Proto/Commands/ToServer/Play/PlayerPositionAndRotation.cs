﻿using System;
using System.Linq;

namespace McAI.Proto.Commands.ToServer.Game
{
    public class PlayerPositionAndRotation : Command
    {
        public PlayerPositionAndRotation(bool isLogging = false) : base(isLogging)
        {

        }

        public override void Execute(byte[] array)
        {
            byte[] reverse = array.Reverse().ToArray();
            double x = BitConverter.ToDouble(reverse[25..33]);
            double y = BitConverter.ToDouble(reverse[17..25]);
            double z = BitConverter.ToDouble(reverse[9..17]);
            float yaw = BitConverter.ToSingle(reverse[5..9]);
            float pitch = BitConverter.ToSingle(reverse[1..5]);
            bool onground = reverse[0] == 1;

            Debug($"x:{x} y:{y} z:{z} yaw:{yaw} pitch:{pitch} onground:{onground}");
        }
    }
}
﻿using System;

namespace McAI.Proto.Extentions
{
    public static class ByteExtentions
    {
        public static string ToHexString(this byte[] data)
        {
            return BitConverter.ToString(data);
        }
    }
}

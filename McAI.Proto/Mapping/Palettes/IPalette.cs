﻿using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping.Palettes
{
    public interface IPalette
    {
        uint IdForState(BlockState state);
        BlockState StateForId(uint id);
        byte GetBitsPerBlock();
        void Read(byte[] data);
        void Write(byte[] data);
    }
}
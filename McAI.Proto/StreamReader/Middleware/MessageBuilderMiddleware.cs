﻿using McAI.Proto.StreamReader.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace McAI.Proto.StreamReader.Middleware
{
    public class MessageBuilderMiddleware : McMiddleware
    {
        protected int length = 0;
        protected int lengthLength = 0;
        protected List<byte> queue = new List<byte>();

        public MessageBuilderMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext ctx)
        {
            queue.AddRange(ctx.Data);
            while (queue.Count > 0)
            {
                ctx.Data = queue.ToArray();
                try
                {
                    McVarint.TryParse(ctx.Data, out lengthLength, out length);
                }
                catch (IndexOutOfRangeException)
                {
                    Debug.WriteLine("Packet is too small, read next packet");
                    if (queue.Count > 5)
                        throw;
                    else
                        break;
                }
                if (length + lengthLength > queue.Count) break;

                ctx.Data = ctx.Data[lengthLength..(length + lengthLength)];
                queue.RemoveRange(0, length + lengthLength);

                ctx.Length = length;
                _next?.Invoke(ctx);
            }
        }
    }
}

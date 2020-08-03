﻿using McAI.BOT.AgentEventHandlers;
using McAI.Proto;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace McAI.BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            // rearrange chunk 
            ConnectionListner connectionListner = new ConnectionListner();
            Agent agent = new Agent("192.168.1.69", 25565);
            agent.OnRecive += connectionListner.ReciveListner;
            agent.OnSend += connectionListner.SendListner;
            connectionListner.Subscribe(new PacketKey(0x21, ConnectionStates.Play, Bounds.Client), new KeepAlive(agent));
            connectionListner.Subscribe(new PacketKey(0x49, ConnectionStates.Play, Bounds.Client), new Respawn(agent));
            connectionListner.Subscribe(new PacketKey(0x36, ConnectionStates.Play, Bounds.Client), new TeleportConfirm(agent));
            connectionListner.Subscribe(new PacketKey(0x22, ConnectionStates.Play, Bounds.Client), new ReadChunkData(agent));
            connectionListner.Subscribe(new PacketKey(0x0F, ConnectionStates.Play, Bounds.Client), new ReadChatMessage(agent));

            UpdatePlayerInfo updatePlayerInfo = new UpdatePlayerInfo(agent);
            connectionListner.Subscribe(new PacketKey(0x05, ConnectionStates.Play, Bounds.Client), updatePlayerInfo);
            connectionListner.Subscribe(new PacketKey(0x34, ConnectionStates.Play, Bounds.Client), updatePlayerInfo);

            UpdateEntityPosition updateEntityPosition = new UpdateEntityPosition(agent);
            connectionListner.Subscribe(new PacketKey(0x29, ConnectionStates.Play, Bounds.Client), updateEntityPosition);
            connectionListner.Subscribe(new PacketKey(0x05, ConnectionStates.Play, Bounds.Client), updateEntityPosition);
            connectionListner.Subscribe(new PacketKey(0x2A, ConnectionStates.Play, Bounds.Client), updateEntityPosition);
            connectionListner.Subscribe(new PacketKey(0x57, ConnectionStates.Play, Bounds.Client), updateEntityPosition);

            BlockChangeUpdate blockChangeUpdate = new BlockChangeUpdate(agent);
            connectionListner.Subscribe(new PacketKey(0x0C, ConnectionStates.Play, Bounds.Client), blockChangeUpdate);
            connectionListner.Subscribe(new PacketKey(0x10, ConnectionStates.Play, Bounds.Client), blockChangeUpdate);

            connectionListner.Subscribe(new PacketKey(0x1E, ConnectionStates.Play, Bounds.Client), new UnloadChunk(agent));
            connectionListner.Subscribe(new TestHandler());
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            // GoForward goForward = new GoForward(agent);
            // goForward.Start(cancelTokenSource.Token);

            Run(agent).GetAwaiter().GetResult();
            while (true)
            {
                ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.Escape)
                    break;
                if (e.Key == ConsoleKey.S)
                    cancelTokenSource.Cancel();
            }
        }

        public static async Task Run(Agent agent)
        {
            await agent.Login("NeAlword");

        }
    }
}

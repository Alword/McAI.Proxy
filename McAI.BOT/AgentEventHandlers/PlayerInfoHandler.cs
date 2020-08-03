﻿using McAI.BOT.Model.PlayerContext;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Model;

namespace McAI.BOT.AgentEventHandlers
{
    public class PlayerInfoHandler : BaseAgentEventHandler<PlayerInfoPacket>
    {
        private readonly Players players;
        public PlayerInfoHandler(Agent agent) : base(agent)
        {
            players = agent.gameState.Players;
        }

        public override void OnPacket(PlayerInfoPacket data)
        {
            if (data.Players != null)
            {
                if (data.Action == 0)
                {
                    foreach (var player in data.Players)
                    {
                        players.Add(new Model.Player()
                        {
                            UUID = player.UUID,
                            Nickname = player.Name,
                            Ping = player.Ping,
                            Gamemode = player.Gamemode
                        });
                    }
                }

                if (data.Action == 1)
                {
                    foreach (var player in data.Players)
                    {
                        players.ContainsGuid(player.UUID).Gamemode = player.Gamemode;
                    }
                }

                if (data.Action == 2)
                {
                    foreach (var player in data.Players)
                    {
                        players.ContainsGuid(player.UUID).Ping = player.Ping;
                    }
                }

                if (data.Action == 4)
                {
                    foreach (var player in data.Players)
                    {
                        players.Remove(player.UUID);
                    }
                }
            }
        }
    }
}
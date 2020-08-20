﻿using Bost.BOT.Model;
using Bost.Proto.Mapping;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.BOT.AgentEventHandlers
{
    public class MultiBlockChangeHandler : BaseAgentEventHandler<MultiBlockChangePacket>
    {
        private readonly World world;
        public MultiBlockChangeHandler(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }

        public override void OnPacket(MultiBlockChangePacket data)
        {
            foreach (var record in data.Records)
            {
                Int3 location = new Int3(
                    (record.HorizontalPosition >> 4 & 15) + (data.ChunkX * 16),
                    record.YCoordinate,
                    (record.HorizontalPosition & 15) + (data.ChunkZ * 16));
                world.SetBlockId(location, new BlockId((uint)record.BlockID));
            }
        }
    }
}
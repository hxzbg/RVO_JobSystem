using Nebukam.JobAssist;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEditor.UI;
using static Nebukam.JobAssist.Extensions;

namespace Nebukam.ORCA
{
    public class AgentEntitiesProvider : AgentProvider
    {
        EntityQuery m_EntityQuery;
        EntityManager m_EntityManager;
        public AgentEntitiesProvider()
        {
            m_EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            m_EntityQuery = m_EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<AgentData>()
            );
        }

        protected override void InternalLock()
        {
            base.InternalLock();
        }

        protected override void Prepare(ref Unemployed job, float delta)
        {
            var array = m_EntityQuery.ToComponentDataArrayAsync<AgentData>(Allocator.TempJob, out JobHandle jobhandle);
            jobhandle.TryComplete();

            int agentCount = array.Length;
            MakeLength(ref m_outputAgents, agentCount);
            array.CopyTo(m_outputAgents);
            
            array.Dispose();
        }
    }
}

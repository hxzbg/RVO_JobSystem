using Unity.Entities;
using Nebukam.Common;
using Nebukam.JobAssist;
using Unity.Collections;
using System.Collections.Generic;

namespace Nebukam.ORCA
{
    /// <summary>
    /// Applies computed simulation result
    /// and update Agent's position and velocity
    /// </summary>
    public class ORCAEntitiesApply : ORCAApply
    {
        protected override void Apply(ref ORCAApplyJob job)
        {
            base.Apply(ref job);
        }
    }
}

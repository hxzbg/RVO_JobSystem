// Copyright (c) 2021 Timothé Lapetite - nebukam@gmail.com
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Nebukam.ORCA
{
    /// <summary>
    /// Job-friendly Agent data.
    /// </summary>
    [BurstCompile]
    public struct AgentData : IComponentData
    {
        public int index;
        public int kdIndex;

        public float2 position;
        public float baseline;
        public float2 prefVelocity;
        public float2 velocity;

        public float height;
        public float radius;
        public float radiusObst;
        public float maxSpeed;

        public int maxNeighbors;
        public float neighborDist;
        public float neighborElev;

        public float timeHorizon;
        public float timeHorizonObst;

        public ORCALayer layerOccupation;
        public ORCALayer layerIgnore;
        public bool navigationEnabled;
        public bool collisionEnabled;

        public float3 worldPosition;
        public float3 worldVelocity;

        public static void Init(ref AgentData data)
        {
            data.index = -1;
            data.kdIndex = -1;

            data.position = float2.zero;
            data.baseline = 0f;
            data.prefVelocity = float2.zero;
            data.velocity = float2.zero;

            data.height = 0.5f;
            data.radius = 0.5f;
            data.radiusObst = 0.5f;
            data.maxSpeed = 20f;

            data.maxNeighbors = 15;
            data.neighborDist = 20.0f;
            data.neighborElev = 0.5f;

            data.timeHorizon = 15.0f;
            data.timeHorizonObst = 1.2f;

            data.layerOccupation = ORCALayer.ANY;
            data.layerIgnore = ORCALayer.NONE;
            data.navigationEnabled = true;
            data.collisionEnabled = true;

            data.worldPosition = float3.zero;
            data.worldVelocity = float3.zero;
        }
    }

    /// <summary>
    /// Agent result data after a simulation step.
    /// </summary>
    [BurstCompile]
    public struct AgentDataResult
    {
        public float2 position;
        public float2 velocity;
    }
}

using System;
using Unity.Mathematics;

namespace Runtime.Data.ValueObjects.PlayerData
{
    [Serializable]
    public struct PlayerForceData
    {
        public float3 ForceParameters;
    }
}
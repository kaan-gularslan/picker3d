using System;

namespace Runtime.Data.ValueObjects.PlayerData
{
    [Serializable]
    public struct PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaySpeed;
    }
}
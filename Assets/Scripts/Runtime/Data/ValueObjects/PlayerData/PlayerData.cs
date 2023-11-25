using System;

namespace Runtime.Data.ValueObjects.PlayerData
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerMeshData MeshData;
        public PlayerForceData ForceData;
    }
    
}
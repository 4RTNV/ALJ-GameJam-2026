using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public interface IItemPickup
    {
        void TryPickUpItem(Vector3 playerPosition);
    }
}
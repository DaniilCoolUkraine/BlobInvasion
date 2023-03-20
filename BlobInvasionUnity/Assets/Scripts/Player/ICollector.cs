using UnityEngine;

namespace BlobInvasion.Player
{
    public interface ICollector
    {
        public void Collect(GameObject collectableGameObject);
    }
}
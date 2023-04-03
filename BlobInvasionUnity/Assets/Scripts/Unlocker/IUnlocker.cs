using UnityEngine;

namespace BlobInvasion.Unlocker
{
    public interface IUnlocker
    {
        public void DoUnlock(GameObject unlockable);
    }
}
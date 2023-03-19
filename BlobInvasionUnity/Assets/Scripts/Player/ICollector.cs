using BlobInvasion.Collectable;

namespace BlobInvasion.Player
{
    public interface ICollector
    {
        public void Collect(ICollectable collectable);
    }
}
namespace BlobInvasion.Collectable.Props.Bonuses
{
    public interface IPowerable
    {
        public bool IsActive { get; set; }
        public void Apply(params object[] param);
        public void Discard(params object[] param);
    }
}
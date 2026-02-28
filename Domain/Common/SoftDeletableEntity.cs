namespace Domain.Common
{
    public abstract class SoftDeletableEntity : AuditableEntity
    {
        public bool IsDeleted { get; set; }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
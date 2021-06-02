namespace SiteConstructor.Framework.Models
{
    public interface IEntityWithId<Tid>: IEntityBase
    {
        Tid Id { get; set; }
    }
}

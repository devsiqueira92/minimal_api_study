namespace MinimalAPI.Domain.Entities
{
    public class UserInfoEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string UserEntityId { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}

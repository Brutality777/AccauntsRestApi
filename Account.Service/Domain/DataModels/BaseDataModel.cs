namespace Account.Service.Domain.DataModels
{
    internal abstract class BaseDataModel<T> where T : struct
    {
        public T Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

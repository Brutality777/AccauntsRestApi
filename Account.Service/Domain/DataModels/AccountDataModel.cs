namespace Account.Service.Domain.DataModels
{
    internal class AccountDataModel : BaseDataModel<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
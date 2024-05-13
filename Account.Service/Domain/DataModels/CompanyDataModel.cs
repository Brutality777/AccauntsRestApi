namespace Account.Service.Domain.DataModels
{
    internal class CompanyDataModel : BaseDataModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<AccountDataModel> Workers { get; set; } = new List<AccountDataModel>();
    }
}

namespace Account.Service.Domain.DataModels
{
    internal class CompanyAccountRelationDataModel
    {
        public int CompanyDataModelId { get; set; }
        public CompanyDataModel? Company { get; set; }

        public int AccountDataModelId { get; set; }
        public AccountDataModel? Account { get; set; }

        public DateTime JoinDate { get; set; }
    }
}

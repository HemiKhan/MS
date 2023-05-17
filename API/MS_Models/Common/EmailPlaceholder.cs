namespace MS_Models.Common
{
    public class EmailPlaceholder
    {
        public Guid Id { get; set; }
        public Guid? EmailTemplateId { get; set; }
        public string EmailPlaceholderType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
namespace EventBus.Messages
{
    public class FileInformationMessage
    {
        public string Random { get; set; }
        public decimal? RandomFloat { get; set; }
        public bool Bool { get; set; }
        public string Date { get; set; }
        public string RegEx { get; set; }
        public string Enum { get; set; }
        public List<string> Elt { get; set; }
        public string Person { get; set; }

        public string? LastUpdated { get; set; }
        public string? LastModified { get; set; }
    }
}

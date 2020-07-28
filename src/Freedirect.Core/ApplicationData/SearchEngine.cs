namespace Freedirect.Core.ApplicationData
{
    public class SearchEngine
    {
        public string Name { get; set; }
        public string Address { get; set; }

        // ReSharper disable once UnusedMember.Global
        public SearchEngine()
        {
        }

        public SearchEngine(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
namespace Freedirect.Core
{
    public class SearchEngine
    {
        // ReSharper disable once UnusedMember.Global
        public SearchEngine()
        {
        }

        public SearchEngine(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
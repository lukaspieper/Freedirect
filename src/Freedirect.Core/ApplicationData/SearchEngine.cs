namespace Freedirect.Core.ApplicationData
{
    public class SearchEngine
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public SearchEngine(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
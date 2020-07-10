namespace Logic.ApplicationData
{
    public class SearchEngineEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public SearchEngineEntity(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
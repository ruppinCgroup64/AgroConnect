namespace AgroConnect_server.BL
{
    public class Categories
    {
        int id;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Categories(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Categories() { }

        public List<Categories> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadCategories();
        }
    }
}

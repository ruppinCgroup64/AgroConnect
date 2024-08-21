namespace AgroConnect_server.BL
{
    public class Products
    {
        int id;
        string pic;
        string name;
        int categoryNum;

        public int Id { get => id; set => id = value; }
        public string Pic { get => pic; set => pic = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryNum { get => categoryNum; set => categoryNum = value; }

        public Products(int id, string pic, string name, int categoryNum)
        {
            this.Id = id;
            this.Pic = pic;
            this.Name = name;
            this.CategoryNum = categoryNum;
        }

        public Products() { }
        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertProduct(this);
        }

        public List<Products> ReadByFarm(int farmId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadByFarm(farmId);
        }

        public List<Products> ReadByConsumer(int consumerId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadByConsumer(consumerId);
        }

        public List<Products> ReadByConsumerAndOrder(int orderId, int consumerId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadProductsByConsumerAndOrder(orderId, consumerId);
        }
    }
}

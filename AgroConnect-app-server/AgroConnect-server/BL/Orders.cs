namespace AgroConnect_server.BL
{
    public class Orders
    {
        int id;
        string dateHour; //dateTime in DB
        string status;
        float totalPrice;
        int consumerNum;

        public int Id { get => id; set => id = value; }
        public string DateHour { get => dateHour; set => dateHour = value; }
        public string Status { get => status; set => status = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int ConsumerNum { get => consumerNum; set => consumerNum = value; }

        public Orders(int id, string dateHour, string status, float totalPrice, int consumerNum)
        {
            this.Id = id;
            this.DateHour = dateHour;
            this.Status = status;
            this.TotalPrice = totalPrice;
            this.ConsumerNum = consumerNum;
        }

        public Orders() { }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertOrders(this);
        }

        public List<Orders> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadOrders();
        }
        public List<Orders> ReadByConsumerId(int ConsumerId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadOrdersByConsumerId(ConsumerId);
        }

        public Orders ReadDetailsByOrderInPointId(int OrderInPointId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadDetailsByOrderInPointId(OrderInPointId);
        }

        public Orders Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateOrder(this);
        }


    }
}

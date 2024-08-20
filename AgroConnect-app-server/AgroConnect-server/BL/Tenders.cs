namespace AgroConnect_server.BL
{
    public class Tenders
    {
        int id;
        string offeredPacks;
        int packsAmount;
        float initialOffer;
        string closeDateHour; //dateTime in DB
        string collectAddress;
        string collectDateHour; //dateTime in DB4
        int farmNum;
        int productNum;
        string collectDateHourClose; //dateTime in DB
        bool active;
        string longitude;
        string latitude;

        public int Id { get => id; set => id = value; }
        public string OfferedPacks { get => offeredPacks; set => offeredPacks = value; }
        public int PacksAmount { get => packsAmount; set => packsAmount = value; }
        public float InitialOffer { get => initialOffer; set => initialOffer = value; }
        public string CloseDateHour { get => closeDateHour; set => closeDateHour = value; }
        public string CollectAddress { get => collectAddress; set => collectAddress = value; }
        public string CollectDateHour { get => collectDateHour; set => collectDateHour = value; }
        public int FarmNum { get => farmNum; set => farmNum = value; }
        public int ProductNum { get => productNum; set => productNum = value; }
        public string CollectDateHourClose { get => collectDateHourClose; set => collectDateHourClose = value; }
        public bool Active { get => active; set => active = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }

        public Tenders(int id, string offeredPacks, int packsAmount, float initialOffer, string closeDateHour, string collectAddress, string collectDateHour, int farmNum, int productNum, string collectDateHourClose, bool active, string longitude, string latitude)
        {
            this.Id = id;
            this.OfferedPacks = offeredPacks;
            this.PacksAmount = packsAmount;
            this.InitialOffer = initialOffer;
            this.CloseDateHour = closeDateHour;
            this.CollectAddress = collectAddress;
            this.CollectDateHour = collectDateHour;
            this.FarmNum = farmNum;
            this.ProductNum = productNum;
            this.CollectDateHourClose = collectDateHourClose;
            this.Active = active;
            this.Longitude = longitude;
            this.Latitude = latitude;    
        }

        public Tenders() { }

        public Tenders Insert()
        {
            DBservices2 dbs = new DBservices2();
            Tenders tender = dbs.InsertTender(this);
            return tender;
        }


        //public int GetTenderById()
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.GetTenderById(this);
        //}

        public List<Object> Read()
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTenders();
        }

        public List<Object> ReadTendersByConsumerBids(int consumerId)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTendersByConsumerBids(consumerId);
        }
        public List<Object> ReadTendersByFarm(int farmID)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTendersByFarm(farmID);
        }
        public List<Object> ReadTendersConsumerWin(int consumerId)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTendersConsumerWin(consumerId);
        }
        public List<Object> ReadTendersConsumerWinShowInOrders(int consumerId)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTendersConsumerWinShowInOrders(consumerId);
        }

        static public List<Object> ReadTenderBidsDetails(int tenderID)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadTenderBidsDetails(tenderID);
        }
        public float ReadAvgProductPrice(int productID)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadAvgProductPrice(productID);
        }
        public Tenders Update()
        {
            DBservices2 dbs = new DBservices2();
            return dbs.UpdateTender(this);
        }

        public int UpdateActivity(int tenderID,bool active)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.UpdateTenderActivity(tenderID, active);
        }
    }
}

namespace AgroConnect_server.BL
{
    public class SalePoints
    {
        int id;
        string address;
        string dateHour; //dateTime in DB
        string contactName;
        string contactPhoneNum;
        int rankPrice;
        int rankQuality;
        int farmNum;
        string longitude;
        string latitude;

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public string DateHour { get => dateHour; set => dateHour = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactPhoneNum { get => contactPhoneNum; set => contactPhoneNum = value; }
        public int RankPrice { get => rankPrice; set => rankPrice = value; }
        public int RankQuality { get => rankQuality; set => rankQuality = value; }
        public int FarmNum { get => farmNum; set => farmNum = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }

        public SalePoints(int id, string address, string dateHour, string contactName, string contactPhoneNum, int rankPrice, int rankQuality, int farmNum, string longitude, string latitude)
        {
            this.Id = id;
            this.Address = address;
            this.DateHour = dateHour;
            this.ContactName = contactName;
            this.ContactPhoneNum = contactPhoneNum;
            this.RankPrice = rankPrice;
            this.RankQuality = rankQuality;
            this.FarmNum = farmNum;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public SalePoints() { }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertSalePoint(this);
        }

        public List<SalePoints> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadSalePoints();
        }

        public SalePoints ReadById(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadSalePointById(id);
        }

        public SalePoints Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateSalePoint(this);
        }
    }
}

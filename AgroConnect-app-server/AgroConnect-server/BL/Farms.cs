namespace AgroConnect_server.BL
{
    public class Farms
    {
        int id;
        string name;
        string address;
        int rank;
        string socialNetworkLink;
        int farmerId;
        string mainPic;
        string longitude;
        string latitude;

        public Farms(int id, string name, string address, int rank, string socialNetworkLink, int farmerId, string mainPic, string longitude, string latitude)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Rank = rank;
            this.SocialNetworkLink = socialNetworkLink;
            this.FarmerId = farmerId;
            this.MainPic = mainPic;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public Farms() { }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int Rank { get => rank; set => rank = value; }
        public string SocialNetworkLink { get => socialNetworkLink; set => socialNetworkLink = value; }
        public int FarmerId { get => farmerId; set => farmerId = value; }
        public string MainPic { get => mainPic; set => mainPic = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }

        public Farms Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertFarm(this);
        }

        public List<Farms> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFarms();
        }

        public List<Farms> ReadById(int farmerId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFarmsById(farmerId);
        }

        public Farms ReadByConsumerAndOrder(int orderId, int consumerId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFarmByConsumerAndOrder(orderId, consumerId);
        }

        public Farms ReadSalePointId(int salePointId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFarmsBydSalePointId(salePointId);
        }

        public Farms Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateFarm(this);
        }

        public int Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteFarm(id);
        }

    }




}

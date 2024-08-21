namespace AgroConnect_server.BL
{
    public class Fairs
    {
        int id;
        string name;
        string address;
        string dateHour; //dateTime in DB
        int maxFarmers;
        string contactName;
        string contactPhoneNum;
        string moreDetails;
        int fairOrganizerNum;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string DateHour { get => dateHour; set => dateHour = value; }
        public int MaxFarmers { get => maxFarmers; set => maxFarmers = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactPhoneNum { get => contactPhoneNum; set => contactPhoneNum = value; }
        public string MoreDetails { get => moreDetails; set => moreDetails = value; }
        public int FairOrganizerNum { get => fairOrganizerNum; set => fairOrganizerNum = value; }

        public Fairs(int id, string name, string address, string dateHour, int maxFarmers, string contactName, string contactPhoneNum, string moreDetails, int fairOrganizerNum)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.DateHour = dateHour;
            this.MaxFarmers = maxFarmers;
            this.ContactName = contactName;
            this.ContactPhoneNum = contactPhoneNum;
            this.MoreDetails = moreDetails;
            this.FairOrganizerNum = fairOrganizerNum;
        }

        public Fairs() { }
    }
}

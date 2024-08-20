using AgroConnect_server.BL;

public class Farmers : Consumers
{
    int rankPrice;
    int rankQuality;
    int farmNum;

    public int RankPrice { get => rankPrice; set => rankPrice = value; }
    public int RankQuality { get => rankQuality; set => rankQuality = value; }
    public int FarmNum { get => farmNum; set => farmNum = value; }

    public Farmers(string email, string firstName, string lastName, string password, string gender, string dateOfBirth, string phoneNum, string address, string registrationDate, bool isAdmin, string profilePic, bool isFarmer, string longitude, string latitude, int rankPrice, int rankQuality, int farmNum)
        : base(email, firstName, lastName, password, gender, dateOfBirth, phoneNum, address, registrationDate, isAdmin, profilePic, isFarmer, longitude, latitude)
    {
        this.RankPrice = rankPrice;
        this.RankQuality = rankQuality;
        this.FarmNum = farmNum;
    }

    public Farmers() { }

}
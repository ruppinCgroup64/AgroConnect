using AgroConnect_server.BL;

public class FairOrganizers : Consumers
{
    

    public FairOrganizers(string email, string firstName, string lastName, string password, string gender, string dateOfBirth, string phoneNum, string address, string registrationDate, bool isAdmin, string profilePic, bool isFarmer, string longitude, string latitude)
        : base(email, firstName, lastName, password, gender, dateOfBirth, phoneNum, address, registrationDate, isAdmin, profilePic, isFarmer, longitude, latitude)
    {
        
    }

    public FairOrganizers() { }
}
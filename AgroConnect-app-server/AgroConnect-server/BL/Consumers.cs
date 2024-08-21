using System.Collections.Generic;

namespace AgroConnect_server.BL
{
    public class Consumers
    {
        int id;
        string email;
        string firstName;
        string lastName;
        string password;
        string gender;
        string dateOfBirth; // Date in DB
        string phoneNum;
        string address;
        string registrationDate; //DateTime in DB
        bool isAdmin;
        string profilePic;
        bool isFarmer;
        string longitude;
        string latitude;
        //static List<Consumer> ConsumersList = new List<Consumer>();

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string Gender { get => gender; set => gender = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Address { get => address; set => address = value; }
        public string RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string ProfilePic { get => profilePic; set => profilePic = value; }
        public bool IsFarmer { get => isFarmer; set => isFarmer = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }

        public Consumers(string email, string firstName, string lastName, string password, string gender, string dateOfBirth, string phoneNum, string address, string registrationDate, bool isAdmin, string profilePic, bool isFarmer, string longitude, string latitude)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNum = phoneNum;
            this.Address = address;
            this.RegistrationDate = registrationDate;
            this.IsAdmin = isAdmin;
            this.ProfilePic = profilePic;
            this.IsFarmer = isFarmer;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public Consumers() { }

        public Consumers Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertConsumer(this);
        }

        //public int GetConsumerById()
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.GetConsumerById(this);
        //}

        public Consumers LoginConsumer()
        {
            DBservices dbs = new DBservices();
            return dbs.LoginConsumer(this);
        }

        public List<Consumers> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadConsumers();
        }

        public Consumers Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateConsumer(this);
        }

        public int UpdateIsActive()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateConsumerIsActive(this);
        }

        public int Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteConsumer(id);
        }
    }
}

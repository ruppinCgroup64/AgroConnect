using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using AgroConnect_server.BL;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{

    public DBservices() { }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


    //--------------------------------------------------------------------------------------------------
    // methods that Inserts to tables
    //--------------------------------------------------------------------------------------------------
    // Consumers
    public Consumers InsertConsumer(Consumers consumer)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateConsumerInsertCommandWithStoredProcedure("sp_InsertConsumer_2024", con, consumer);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Consumers c = new Consumers();
            if (dataReader.RecordsAffected == -1) return c;
            while (dataReader.Read())
            {
                c.Id = Convert.ToInt32(dataReader["Id"]);
                c.Email = dataReader["email"].ToString(); //maybe remove?
                c.FirstName = dataReader["firstName"].ToString();
                c.LastName = dataReader["lastName"].ToString();
                c.Password = dataReader["password"].ToString();
                c.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                c.Gender = dataReader["gender"].ToString();
                c.DateOfBirth = dataReader["dateOfBirth"].ToString();
                c.PhoneNum = dataReader["phoneNum"].ToString();
                c.Address = dataReader["address"].ToString();
                c.RegistrationDate = dataReader["registrationDate"].ToString(); // maybe remove?
                c.ProfilePic = dataReader["profilePic"].ToString();
                c.IsFarmer = Convert.ToBoolean(dataReader["isFarmer"]);
                c.Longitude = dataReader["longitude"].ToString();
                c.Latitude = dataReader["latitude"].ToString();
            }
            return c;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // Farms
    public Farms InsertFarm(Farms farm)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFarmInsertCommandWithStoredProcedure("sp_InsertFarm_2024", con, farm);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Farms f = new Farms();
            if (dataReader.RecordsAffected == -1) return f;
            while (dataReader.Read())
            {
                f = new Farms();
                f.Id = Convert.ToInt32(dataReader["id"]);
                f.Name = dataReader["name"].ToString();
                f.Address = dataReader["address"].ToString();
                f.Rank = Convert.ToInt32(dataReader["rank"]);
                f.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                f.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                f.MainPic = dataReader["mainPic"].ToString();
                f.Longitude = dataReader["longitude"].ToString();
                f.Latitude = dataReader["latitude"].ToString();
            }
            return f;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // Products
    public int InsertProduct(Products product)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateProductInsertCommandWithStoredProcedure("sp_insert_product_2024", con, product);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // FarmProductsInPoint
    public int InsertFarmProductInPoint(FarmProductsInPoint productInPoint)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFarmProductsInPointInsertCommandWithStoredProcedure("sp_insertProductInPoint_2024", con, productInPoint);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // SalePoints
    public int InsertSalePoint(SalePoints salePoint)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateSalePointInsertCommandWithStoredProcedure("sp_InsertSalePoint_2024", con, salePoint);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // Oreders
    public int InsertOrders(Orders order)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateOrderInsertCommandWithStoredProcedure("sp_InsertOrder_2024", con, order);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // OredersInPoint
    public int InsertProductInPointOrder(OrdersInPoint productInPointOrder)
    {

        SqlConnection con;
        SqlCommand cmd;
        int orderNum = -1;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateOrderInPointInsertCommandWithStoredProcedure("sp_InsertOrderInPoint_2024", con, productInPointOrder);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dataReader.RecordsAffected == -1) return -1;
            while (dataReader.Read())
            {
                orderNum = Convert.ToInt32(dataReader["OrderNum"]);
            }
            return orderNum;

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Tenders
    public Tenders InsertTender(Tenders tender)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateTenderInsertCommandWithStoredProcedure("sp_InsertTender_2024", con, tender);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Tenders t = new Tenders();
            while (dataReader.Read())
            {
                t.Id = Convert.ToInt32(dataReader["id"]);
                t.OfferedPacks = dataReader["offeredPacks"].ToString();
                t.PacksAmount = Convert.ToInt32(dataReader["packsAmount"]);
                t.InitialOffer = Convert.ToSingle(dataReader["initialOffer"]);
                t.CloseDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(); // Convert to DateTime
                t.CollectAddress = dataReader["collectAddress"].ToString();
                t.CollectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(); // Convert to DateTime
                t.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                t.ProductNum = Convert.ToInt32(dataReader["productNum"]);

            }
            return t;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // methods that reads from the database 
    //--------------------------------------------------------------------------------------------------
    // Consumers
    public List<Consumers> ReadConsumers()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Consumers> consumersList = new List<Consumers>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetConsumers_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Consumers c = new Consumers();
                c.Id = Convert.ToInt32(dataReader["Id"]);
                c.Email = dataReader["email"].ToString();
                c.FirstName = dataReader["firstName"].ToString();
                c.LastName = dataReader["lastName"].ToString();
                c.Password = dataReader["password"].ToString();
                c.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                c.Gender = dataReader["gender"].ToString();
                c.DateOfBirth = dataReader["dateOfBirth"].ToString(); 
                c.PhoneNum = dataReader["phoneNum"].ToString();
                c.Address = dataReader["address"].ToString();
                c.RegistrationDate = dataReader["registrationDate"].ToString(); 
                c.ProfilePic = dataReader["profilePic"].ToString();
                c.IsFarmer = Convert.ToBoolean(dataReader["isFarmer"]);
                c.Longitude = dataReader["longitude"].ToString();
                c.Latitude = dataReader["latitude"].ToString();
                consumersList.Add(c);
            }
            return consumersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Farms
    public List<Farms> ReadFarms()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Farms> farmsList = new List<Farms>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetFarms_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Farms f = new Farms();
                f.Id = Convert.ToInt32(dataReader["id"]);
                f.Name = dataReader["name"].ToString();
                f.Address = dataReader["address"].ToString();
                f.Rank = Convert.ToInt32(dataReader["rank"]);
                f.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                f.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                f.MainPic = dataReader["mainPic"].ToString();
                f.Longitude = dataReader["longitude"].ToString();
                f.Latitude = dataReader["latitude"].ToString();
                farmsList.Add(f);
            }
            return farmsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //FarmById
    public List<Farms> ReadFarmsById(int farmerId)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Farms> farmsList = new List<Farms>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetFarmsByFarmerID_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@farmerId", farmerId); // add farmerId parameter

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Farms f = new Farms();
                f.Id = Convert.ToInt32(dataReader["id"]);
                f.Name = dataReader["name"].ToString();
                f.Address = dataReader["address"].ToString();
                f.Rank = Convert.ToInt32(dataReader["rank"]);
                f.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                f.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                f.MainPic = dataReader["mainPic"].ToString();
                f.Longitude = dataReader["longitude"].ToString();
                f.Latitude = dataReader["latitude"].ToString();
                farmsList.Add(f);
            }
            return farmsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Farm by consumerID and orderId
    public Farms ReadFarmByConsumerAndOrder(int orderId, int consumerId)
    {
        SqlConnection con;
        SqlCommand cmd;
        Farms farm = null;


        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_FarmByConsumerAndOrder_2024", con);
        cmd.Parameters.AddWithValue("@consumerNum", consumerId); 
        cmd.Parameters.AddWithValue("@orderId", orderId);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dataReader.Read())
            {
                farm = new Farms();
                farm.Id = Convert.ToInt32(dataReader["id"]);
                farm.Name = dataReader["name"].ToString();
                farm.Address = dataReader["address"].ToString();
                farm.Rank = Convert.ToInt32(dataReader["rank"]);
                farm.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                farm.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                farm.MainPic = dataReader["mainPic"].ToString();
                farm.Longitude = dataReader["longitude"].ToString();
                farm.Latitude = dataReader["latitude"].ToString();
            }

            return farm;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Farm By salePoint Id
    public Farms ReadFarmsBydSalePointId(int salePointId)
    {

        SqlConnection con;
        SqlCommand cmd;
        Farms farm = null;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetFarmBysalePointID_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@salePointId", salePointId); // add farmerId parameter

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dataReader.Read())
            {
                farm = new Farms();
                farm.Id = Convert.ToInt32(dataReader["id"]);
                farm.Name = dataReader["name"].ToString();
                farm.Address = dataReader["address"].ToString();
                farm.Rank = Convert.ToInt32(dataReader["rank"]);
                farm.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                farm.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                farm.MainPic = dataReader["mainPic"].ToString();
                farm.Longitude = dataReader["longitude"].ToString();
                farm.Latitude = dataReader["latitude"].ToString();
            }

            return farm;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Categories
    public List<Categories> ReadCategories()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Categories> categoriesList = new List<Categories>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetCategories_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Categories c = new Categories();
                c.Id = Convert.ToInt32(dataReader["id"]);
                c.Name = dataReader["name"].ToString();
                categoriesList.Add(c);
            }
            return categoriesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Products by farmID
    public List<Products> ReadByFarm(int farmNum)
    {
        SqlConnection con;
        SqlCommand cmd;
        List<Products> productsByFarm = new List<Products>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_ProductNamesByFarm_2024", con); //returns a list of products (not just the names)
        cmd.Parameters.AddWithValue("@farmNum", farmNum); // add farmNum parameter

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Products p = new Products();
                p.Id = Convert.ToInt32(dataReader["id"]);
                p.Pic = dataReader["pic"].ToString();
                p.Name = dataReader["name"].ToString();
                p.CategoryNum = Convert.ToInt32(dataReader["categoryNum"]);

                productsByFarm.Add(p);
            }
            return productsByFarm;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Products by consumerID
    public List<Products> ReadByConsumer(int consumerId)
    {
        SqlConnection con;
        SqlCommand cmd;
        List<Products> productsByFarm = new List<Products>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_ProductsByConsumer_2024", con); 
        cmd.Parameters.AddWithValue("@consumerNum", consumerId); 

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Products p = new Products();
                p.Id = Convert.ToInt32(dataReader["id"]);
                p.Pic = dataReader["pic"].ToString();
                p.Name = dataReader["name"].ToString();
                p.CategoryNum = Convert.ToInt32(dataReader["categoryNum"]);

                productsByFarm.Add(p);
            }
            return productsByFarm;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Products by consumerID and orderId
    public List<Products> ReadProductsByConsumerAndOrder(int orderId, int consumerId)
    {
        SqlConnection con;
        SqlCommand cmd;
        List<Products> productsByConsumerAndOrder = new List<Products>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_ProductsByConsumerAndOrder_2024", con);
        cmd.Parameters.AddWithValue("@consumerNum", consumerId);
        cmd.Parameters.AddWithValue("@orderId", orderId);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Products p = new Products();
                p.Id = Convert.ToInt32(dataReader["id"]);
                p.Pic = dataReader["pic"].ToString();
                p.Name = dataReader["name"].ToString();
                p.CategoryNum = Convert.ToInt32(dataReader["categoryNum"]);

                productsByConsumerAndOrder.Add(p);
            }
            return productsByConsumerAndOrder;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //FarmProductsInPoint by salePoint id
    public List<FarmProductsInPoint> ReadProductsInPointById(int id)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<FarmProductsInPoint> productsInPointList = new List<FarmProductsInPoint>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetProductsInPoint_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@id", id); // add farmNum parameter

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                FarmProductsInPoint pip = new FarmProductsInPoint();
                pip.SalePointNum = Convert.ToInt32(dataReader["salePointNum"]);
                pip.ProductInFarmNum = Convert.ToInt32(dataReader["productInFarmNum"]);
                pip.ProductAmount = Convert.ToInt32(dataReader["productAmount"]);
                pip.UnitPrice = Convert.ToSingle(dataReader["unitPrice"]);
                productsInPointList.Add(pip);
            }
            return productsInPointList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //SalePoints
    public List<SalePoints> ReadSalePoints()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<SalePoints> slaePointsList = new List<SalePoints>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetSalePoints_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                SalePoints s = new SalePoints();
                s.Id = Convert.ToInt32(dataReader["id"]);
                s.Address = dataReader["address"].ToString();
                s.DateHour = dataReader["dateHour"].ToString();
                s.ContactName = dataReader["contactName"].ToString();
                s.ContactPhoneNum = dataReader["contactPhoneNum"].ToString();
                s.RankPrice = Convert.ToInt32(dataReader["rankPrice"]);
                s.RankQuality = Convert.ToInt32(dataReader["rankQuality"]);
                s.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                s.Longitude = dataReader["longitude"].ToString();
                s.Latitude = dataReader["latitude"].ToString();
                slaePointsList.Add(s);
            }
            return slaePointsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //SalePoint by ID
    public SalePoints ReadSalePointById(int Id)
    {
        SqlConnection con;
        SqlCommand cmd;
        SalePoints s = null;


        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetSalePointById_2024", con);
        cmd.Parameters.AddWithValue("@Id", Id);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dataReader.Read())
            {
                s = new SalePoints();
                s.Id = Convert.ToInt32(dataReader["id"]);
                s.Address = dataReader["address"].ToString();
                s.DateHour = dataReader["dateHour"].ToString();
                s.ContactName = dataReader["contactName"].ToString();
                s.ContactPhoneNum = dataReader["contactPhoneNum"].ToString();
                s.RankPrice = Convert.ToInt32(dataReader["rankPrice"]);
                s.RankQuality = Convert.ToInt32(dataReader["rankQuality"]);
                s.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                s.Longitude = dataReader["longitude"].ToString();
                s.Latitude = dataReader["latitude"].ToString();
            }

            return s;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Orders
    public List<Orders> ReadOrders()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Orders> ordersList = new List<Orders>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOrders_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Orders o = new Orders();
                o.Id = Convert.ToInt32(dataReader["id"]);
                o.DateHour = dataReader["dateHour"].ToString();
                o.Status = dataReader["status"].ToString();
                o.TotalPrice = Convert.ToSingle(dataReader["totalPrice"]);
                o.ConsumerNum = Convert.ToInt32(dataReader["consumerNum"]);
                ordersList.Add(o);
            }
            return ordersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Orders> ReadOrdersByConsumerId(int ConsumerId)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Orders> ordersList = new List<Orders>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOrdersByConsumerId_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@consumerNum", ConsumerId); // add salePointNum parameter


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Orders o = new Orders();
                o.Id = Convert.ToInt32(dataReader["id"]);
                o.DateHour = dataReader["dateHour"].ToString();
                o.Status = dataReader["status"].ToString();
                o.TotalPrice = Convert.ToSingle(dataReader["totalPrice"]);
                o.ConsumerNum = Convert.ToInt32(dataReader["consumerNum"]);
                ordersList.Add(o);
            }
            return ordersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Oreder details by orderInPoint ID
    public Orders ReadDetailsByOrderInPointId(int OrderInPointId)
    {

        SqlConnection con;
        SqlCommand cmd;
        Orders o = null;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOrderByOrderInPointId_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@OrderInPointId", OrderInPointId); // add salePointNum parameter


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dataReader.Read())
            {
                o = new Orders();
                o.Id = Convert.ToInt32(dataReader["id"]);
                o.DateHour = dataReader["dateHour"].ToString();
                o.Status = dataReader["status"].ToString();
                o.TotalPrice = Convert.ToSingle(dataReader["totalPrice"]);
                o.ConsumerNum = Convert.ToInt32(dataReader["consumerNum"]);
            }
            return o;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //OrdersInPoint
    public List<OrdersInPoint> ReadOrdersBySalePointId(int salePointId)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<OrdersInPoint> ordersListBySalePoint = new List<OrdersInPoint>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOrdersBySalePointId_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@salePointNum", salePointId); // add salePointNum parameter


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                OrdersInPoint oip = new OrdersInPoint();
                oip.Id = Convert.ToInt32(dataReader["id"]);
                oip.SalePointNum = Convert.ToInt32(dataReader["salePointNum"]);
                oip.ProductInFarmNum = Convert.ToInt32(dataReader["productInFarmNum"]);
                oip.OrderNum = Convert.ToInt32(dataReader["orderNum"]);
                oip.Amount = Convert.ToInt32(dataReader["amount"]);
                oip.RankProduct = Convert.ToInt32(dataReader["rankProduct"]);
                ordersListBySalePoint.Add(oip);
            }
            return ordersListBySalePoint;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Get orderInPoint details by orderId
    public List<OrdersInPoint> ReadOrderInPointDetailsByOrdertId(int orderId)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<OrdersInPoint> orderInPointOrdersList = new List<OrdersInPoint>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOrderInPointDetailsByOrderId_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@orderNum", orderId); // add salePointNum parameter


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                OrdersInPoint oip = new OrdersInPoint();
                oip = new OrdersInPoint();
                oip.Id = Convert.ToInt32(dataReader["id"]);
                oip.SalePointNum = Convert.ToInt32(dataReader["salePointNum"]);
                oip.ProductInFarmNum = Convert.ToInt32(dataReader["productInFarmNum"]); //product Id from products table
                oip.OrderNum = Convert.ToInt32(dataReader["orderNum"]);
                oip.Amount = Convert.ToInt32(dataReader["amount"]);
                oip.RankProduct = Convert.ToInt32(dataReader["rankProduct"]);
                orderInPointOrdersList.Add(oip);
            }
            return orderInPointOrdersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //Tender
    public List<Tenders> ReadTenders()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Tenders> tendersList = new List<Tenders>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTenders_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Tenders t = new Tenders();
                t.Id = Convert.ToInt32(dataReader["id"]);
                t.OfferedPacks = dataReader["offeredPacks"].ToString();
                t.PacksAmount = Convert.ToInt32(dataReader["packsAmount"]);
                t.InitialOffer = Convert.ToSingle(dataReader["initialOffer"]);
                t.CloseDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(); // Convert to DateTime
                t.CollectAddress = dataReader["collectAddress"].ToString();
                t.CollectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(); // Convert to DateTime
                t.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                t.ProductNum = Convert.ToInt32(dataReader["productNum"]);

                tendersList.Add(t);
            }
            return tendersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // methods that updates details
    //--------------------------------------------------------------------------------------------------
    // Consumers
    public Consumers UpdateConsumer(Consumers consumer)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateConsumerUpdateCommandWithStoredProcedure("sp_UpdateConsumer_2024", con, consumer);             // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            Consumers c = new Consumers();
            while (dataReader.Read())
            {
                c.Id = Convert.ToInt32(dataReader["Id"]);
                c.Email = dataReader["email"].ToString(); //maybe remove?
                c.FirstName = dataReader["firstName"].ToString();
                c.LastName = dataReader["lastName"].ToString();
                c.Password = dataReader["password"].ToString();
                c.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                c.Gender = dataReader["gender"].ToString();
                c.DateOfBirth = dataReader["dateOfBirth"].ToString();
                c.PhoneNum = dataReader["phoneNum"].ToString();
                c.Address = dataReader["address"].ToString();
                c.RegistrationDate = dataReader["registrationDate"].ToString(); // maybe remove?
                c.ProfilePic = dataReader["profilePic"].ToString();
                c.IsFarmer = Convert.ToBoolean(dataReader["isFarmer"]);
                c.Longitude = dataReader["longitude"].ToString();
                c.Latitude = dataReader["latitude"].ToString();
            }
            return c;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    // Farms
    public Farms UpdateFarm(Farms farm)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFarmUpdateCommandWithStoredProcedure("sp_UpdateFarm_2024", con, farm); // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Farms f = new Farms();
            while (dataReader.Read())
            {
                f.Id = Convert.ToInt32(dataReader["id"]);
                f.Name = dataReader["name"].ToString();
                f.Address = dataReader["address"].ToString();
                f.Rank = Convert.ToInt32(dataReader["rank"]);
                f.SocialNetworkLink = dataReader["socialNetworkLink"].ToString();
                f.FarmerId = Convert.ToInt32(dataReader["farmerId"]);
                f.MainPic = dataReader["mainPic"].ToString();
                f.Longitude = dataReader["longitude"].ToString();
                f.Latitude = dataReader["latitude"].ToString();

            }
            return f;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //SalePoints
    public SalePoints UpdateSalePoint(SalePoints salePoint)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateSalePointsUpdateCommandWithStoredProcedure("sp_UpdateSalePoints_2024", con, salePoint); // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            SalePoints s = new SalePoints();

            while (dataReader.Read())
            {
                s.Id = Convert.ToInt32(dataReader["id"]);
                s.Address = dataReader["address"].ToString();
                s.DateHour = dataReader["dateHour"].ToString();
                s.ContactName = dataReader["contactName"].ToString();
                s.ContactPhoneNum = dataReader["contactPhoneNum"].ToString();
                s.RankPrice = Convert.ToInt32(dataReader["rankPrice"]);
                s.RankQuality = Convert.ToInt32(dataReader["rankQuality"]);
                s.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                s.Longitude = dataReader["longitude"].ToString();
                s.Latitude = dataReader["latitude"].ToString();

            }
            return s;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //FarmProductsInPoint
    public FarmProductsInPoint UpdateProductInPoint(FarmProductsInPoint productInPoint)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateProductInPointsUpdateCommandWithStoredProcedure("sp_UpdateproductInPoint_2024", con, productInPoint); // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            FarmProductsInPoint pip = new FarmProductsInPoint();

            while (dataReader.Read())
            {
                pip.Id = Convert.ToInt32(dataReader["id"]);
                pip.SalePointNum = Convert.ToInt32(dataReader["salePointNum"]);
                pip.ProductInFarmNum = Convert.ToInt32(dataReader["productInFarmNum"]);
                pip.ProductAmount = Convert.ToInt32(dataReader["productAmount"]);
                pip.UnitPrice = Convert.ToSingle(dataReader["unitPrice"]);

            }
            return pip;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Orders
    public Orders UpdateOrder(Orders order)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateOrderUpdateCommandWithStoredProcedure("sp_UpdateOrders_2024", con, order); // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Orders o = new Orders();
            while (dataReader.Read())
            {
                o.Id = Convert.ToInt32(dataReader["id"]);
                o.DateHour = dataReader["dateHour"].ToString();
                o.Status = dataReader["status"].ToString();
                o.TotalPrice = Convert.ToSingle(dataReader["totalPrice"]);
                o.ConsumerNum = Convert.ToInt32(dataReader["consumerNum"]);
            }
            return o;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //OrdersInPoint
    public OrdersInPoint UpdateOrdersInPoint(OrdersInPoint orderInPoint)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateOrderInPointUpdateCommandWithStoredProcedure("sp_UpdateOrderInPoint_2024", con, orderInPoint); // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            OrdersInPoint oip = new OrdersInPoint();
            while (dataReader.Read())
            {
                oip.Id = Convert.ToInt32(dataReader["id"]);
                oip.SalePointNum = Convert.ToInt32(dataReader["salePointNum"]);
                oip.ProductInFarmNum = Convert.ToInt32(dataReader["productInFarmNum"]);
                oip.OrderNum = Convert.ToInt32(dataReader["orderNum"]);
                oip.Amount = Convert.ToInt32(dataReader["amount"]);
                oip.RankProduct = Convert.ToInt32(dataReader["rankProduct"]);
            }
            return oip;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //Tenders
    public Tenders UpdateTender(Tenders tender)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateTenderUpdateCommandWithStoredProcedure("sp_UpdateTender_2024", con, tender);             // create the command
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            Tenders t = new Tenders();
            while (dataReader.Read())
            {
                t.Id = Convert.ToInt32(dataReader["id"]);
                t.OfferedPacks = dataReader["offeredPacks"].ToString();
                t.PacksAmount = Convert.ToInt32(dataReader["packsAmount"]);
                t.InitialOffer = Convert.ToSingle(dataReader["initialOffer"]);
                t.CloseDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(); // Convert to DateTime
                t.CollectAddress = dataReader["collectAddress"].ToString();
                t.CollectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(); // Convert to DateTime
                t.FarmNum = Convert.ToInt32(dataReader["farmNum"]);
                t.ProductNum = Convert.ToInt32(dataReader["productNum"]);

            }
            return t;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }


    public Consumers LoginConsumer(Consumers consumer)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateConsumerInsertCommandWithStoredProcedure("sp_LoginConsumer_2024", con, consumer);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            Consumers c = new Consumers();
            while (dataReader.Read())
            {
                c.Id = Convert.ToInt32(dataReader["Id"]);
                c.Email = dataReader["email"].ToString();
                c.FirstName = dataReader["firstName"].ToString();
                c.LastName = dataReader["lastName"].ToString();
                c.Password = dataReader["password"].ToString();
                c.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                c.Gender = dataReader["gender"].ToString();
                c.DateOfBirth = dataReader["dateOfBirth"].ToString();
                c.PhoneNum = dataReader["phoneNum"].ToString();
                c.Address = dataReader["address"].ToString();
                c.RegistrationDate = dataReader["registrationDate"].ToString();
                c.ProfilePic = dataReader["profilePic"].ToString();
                c.IsFarmer = Convert.ToBoolean(dataReader["isFarmer"]);
                c.Longitude = dataReader["longitude"].ToString();
                c.Latitude = dataReader["latitude"].ToString();
            }
            return c;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }
    public int UpdateConsumerIsActive(Consumers consumer)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateConsumerUpdateIsActiveCommandWithStoredProcedure("sp_UpdateConsumerActivity_2024", con, consumer);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // methods that "Delets" from tables
    //--------------------------------------------------------------------------------------------------
    // Consumers
    public int DeleteConsumer(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateConsumerDeleteCommandWithStoredProcedure("sp_DeleteConsumer_2024", con, id);             // create the command
        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    // Farms
    public int DeleteFarm(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFarmDeleteCommandWithStoredProcedure("sp_DeleteFarm_2024", con, id);             // create the command
        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }



    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------

    //Consumers
    private SqlCommand CreateConsumerInsertCommandWithStoredProcedure(String spName, SqlConnection con, Consumers consumer)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime dateOfBirth = DateTime.Parse(consumer.DateOfBirth); ;
        DateTime RegistrationDate = DateTime.Now;

        cmd.Parameters.AddWithValue("@email", consumer.Email);
        cmd.Parameters.AddWithValue("@firstName", consumer.FirstName);
        cmd.Parameters.AddWithValue("@lastName", consumer.LastName);
        cmd.Parameters.AddWithValue("@password", consumer.Password);
        cmd.Parameters.AddWithValue("@gender", consumer.Gender);
        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
        cmd.Parameters.AddWithValue("@phoneNum", consumer.PhoneNum);
        cmd.Parameters.AddWithValue("@address", consumer.Address);
        cmd.Parameters.AddWithValue("@registrationDate", RegistrationDate);
        cmd.Parameters.AddWithValue("@isAdmin", consumer.IsAdmin);
        cmd.Parameters.AddWithValue("@profilePic", consumer.ProfilePic);
        cmd.Parameters.AddWithValue("@isFarmer", consumer.IsFarmer);
        cmd.Parameters.AddWithValue("@longitude", consumer.Longitude);
        cmd.Parameters.AddWithValue("@latitude", consumer.Latitude);
        ;
        return cmd;
    }

    private SqlCommand CreateConsumerUpdateCommandWithStoredProcedure(String spName, SqlConnection con, Consumers consumer)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime dateOfBirth = DateTime.Parse(consumer.DateOfBirth);
        DateTime RegistrationDate = DateTime.Now;

        cmd.Parameters.AddWithValue("@email", consumer.Email); // maybe remove?
        cmd.Parameters.AddWithValue("@firstName", consumer.FirstName);
        cmd.Parameters.AddWithValue("@lastName", consumer.LastName);
        cmd.Parameters.AddWithValue("@password", consumer.Password);
        cmd.Parameters.AddWithValue("@gender", consumer.Gender);
        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
        cmd.Parameters.AddWithValue("@phoneNum", consumer.PhoneNum);
        cmd.Parameters.AddWithValue("@address", consumer.Address);
        //cmd.Parameters.AddWithValue("@registrationDate", RegistrationDate);
        cmd.Parameters.AddWithValue("@isAdmin", consumer.IsAdmin);
        cmd.Parameters.AddWithValue("@profilePic", consumer.ProfilePic);
        cmd.Parameters.AddWithValue("@isFarmer", consumer.IsFarmer);
        cmd.Parameters.AddWithValue("@longitude", consumer.Longitude);
        cmd.Parameters.AddWithValue("@latitude", consumer.Latitude);

        return cmd;
    }

    private SqlCommand CreateConsumerUpdateIsActiveCommandWithStoredProcedure(String spName, SqlConnection con, Consumers consumer)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime dateOfBirth = DateTime.Parse(consumer.DateOfBirth);
        DateTime RegistrationDate = DateTime.Now;

        cmd.Parameters.AddWithValue("@email", consumer.Email);
        cmd.Parameters.AddWithValue("@firstName", consumer.FirstName);
        cmd.Parameters.AddWithValue("@lastName", consumer.LastName);
        cmd.Parameters.AddWithValue("@password", consumer.Password);
        cmd.Parameters.AddWithValue("@gender", consumer.Gender);
        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
        cmd.Parameters.AddWithValue("@phoneNum", consumer.PhoneNum);
        cmd.Parameters.AddWithValue("@address", consumer.Address);
        cmd.Parameters.AddWithValue("@registrationDate", RegistrationDate);
        cmd.Parameters.AddWithValue("@isAdmin", consumer.IsAdmin);
        cmd.Parameters.AddWithValue("@profilePic", consumer.ProfilePic);
        cmd.Parameters.AddWithValue("@isFarmer", consumer.IsFarmer);
        cmd.Parameters.AddWithValue("@longitude", consumer.Longitude);
        cmd.Parameters.AddWithValue("@latitude", consumer.Latitude);
        return cmd;
    }

    private SqlCommand CreateConsumerDeleteCommandWithStoredProcedure(String spName, SqlConnection con, int id)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@Id", id); // add the ID parameter

        return cmd;
    }


    //No parameters

    private SqlCommand CreateCommandWithStoredProcedureWithoutParameters(String spName, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        return cmd;
    }

    //Farms 
    private SqlCommand CreateFarmInsertCommandWithStoredProcedure(String spName, SqlConnection con, Farms farm)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@name", farm.Name);
        cmd.Parameters.AddWithValue("@address", farm.Address);
        cmd.Parameters.AddWithValue("@rank", farm.Rank);
        cmd.Parameters.AddWithValue("@socialNetworkLink", farm.SocialNetworkLink);
        cmd.Parameters.AddWithValue("@farmerId", farm.FarmerId);
        cmd.Parameters.AddWithValue("@mainPic", farm.MainPic);
        cmd.Parameters.AddWithValue("@longitude", farm.Longitude);
        cmd.Parameters.AddWithValue("@latitude", farm.Latitude);

        return cmd;
    }

    private SqlCommand CreateFarmUpdateCommandWithStoredProcedure(String spName, SqlConnection con, Farms farm)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", farm.Id);
        cmd.Parameters.AddWithValue("@name", farm.Name);
        cmd.Parameters.AddWithValue("@address", farm.Address);
        cmd.Parameters.AddWithValue("@rank", farm.Rank);
        cmd.Parameters.AddWithValue("@socialNetworkLink", farm.SocialNetworkLink);
        cmd.Parameters.AddWithValue("@farmerId", farm.FarmerId);
        cmd.Parameters.AddWithValue("@mainPic", farm.MainPic);
        cmd.Parameters.AddWithValue("@longitude", farm.Longitude);
        cmd.Parameters.AddWithValue("@latitude", farm.Latitude);

        return cmd;
    }

    private SqlCommand CreateFarmDeleteCommandWithStoredProcedure(String spName, SqlConnection con, int id)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@Id", id); // add the ID parameter

        return cmd;
    }


    //Products
    private SqlCommand CreateProductInsertCommandWithStoredProcedure(String spName, SqlConnection con, Products product)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@pic", product.Pic);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@categoryNum", product.CategoryNum);

        return cmd;
    }

    //FarmProductsInPoint
    private SqlCommand CreateFarmProductsInPointInsertCommandWithStoredProcedure(String spName, SqlConnection con, FarmProductsInPoint productInPoint)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@salePointNum", productInPoint.SalePointNum);
        cmd.Parameters.AddWithValue("@productNum", productInPoint.ProductInFarmNum); // in the sp replace with the real productInFarmId
        cmd.Parameters.AddWithValue("@productAmount", productInPoint.ProductAmount);
        cmd.Parameters.AddWithValue("@unitPrice", productInPoint.UnitPrice);


        return cmd;
    }

    private SqlCommand CreateProductInPointsUpdateCommandWithStoredProcedure(String spName, SqlConnection con, FarmProductsInPoint productInPoint)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", productInPoint.Id);
        cmd.Parameters.AddWithValue("@salePointNum", productInPoint.SalePointNum);
        cmd.Parameters.AddWithValue("@productNum", productInPoint.ProductInFarmNum); 
        cmd.Parameters.AddWithValue("@productAmount", productInPoint.ProductAmount);
        cmd.Parameters.AddWithValue("@unitPrice", productInPoint.UnitPrice);


        return cmd;
    }


    //SalePoints
    private SqlCommand CreateSalePointInsertCommandWithStoredProcedure(String spName, SqlConnection con, SalePoints salePoint)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime dateOfSalePoint = DateTime.Parse(salePoint.DateHour); ;


        cmd.Parameters.AddWithValue("@address", salePoint.Address);
        cmd.Parameters.AddWithValue("@dateHour", dateOfSalePoint);
        cmd.Parameters.AddWithValue("@contactName", salePoint.ContactName);
        cmd.Parameters.AddWithValue("@contactPhoneNum", salePoint.ContactPhoneNum);
        cmd.Parameters.AddWithValue("@rankPrice", salePoint.RankPrice);
        cmd.Parameters.AddWithValue("@rankQuality", salePoint.RankQuality);
        cmd.Parameters.AddWithValue("@farmNum", salePoint.FarmNum);
        cmd.Parameters.AddWithValue("@longitude", salePoint.Longitude);
        cmd.Parameters.AddWithValue("@latitude", salePoint.Latitude);

        return cmd;
    }

    private SqlCommand CreateSalePointsUpdateCommandWithStoredProcedure(String spName, SqlConnection con, SalePoints salePoint)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", salePoint.Id);
        cmd.Parameters.AddWithValue("@address", salePoint.Address);
        cmd.Parameters.AddWithValue("@dateHour", salePoint.DateHour);
        cmd.Parameters.AddWithValue("@contactName", salePoint.ContactName);
        cmd.Parameters.AddWithValue("@contactPhoneNum", salePoint.ContactPhoneNum);
        cmd.Parameters.AddWithValue("@rankPrice", salePoint.RankPrice);
        cmd.Parameters.AddWithValue("@rankQuality", salePoint.RankQuality);
        cmd.Parameters.AddWithValue("@farmNum", salePoint.FarmNum);
        cmd.Parameters.AddWithValue("@longitude", salePoint.Longitude);
        cmd.Parameters.AddWithValue("@latitude", salePoint.Latitude);

        return cmd;
    }

    //Orders
    private SqlCommand CreateOrderInsertCommandWithStoredProcedure(String spName, SqlConnection con, Orders order)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime OrderDate = DateTime.Now;


        cmd.Parameters.AddWithValue("@dateHour", OrderDate);
        cmd.Parameters.AddWithValue("@status", order.Status);
        cmd.Parameters.AddWithValue("@totalPrice", order.TotalPrice);
        cmd.Parameters.AddWithValue("@consumerNum", order.ConsumerNum);

        return cmd;
    }

    private SqlCommand CreateOrderUpdateCommandWithStoredProcedure(String spName, SqlConnection con, Orders order)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", order.Id);
        cmd.Parameters.AddWithValue("@dateHour", order.DateHour);
        cmd.Parameters.AddWithValue("@status", order.Status);
        cmd.Parameters.AddWithValue("@totalPrice", order.TotalPrice);
        cmd.Parameters.AddWithValue("@consumerNum", order.ConsumerNum);

        return cmd;
    }

    //OrdersInPoint
    private SqlCommand CreateOrderInPointInsertCommandWithStoredProcedure(String spName, SqlConnection con, OrdersInPoint orderInPoint)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@salePointNum", orderInPoint.SalePointNum);
        cmd.Parameters.AddWithValue("@productNum", orderInPoint.ProductInFarmNum); // in the sp replace with the real productInFarmId
        cmd.Parameters.AddWithValue("@orderNum", orderInPoint.OrderNum);
        cmd.Parameters.AddWithValue("@amount", orderInPoint.Amount);
        cmd.Parameters.AddWithValue("@rankProduct", orderInPoint.RankProduct);

        return cmd;
    }

    private SqlCommand CreateOrderInPointUpdateCommandWithStoredProcedure(String spName, SqlConnection con, OrdersInPoint orderInPoint)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", orderInPoint.Id);
        cmd.Parameters.AddWithValue("@salePointNum", orderInPoint.SalePointNum);
        cmd.Parameters.AddWithValue("@productInFarmNum", orderInPoint.ProductInFarmNum);
        cmd.Parameters.AddWithValue("@orderNum", orderInPoint.OrderNum);
        cmd.Parameters.AddWithValue("@amount", orderInPoint.Amount);
        cmd.Parameters.AddWithValue("@rankProduct", orderInPoint.RankProduct);

        return cmd;
    }

    //Tenders
    private SqlCommand CreateTenderInsertCommandWithStoredProcedure(String spName, SqlConnection con, Tenders tender)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime collectDateHour = DateTime.Parse(tender.CollectDateHour); 

        cmd.Parameters.AddWithValue("@offeredPacks", tender.OfferedPacks);
        cmd.Parameters.AddWithValue("@packsAmount", tender.PacksAmount);
        cmd.Parameters.AddWithValue("@initialOffer", tender.InitialOffer);
        cmd.Parameters.AddWithValue("@closeDateHour", collectDateHour);
        cmd.Parameters.AddWithValue("@collectAddress", tender.CollectAddress);
        cmd.Parameters.AddWithValue("@collectDateHour", collectDateHour);
        cmd.Parameters.AddWithValue("@farmNum", tender.FarmNum);
        cmd.Parameters.AddWithValue("@productNum", tender.ProductNum);

        return cmd;
    }

    private SqlCommand CreateTenderUpdateCommandWithStoredProcedure(String spName, SqlConnection con, Tenders tender)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        DateTime collectDateHour = DateTime.Parse(tender.CollectDateHour);

        cmd.Parameters.AddWithValue("@id", tender.Id);
        cmd.Parameters.AddWithValue("@offeredPacks", tender.OfferedPacks);
        cmd.Parameters.AddWithValue("@packsAmount", tender.PacksAmount);
        cmd.Parameters.AddWithValue("@initialOffer", tender.InitialOffer);
        cmd.Parameters.AddWithValue("@closeDateHour", collectDateHour);
        cmd.Parameters.AddWithValue("@collectAddress", tender.CollectAddress);
        cmd.Parameters.AddWithValue("@collectDateHour", collectDateHour);
        cmd.Parameters.AddWithValue("@farmNum", tender.FarmNum);
        cmd.Parameters.AddWithValue("@productNum", tender.ProductNum);

        return cmd;
    }




}

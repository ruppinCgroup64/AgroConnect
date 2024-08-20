using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using AgroConnect_server.BL;
using System.Net.NetworkInformation;
public class DBservices2
{
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
                t.CollectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(); // Convert to DateTime
                t.Active = Convert.ToBoolean(dataReader["active"]);
                t.Longitude = dataReader["longitude"].ToString();
                t.Latitude = dataReader["latitude"].ToString();
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

    //Bids
    public int InsertBid(Bids bid)
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

        cmd = CreateBidInsertCommandWithStoredProcedure("sp_InsertBid_2024", con, bid);             // create the command

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
    // methods that reads from the database 
    //--------------------------------------------------------------------------------------------------

    //Tender
    public List<Object> ReadTenders()
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTenders_2024", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> tendersWithDetails = new List<Object>();

            while (dataReader.Read())
            {
                tendersWithDetails.Add(new
                {
                    id = Convert.ToInt32(dataReader["id"]),
                    offeredPacks = dataReader["offeredPacks"].ToString(),
                    packsAmount = Convert.ToInt32(dataReader["packsAmount"]),
                    initialOffer = Convert.ToSingle(dataReader["initialOffer"]),
                    closeDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(),
                    collectAddress = dataReader["collectAddress"].ToString(),
                    collectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(),
                    farmNum = Convert.ToInt32(dataReader["farmNum"]),
                    productNum = Convert.ToInt32(dataReader["productNum"]),
                    collectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(),
                    active = Convert.ToBoolean(dataReader["active"]),
                    longitude = dataReader["longitude"].ToString(),
                    latitude = dataReader["latitude"].ToString(),
                    farmName = dataReader["farmName"].ToString(),
                    farmPic = dataReader["farmPic"].ToString(),
                    productName = dataReader["productName"].ToString(),
                    productPic = dataReader["productPic"].ToString()
                });
            }
            return tendersWithDetails;
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
    public List<Object> ReadTendersByConsumerBids(int consumerId)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTendersByConsumerBids_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@consumerNum", consumerId);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> tendersWithDetails = new List<Object>();

            while (dataReader.Read())
            {
                tendersWithDetails.Add(new
                {
                    id = Convert.ToInt32(dataReader["id"]),
                    offeredPacks = dataReader["offeredPacks"].ToString(),
                    packsAmount = Convert.ToInt32(dataReader["packsAmount"]),
                    initialOffer = Convert.ToSingle(dataReader["initialOffer"]),
                    closeDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(),
                    collectAddress = dataReader["collectAddress"].ToString(),
                    collectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(),
                    farmNum = Convert.ToInt32(dataReader["farmNum"]),
                    productNum = Convert.ToInt32(dataReader["productNum"]),
                    collectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(),
                    active = Convert.ToBoolean(dataReader["active"]),
                    longitude = dataReader["longitude"].ToString(),
                    latitude = dataReader["latitude"].ToString(),
                    farmName = dataReader["farmName"].ToString(),
                    farmPic = dataReader["farmPic"].ToString(),
                    productName = dataReader["productName"].ToString(),
                    productPic = dataReader["productPic"].ToString()
                });
            }
            return tendersWithDetails;
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
    public List<Object> ReadTendersByFarm(int farmID)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTendersByFarm_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@farmNum", farmID);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> tendersWithDetails = new List<Object>();

            while (dataReader.Read())
            {
                tendersWithDetails.Add(new
                {
                    id = Convert.ToInt32(dataReader["id"]),
                    offeredPacks = dataReader["offeredPacks"].ToString(),
                    packsAmount = Convert.ToInt32(dataReader["packsAmount"]),
                    initialOffer = Convert.ToSingle(dataReader["initialOffer"]),
                    closeDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(),
                    collectAddress = dataReader["collectAddress"].ToString(),
                    collectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(),
                    farmNum = Convert.ToInt32(dataReader["farmNum"]),
                    productNum = Convert.ToInt32(dataReader["productNum"]),
                    collectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(),
                    active = Convert.ToBoolean(dataReader["active"]),
                    longitude = dataReader["longitude"].ToString(),
                    latitude = dataReader["latitude"].ToString(),
                    farmName = dataReader["farmName"].ToString(),
                    farmPic = dataReader["farmPic"].ToString(),
                    productName = dataReader["productName"].ToString(),
                    productPic = dataReader["productPic"].ToString()
                });
            }
            return tendersWithDetails;
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
    public List<Object> ReadTenderBidsDetails(int tenderID)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Object> tenderBidsDetails = new List<Object>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTenderBidsDetails_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@tenderNum", tenderID);
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                tenderBidsDetails.Add(new
                {
                    BidId = Convert.ToInt32(dataReader["BidId"]),
                    BidAmount = Convert.ToInt32(dataReader["BidAmount"]),
                    UnitPrice = Convert.ToSingle(dataReader["UnitPrice"]),
                    BidStatus = dataReader["BidStatus"].ToString(),
                    BidSortedNum = Convert.ToInt32(dataReader["BidSortedNum"]),
                    ConsumerId = Convert.ToInt32(dataReader["ConsumerId"]),
                    ConsumerFirstName = dataReader["ConsumerFirstName"].ToString(),
                    ConsumerLastName = dataReader["ConsumerLastName"].ToString(),
                    ConsumerPhoneNum = dataReader["ConsumerPhoneNum"].ToString()
                });
            }
            return tenderBidsDetails;
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
    public List<Object> ReadTendersConsumerWin(int consumerId)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTendersConsumerWin_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@consumerNum", consumerId);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> tendersWithDetails = new List<Object>();

            while (dataReader.Read())
            {
                tendersWithDetails.Add(new
                {
                    id = Convert.ToInt32(dataReader["id"]),
                    offeredPacks = dataReader["offeredPacks"].ToString(),
                    packsAmount = Convert.ToInt32(dataReader["packsAmount"]),
                    initialOffer = Convert.ToSingle(dataReader["initialOffer"]),
                    closeDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(),
                    collectAddress = dataReader["collectAddress"].ToString(),
                    collectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(),
                    farmNum = Convert.ToInt32(dataReader["farmNum"]),
                    productNum = Convert.ToInt32(dataReader["productNum"]),
                    collectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(),
                    active = Convert.ToBoolean(dataReader["active"]),
                    longitude = dataReader["longitude"].ToString(),
                    latitude = dataReader["latitude"].ToString(),
                    farmName = dataReader["farmName"].ToString(),
                    farmPic = dataReader["farmPic"].ToString(),
                    productName = dataReader["productName"].ToString(),
                    productPic = dataReader["productPic"].ToString()
                });
            }
            return tendersWithDetails;
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
    public List<Object> ReadTendersConsumerWinShowInOrders(int consumerId)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetTendersConsumerWinShowInOrders_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@consumerNum", consumerId);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> tendersWithDetails = new List<Object>();

            while (dataReader.Read())
            {
                tendersWithDetails.Add(new
                {
                    id = Convert.ToInt32(dataReader["id"]),
                    offeredPacks = dataReader["offeredPacks"].ToString(),
                    packsAmount = Convert.ToInt32(dataReader["packsAmount"]),
                    initialOffer = Convert.ToSingle(dataReader["initialOffer"]),
                    closeDateHour = Convert.ToDateTime(dataReader["closeDateHour"]).ToString(),
                    collectAddress = dataReader["collectAddress"].ToString(),
                    collectDateHour = Convert.ToDateTime(dataReader["collectDateHour"]).ToString(),
                    farmNum = Convert.ToInt32(dataReader["farmNum"]),
                    productNum = Convert.ToInt32(dataReader["productNum"]),
                    collectDateHourClose = Convert.ToDateTime(dataReader["collectDateHourClose"]).ToString(),
                    active = Convert.ToBoolean(dataReader["active"]),
                    longitude = dataReader["longitude"].ToString(),
                    latitude = dataReader["latitude"].ToString(),
                    farmName = dataReader["farmName"].ToString(),
                    farmPic = dataReader["farmPic"].ToString(),
                    productName = dataReader["productName"].ToString(),
                    productPic = dataReader["productPic"].ToString(),
                    amount = Convert.ToInt32(dataReader["amount"]),
                    unitPrice = Convert.ToSingle(dataReader["unitPrice"]),
                    sortedNum = Convert.ToInt32(dataReader["sortedNum"]),
                    bidTotalPrice = Convert.ToSingle(dataReader["bidTotalPrice"]),
                    actualAmount = Convert.ToInt32(dataReader["actualAmount"])
                });
            }
            return tendersWithDetails;
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
    public List<Object> CalculateScoreTenderConsumer(int tenderID)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_CalculateScoreAndInsertTopTwoConsumers", con);             // create the command
        cmd.Parameters.AddWithValue("@TenderNum", tenderID);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Object> scores = new List<Object>();

            while (dataReader.Read())
            {
                scores.Add(new
                {
                    consumerNum = Convert.ToInt32(dataReader["id"]),
                    Score = Convert.ToInt32(dataReader["id"])
                });
            }
            return scores;
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


    //product avg price
    public float ReadAvgProductPrice(int productID)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetProductAvgPrice_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@productID", productID);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            float AvgPrice = 0;

            while (dataReader.Read())
            {
                AvgPrice = Convert.ToSingle(dataReader["AvgPrice"]);
            }
            return AvgPrice;
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

    //Bids
    public List<Bids> ReadBids(int tenderID)
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
        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetBids_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@tenderID", tenderID);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<Bids> bids = new List<Bids>();
            while (dataReader.Read())
            {
                Bids b = new Bids();
                b.TenderNum = Convert.ToInt32(dataReader["tendertNum"]);
                b.Id = Convert.ToInt32(dataReader["id"]);
                b.Amount = Convert.ToInt32(dataReader["amount"]);
                b.UnitPrice = Convert.ToSingle(dataReader["unitPrice"]);
                b.Status = dataReader["status"].ToString();
                b.SortedNum = Convert.ToInt32(dataReader["sortedNum"]);
                b.BidDate = Convert.ToDateTime(dataReader["bidDate"]);
                b.ConsumerNum = Convert.ToInt32(dataReader["consumerNum"]);
                bids.Add(b);
            }
            return bids;
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
    public int ReadOfferedPacks(int tenderID)
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
        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_GetOfferedPacks_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@tenderID", tenderID);

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            int offer = 0;
            while (dataReader.Read())
            {
                offer = Convert.ToInt32(dataReader["offeredPacks"]);

            }
            return offer;
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
    public int UpdateTenderActivity(int tenderID, bool active)
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

        cmd = CreateTenderUpdateActivityCommandWithStoredProcedure("sp_UpdateTenderActivity_2024", con, tenderID, active);             // create the command
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

    //Bids
    public int UpdateBidsStatusAndSortedNum(List<Bids> sortedBids)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_UpdateBidsStatusAndSortedNum_2024", con);             // create the command
        try
        {
            int rowsAffected = 0;
            foreach (var b in sortedBids)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", b.Id);
                cmd.Parameters.AddWithValue("@status", b.Status);
                cmd.Parameters.AddWithValue("@sortedNum", b.SortedNum);

                rowsAffected += cmd.ExecuteNonQuery();
            }
            return rowsAffected;
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
    // methods that Delete (change value to "Deleted")
    //--------------------------------------------------------------------------------------------------

    //Bids
    public int DeleteBid(int bidID)
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

        cmd = CreateCommandWithStoredProcedureWithoutParameters("sp_DeleteBid_2024", con);             // create the command
        cmd.Parameters.AddWithValue("@bidID", bidID);

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

    private SqlCommand CreateCommandWithStoredProcedureWithoutParameters(String spName, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

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
        DateTime collectDateHourClose = DateTime.Parse(tender.CollectDateHourClose);
        DateTime closeDateHour = DateTime.Parse(tender.CloseDateHour);

        cmd.Parameters.AddWithValue("@offeredPacks", tender.OfferedPacks);
        cmd.Parameters.AddWithValue("@packsAmount", tender.PacksAmount);
        cmd.Parameters.AddWithValue("@initialOffer", tender.InitialOffer);
        cmd.Parameters.AddWithValue("@closeDateHour", closeDateHour);
        cmd.Parameters.AddWithValue("@collectAddress", tender.CollectAddress);
        cmd.Parameters.AddWithValue("@collectDateHour", collectDateHour);
        cmd.Parameters.AddWithValue("@farmNum", tender.FarmNum);
        cmd.Parameters.AddWithValue("@productNum", tender.ProductNum);
        cmd.Parameters.AddWithValue("@collectDateHourClose", collectDateHourClose);
        cmd.Parameters.AddWithValue("@longitude", tender.Longitude);
        cmd.Parameters.AddWithValue("@latitude", tender.Latitude);

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
    private SqlCommand CreateTenderUpdateActivityCommandWithStoredProcedure(String spName, SqlConnection con, int tenderID, bool active)
    {


        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@id", tenderID);
        cmd.Parameters.AddWithValue("@active", active);


        return cmd;
    }

    //Bids
    private SqlCommand CreateBidInsertCommandWithStoredProcedure(String spName, SqlConnection con, Bids bid)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        //DateTime BidDate = DateTime.Parse(bid.BidDate);

        cmd.Parameters.AddWithValue("@tenderNum", bid.TenderNum);
        cmd.Parameters.AddWithValue("@amount", bid.Amount);
        cmd.Parameters.AddWithValue("@unitPrice", bid.UnitPrice);
        cmd.Parameters.AddWithValue("@status", bid.Status);
        cmd.Parameters.AddWithValue("@consumerNum", bid.ConsumerNum);
        cmd.Parameters.AddWithValue("@bidDate", bid.BidDate);
        cmd.Parameters.AddWithValue("@sortedNum", bid.SortedNum);

        return cmd;
    }

}


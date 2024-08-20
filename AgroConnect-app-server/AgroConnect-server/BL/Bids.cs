namespace AgroConnect_server.BL
{
    public class Bids
    {
        int tenderNum;
        int id;
        int amount;
        float unitPrice;
        string status;
        int consumerNum;
        DateTime bidDate;
        int sortedNum;

        public Bids(int tenderNum, int id, int amount, float unitPrice, string status, int consumerNum, DateTime bidDate, int sortedNum)
        {
            this.TenderNum = tenderNum;
            this.Id = id;
            this.Amount = amount;
            this.UnitPrice = unitPrice;
            this.Status = status;
            this.ConsumerNum = consumerNum;
            this.BidDate = bidDate;
            this.SortedNum = sortedNum;
        }

        public Bids() { }

        public int TenderNum { get => tenderNum; set => tenderNum = value; }
        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public float UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string Status { get => status; set => status = value; }
        public int ConsumerNum { get => consumerNum; set => consumerNum = value; }
        public DateTime BidDate { get => bidDate; set => bidDate = value; }
        public int SortedNum { get => sortedNum; set => sortedNum = value; }

        public List<Object> Insert(int tenderID)
        {
            this.bidDate = DateTime.Now;//add the bid's post time
            DBservices2 dbs = new DBservices2();
            dbs.InsertBid(this);//post bid
            return checkWinners(tenderID);//update status and sortedNum in all the tender's bids
            //and return the updated tender's bids details
        }
        public List<Bids> Read(int tenderID)
        {
            DBservices2 dbs = new DBservices2();
            return dbs.ReadBids(tenderID);
        }
        public List<Object> Delete(int bidID, int tenderID)
        {
            DBservices2 dbs = new DBservices2();
            dbs.DeleteBid(bidID);
            return checkWinners(tenderID);
        }

        private List<Object> checkWinners(int tenderID)
        {
            DBservices2 dbs = new DBservices2();
            List<Bids> bids = new List<Bids>();
            bids = dbs.ReadBids(tenderID);//get all tender's bids
            int offeredPacks = dbs.ReadOfferedPacks(tenderID);//get the number of offered packs
            var sortedBids = bids
                .OrderByDescending(b => b.UnitPrice)
                .ThenBy(b => b.BidDate)
                .ToList();
            int totalAmount = 0;
            int counterSortedNum = 1;
            foreach (var bid in sortedBids)
            {
                if (totalAmount + bid.Amount <= offeredPacks)
                {
                    bid.Status = "win";
                    bid.SortedNum = counterSortedNum;
                    counterSortedNum++;
                    totalAmount += bid.Amount;
                }
                else
                {
                    if (totalAmount < offeredPacks)
                    {
                        int newAmount = offeredPacks - totalAmount;
                        bid.Status = "win " + newAmount;
                        bid.SortedNum = counterSortedNum;
                        counterSortedNum++;
                        totalAmount = offeredPacks;
                    }
                    else
                    {
                        bid.Status = "lose";
                        bid.SortedNum = counterSortedNum;
                        counterSortedNum++;
                    }
                }
            }
            dbs.UpdateBidsStatusAndSortedNum(sortedBids);
            return dbs.ReadTenderBidsDetails(tenderID);//read the updated details of the bids
        }
    }
}

using System;
using System.Collections.Generic;

namespace AgroConnect_server.BL
{
    public class OrdersInPoint
    {
        int id;
        int salePointNum;
        int productInFarmNum;
        int orderNum;
        int amount;
        int rankProduct;

        public int Id { get => id; set => id = value; }
        public int SalePointNum { get => salePointNum; set => salePointNum = value; }
        public int ProductInFarmNum { get => productInFarmNum; set => productInFarmNum = value; }
        public int OrderNum { get => orderNum; set => orderNum = value; }
        public int Amount { get => amount; set => amount = value; }
        public int RankProduct { get => rankProduct; set => rankProduct = value; }

        public OrdersInPoint(int id, int salePointNum, int productInFarmNum, int orderNum, int amount, int rankProduct)
        {
            this.Id = id;
            this.SalePointNum = salePointNum;
            this.ProductInFarmNum = productInFarmNum;
            this.OrderNum = orderNum;
            this.Amount = amount;
            this.RankProduct = rankProduct;
        }

        public OrdersInPoint() { }

        //public OrdersInPoint Insert()
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.InsertOrderInPoint(this);
        //}

        public static int InsertOrderProductsInPoint(List<OrdersInPoint> productsInPointOrderList)
        {
            if (productsInPointOrderList == null || !productsInPointOrderList.Any())
            {
                return -1; // Return an empty list if the input list is null or empty
            }

            DBservices dbs = new DBservices();
            int lastOrderNum = -1;

            foreach (var product in productsInPointOrderList)
            {
                try
                {
                    int orderNum = dbs.InsertProductInPointOrder(product);
                    if (orderNum > 0) // Assuming a positive result means success
                    {
                        lastOrderNum = orderNum; // Update the last order number
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (log logic not shown here)
                    continue;
                }
            }

            return lastOrderNum;
        }

        public List<OrdersInPoint> ReadBySalePointId(int salePointId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadOrdersBySalePointId(salePointId);
        }

        public List<OrdersInPoint> ReadDetailsByOrderId(int orderId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadOrderInPointDetailsByOrdertId(orderId);
        }

        public OrdersInPoint Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateOrdersInPoint(this);
        }
    }
}

using System.Collections.Generic;

namespace AgroConnect_server.BL
{
    public class FarmProductsInPoint
    {
        int id;
        int salePointNum;
        int productInFarmNum;
        int productAmount;
        float unitPrice;

        public int Id { get => id; set => id = value; }
        public int SalePointNum { get => salePointNum; set => salePointNum = value; }
        public int ProductInFarmNum { get => productInFarmNum; set => productInFarmNum = value; }
        public int ProductAmount { get => productAmount; set => productAmount = value; }
        public float UnitPrice { get => unitPrice; set => unitPrice = value; }

        public FarmProductsInPoint(int id, int salePointNum, int productInFarmNum, int productAmount, int unitPrice)
        {
            this.Id = id;
            this.SalePointNum = salePointNum;
            this.ProductInFarmNum = productInFarmNum;
            this.ProductAmount = productAmount;
            this.UnitPrice = unitPrice;
        }

        public FarmProductsInPoint() { }

        public static List<FarmProductsInPoint> InsertProducts(List<FarmProductsInPoint> productsList)
        {
            if (productsList == null || !productsList.Any())
            {
                return new List<FarmProductsInPoint>(); // Return an empty list if the input list is null or empty
            }

            DBservices dbs = new DBservices();
            List<FarmProductsInPoint> addedProducts = new List<FarmProductsInPoint>();

            foreach (var product in productsList)
            {
                try
                {
                    int result = dbs.InsertFarmProductInPoint(product);
                    if (result > 0) // Assuming a positive result means success
                    {
                        addedProducts.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (log logic not shown here)
                    continue;
                }
            }

            return addedProducts;
        }

        public List<FarmProductsInPoint> ReadById(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadProductsInPointById(id);
        }

        public FarmProductsInPoint Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateProductInPoint(this);
        }
    }


}

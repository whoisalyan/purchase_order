namespace PurcaseOrder.Models
{
    public class Customer
    {
        public Customer()
        {
            List<PO> PO = new List<PO>();

        }
        public int ID { get; set; }
        public String CustomerName { get; set; }
        public String CustomerLocation{ get; set; }
        public IList<PO> PurchaseOrders { get; set; }


    }
}

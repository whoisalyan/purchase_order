namespace PurcaseOrder.Models
{
    public class PO
    {
        public PO()
        {
            List<Products> Products = new List<Products>();
        }

        public int ID { get; set; }
        public DateTime PoTime { get; set; }
        public bool isDraft { get; set; }
        public Customer CustomerName { get; set; }
        public IList<Products> ListItem { get; set; }

    }
}

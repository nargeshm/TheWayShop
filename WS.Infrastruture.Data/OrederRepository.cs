using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WS.Core.Contracts.Repository;
using WS.Core.Entites;
using WS.Infrastruture.Sql;

namespace WS.Infrastruture.Data
{
    public class OrederRepository : IOrderRepository
    {
        private readonly DemoContext context;

        public OrederRepository(DemoContext context)
        {

            this.context = context;
        }



        public void PaymentDone(string token, int tId)
        {
            try
            {
                var order = context.Orders.Where(c => c.paymentToken == token.ToString()).First();
                order.PaymentDate = DateTime.Now;
                order.PaymentId = tId.ToString();
                //add seller count in each transition
              var order1=  context.Entry(order).Collection(a => a.Lines).Query().Include(a => a.Product);
              
                foreach (var item in order1.Select(a => a.Product) )
                {
                    item.SellerCount++;
                }
             
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save(Order order)
        {
            context.AttachRange(order.Lines.Select(a => a.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        public void SetOrderToken(int orderId, string token)
        {
            try
            {
                var order = context.Orders.Find(orderId);
                order.paymentToken = token;
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }
}

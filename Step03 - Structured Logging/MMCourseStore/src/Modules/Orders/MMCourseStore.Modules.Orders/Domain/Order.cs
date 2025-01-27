using MMCourseStore.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Orders.Domain;
public class Order : AggregateRoot<long>
{
    public long StudentId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];

    public Order(long id,long studentId, DateTime orderDate)
    {
        Id = id;
        StudentId = studentId;
        OrderDate = orderDate;
    }

    public Result AddItem(long id,long courseId,int quantity, int price)
    {
        OrderItem item = OrderItems.FirstOrDefault(c=>c.Id== courseId);
        if(item==null)
        {
            item = new OrderItem(id,courseId,quantity,price);
        }
        else
        {
            item.AddQuantity(quantity);
        }
        return Result.Success();
    }

}

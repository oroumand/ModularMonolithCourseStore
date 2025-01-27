using MMCourseStore.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Orders.Domain;
public class OrderItem:BaseEntity<long> 
{
    public OrderItem(long id, long courseId,int quantity,int price)
    {
        Id = id;
        CourseId = courseId;
        Quantity = quantity;
        Price = price;
    }
    public long OrderId { get; set; }
    public long CourseId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public Result AddQuantity(int addedCount )
    {
        Quantity += addedCount; 
        return Result.Success();
    }

}

using MMCourseStore.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Orders.ApplicationServices.Commands.CreateOrder;
public record CreateOrderCommand(long studentId, long courseId):ICommand<long>;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Framework.Services.IdGeneratorServices;
public interface IIdGenerator<TId>
{
    TId GetId();
}

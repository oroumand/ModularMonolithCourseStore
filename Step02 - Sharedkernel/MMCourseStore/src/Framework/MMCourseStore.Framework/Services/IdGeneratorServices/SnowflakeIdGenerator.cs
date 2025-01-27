using IdGen;

namespace HouseRent.Infra.SnowflakeIdGenerators;

public class SnowflakeIdGenerator(IdGenerator generator) : MMCourseStore.Framework.Services.IdGeneratorServices.IIdGenerator<long>
{
    private readonly IdGenerator _generator = generator;

    public long GetId()
    {
        return _generator.CreateId();
    }
}

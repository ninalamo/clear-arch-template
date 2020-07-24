using AutoMapper;

namespace Core.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        abstract void Mapping(Profile profile);//=> profile.CreateMap(typeof(T), GetType());
    }
}
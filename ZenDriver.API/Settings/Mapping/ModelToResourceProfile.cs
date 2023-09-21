using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Resources;

namespace ZenDriver.API.Settings.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Education, EducationResource>();
        CreateMap<School, SchoolResource>();
    }
}
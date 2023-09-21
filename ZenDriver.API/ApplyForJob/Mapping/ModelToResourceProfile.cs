using AutoMapper;
using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Resources;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Resources;

namespace ZenDriver.API.ApplyForJob.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Address, AddressResource>();
        CreateMap<Company, CompanyResource>();
        CreateMap<Post, PostResource>();
        CreateMap<Recruiter, RecruiterResource>();
    }
}
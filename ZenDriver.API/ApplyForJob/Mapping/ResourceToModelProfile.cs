using AutoMapper;
using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Resources;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Resources;

namespace ZenDriver.API.ApplyForJob.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAddressResource, Address> ();
        CreateMap<SaveCompanyResource, Company> ();
        CreateMap<SavePostResource, Post> ();
        CreateMap<SaveRecruiterResource, Recruiter> ();
    }
}

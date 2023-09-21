using ZenDriver.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.Security.Domain.Models;
using ZenDriver.API.Settings.Domain.Models;
using Address = ZenDriver.API.ApplyForJob.Domain.Models.Address;
using Company = ZenDriver.API.ApplyForJob.Domain.Models.Company;
using Driver = ZenDriver.API.DriverProfile.Domain.Models.Driver;
using License = ZenDriver.API.DriverProfile.Domain.Models.License;
using Post = ZenDriver.API.ApplyForJob.Domain.Models.Post;
using Recruiter = ZenDriver.API.ApplyForJob.Domain.Models.Recruiter;
using SocialNetwork = ZenDriver.API.SocialNetworking.Domain.Models.SocialNetwork;
using DriverProfile = ZenDriver.API.DriverProfile.Domain.Models.DriverProfile;

namespace ZenDriver.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    
    public DbSet<Driver> Drivers { get; set; }

    public DbSet<DriverProfile.Domain.Models.DriverProfile> Driverprofiles { get; set; }
    
    public DbSet<License> Licenses { get; set; }
    
    public DbSet<School> Schools { get; set; }
    
    public DbSet<Education> Educations { get; set; }

    public DbSet<Address> Address { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    public DbSet<MessageZenDriver> Messages { get; set; }
    
    public DbSet<NotificationZenDriver> Notifications { get; set; }

    public AppDbContext(DbContextOptions options) : base (options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    base.OnModelCreating(builder);
        //Social Network
        builder.Entity<SocialNetwork>().ToTable("SocialNetwork");
        builder.Entity<SocialNetwork>().HasKey(p => p.Id);
        builder.Entity<SocialNetwork>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SocialNetwork>().Property(p => p.DescriptionSocialNetwork).IsRequired().HasMaxLength(500);
        builder.Entity<SocialNetwork>().Property(p => p.UrlImageSocialNetwork).IsRequired().HasMaxLength(500);
        builder.Entity<SocialNetwork>().Property(p => p.Like).IsRequired().ValueGeneratedOnAdd();
        //Relationsships
        builder.Entity<SocialNetwork>()
            .HasOne(p => p.User)
            .WithMany(p => p.SocialNetworks)
            .HasForeignKey(p => p.UserId);

        //Address
        builder.Entity<Address>().ToTable("Address");
        builder.Entity<Address>().HasKey(p => p.Id);
        builder.Entity<Address>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Address>().Property(p => p.NameAddress).IsRequired().HasMaxLength(500);
        //Relationsships
        builder.Entity<Address>()
            .HasOne(p => p.User)
            .WithMany(p => p.Address)
            .HasForeignKey(p => p.UserId);
        
        //Driver
        builder.Entity<Driver>().ToTable("Driver");
        builder.Entity<Driver>().HasKey(p => p.Id);
        builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Relationsships
        builder.Entity<Driver>()
            .HasOne(p => p.User)
            .WithOne(p => p.Driver)
            .HasForeignKey<Driver>(p => p.UserId);
        
        //Driverprofile
        builder.Entity<DriverProfile.Domain.Models.DriverProfile>().ToTable("Driverprofile");
        builder.Entity<DriverProfile.Domain.Models.DriverProfile>().HasKey(p => p.Id);
        builder.Entity<DriverProfile.Domain.Models.DriverProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Relationsships
        builder.Entity<DriverProfile.Domain.Models.DriverProfile>()
            .HasOne(p => p.Driver)
            .WithOne(p => p.DriverProfile)
            .HasForeignKey<DriverProfile.Domain.Models.DriverProfile>(p => p.DriverId);
        // builder.Entity<DriverProfile.Domain.Models.DriverProfile>()
        //     .HasOne(p => p.License)
        //     .WithOne(p => p.DriverProfile)
        //     .HasForeignKey<DriverProfile.Domain.Models.DriverProfile>(p => p.LicenseId);
        
        //License
        builder.Entity<License>().ToTable("License");
        builder.Entity<License>().HasKey(p => p.Id);
        builder.Entity<License>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        //Education
        builder.Entity<Education>().ToTable("Education");
        builder.Entity<Education>().HasKey(p => p.Id);
        builder.Entity<Education>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Education>().Property(p => p.Grade_education).IsRequired();
        //Relationsships
        builder.Entity<Education>()
            .HasOne(p => p.DriverProfile)
            .WithOne(p => p.Education)
            .HasForeignKey<Education>(p => p.DriverprofileId);
        
        //School
        builder.Entity<School>().ToTable("School");
        builder.Entity<School>().HasKey(p => p.Id);
        builder.Entity<School>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<School>().Property(p => p.name_school).IsRequired();
        builder.Entity<School>().Property(p => p.type).IsRequired();
        //Relationsships
        builder.Entity<School>()
            .HasOne(p => p.Education)
            .WithMany(p => p.Schooles)
            .HasForeignKey(p => p.EducationId);

        //Users
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.UserName).IsRequired();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Role).IsRequired().HasMaxLength(10);
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Description);
        builder.Entity<User>().Property(p => p.ImageUrl);
        builder.Entity<User>().Property(p => p.BirthdayDate).HasDefaultValue(DateTime.Now);

        //Messages
        builder.Entity<MessageZenDriver>().ToTable("Messages");
        builder.Entity<MessageZenDriver>().HasKey(p => p.Id);
        builder.Entity<MessageZenDriver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MessageZenDriver>().Property(p => p.Content).IsRequired();
        builder.Entity<MessageZenDriver>().Property(p => p.CreatedAt).IsRequired();
        //Relations
        builder.Entity<MessageZenDriver>()
            .HasOne(p => p.Emitter)
            .WithMany(p => p.EmittedMessages)
            .HasForeignKey(p => p.EmitterId);
        //.WithMany(p => p.ReceivedMessages)

        builder.Entity<MessageZenDriver>()
            .HasOne(p => p.Receiver)
            .WithMany(p => p.ReceivedMessages)
            .HasForeignKey(p => p.ReceiverId); 
        
        // Companies
        builder.Entity<Company>().ToTable("Companies");
        builder.Entity<Company>().HasKey(p => p.Id);
        builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Company>().Property(p => p.Name).IsRequired();
        builder.Entity<Company>().Property(p => p.RUC).IsRequired().HasMaxLength(11);
        builder.Entity<Company>().Property(p => p.Owner).IsRequired();
        builder.Entity<Company>().Property(p => p.Image_url).IsRequired();
        
        // Recruiters
        builder.Entity<Recruiter>().ToTable("Recruiters");
        builder.Entity<Recruiter>().HasKey(p => p.Id);
        builder.Entity<Recruiter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        // Relationsships
        builder.Entity<Recruiter>()
            .HasOne(p => p.Company)
            .WithMany(p => p.Recruiters)
            .HasForeignKey(p => p.CompanyId);
        builder.Entity<Recruiter>()
            .HasOne(p => p.User)
            .WithOne(p => p.Recruiter)
            .HasForeignKey<Recruiter>(p => p.UserId);

        // Posts
        builder.Entity<Post>().ToTable("Posts");
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Post>().Property(p => p.Title).IsRequired(); 
        builder.Entity<Post>().Property(p => p.Description).IsRequired();
        builder.Entity<Post>().Property(p => p.date).IsRequired();
        // Relationsships
        builder.Entity<Post>()
            .HasOne(p => p.Recruiter)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.RecruiterId);
        
        //Notifications
        builder.Entity<NotificationZenDriver>().ToTable("Notifications");
        builder.Entity<NotificationZenDriver>().HasKey(p => p.Id);
        builder.Entity<NotificationZenDriver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<NotificationZenDriver>().Property(p => p.Content).IsRequired();
        //Relations
        builder.Entity<NotificationZenDriver>()
            .HasOne(p => p.Emitter)
            .WithMany(p => p.EmittedNotifications)
            .HasForeignKey(p => p.EmitterId);
        //.WithMany(p => p.ReceivedMessages)

        builder.Entity<NotificationZenDriver>()
            .HasOne(p => p.Receiver)
            .WithMany(p => p.ReceivedNotifications)
            .HasForeignKey(p => p.ReceiverId);
        //.WithMany(p => p.EmittedMessages)
       
        
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}

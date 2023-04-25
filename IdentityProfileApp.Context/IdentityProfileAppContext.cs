using IdentityProfileApp.Domain.Entities.Models;
using System.Data.Entity;

namespace IdentityProfileApp.Context
{
    public class IdentityProfileAppContext : DbContext
    {
        public IdentityProfileAppContext() : base("IdentityProfileAppConnection")
        {
            Database.SetInitializer<IdentityProfileAppContext>(new IPInitializer<IdentityProfileAppContext, Configuration>());
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<FeedBackAnswer> FeedBackAnswer { get; set; }
        public DbSet<FeedBackQuestion> FeedBackQuestion { get; set; }
        public DbSet<PaymentPackage> PaymentPackage { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileDuty> ProfileTask { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionGroup> QuestionGroup { get; set; }
        public DbSet<Duty> Duty { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPackage> UserPackage { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<LogError> Errors { get; set; }
        public DbSet<UserDiscount> UserDiscounts { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<ProfilePart> ProfilePart { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LanguageResource> LanguageResource { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Setting> Setting { get; set; }
    }
}

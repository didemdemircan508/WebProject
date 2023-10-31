using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities.Entities.Identity;

namespace WebProject.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable("AspNetUsers");

            var adminUser = new User
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMINUSER",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+905555555555",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()


            };
            adminUser.PasswordHash = CreatePasswordHash(adminUser, "adminuser");

            var memberUser = new User
            {
                Id = 2,
                UserName = "memberuser",
                NormalizedUserName = "MEMBERUSER",
                Email = "member@gmail.com",
                NormalizedEmail = "member@GMAIL.COM",
                PhoneNumber = "+905555555555",
              
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()


            };
            memberUser.PasswordHash = CreatePasswordHash(memberUser, "memberuser");


            builder.HasData(adminUser);
            builder.HasData(memberUser);


        }

        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }

    }
}


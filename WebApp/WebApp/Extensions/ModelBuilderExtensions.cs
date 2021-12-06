using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Commons;
using WebApp.Entities;

namespace WebApp.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void OptionSeeding(this ModelBuilder modelBuilder)
        {
            // Thiết lập các Options
            modelBuilder.Entity<Option>().HasData(
              new Option() { Id = SystemConstants.OptionStatic.color, Name = nameof(SystemConstants.OptionStatic.color), IsNumber = false },
              new Option() { Id = SystemConstants.OptionStatic.sizeWidth, Name = nameof(SystemConstants.OptionStatic.sizeWidth), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.sizeHeight, Name = nameof(SystemConstants.OptionStatic.sizeHeight), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.sizeDepth, Name = nameof(SystemConstants.OptionStatic.sizeDepth), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.rotateX, Name = nameof(SystemConstants.OptionStatic.rotateX), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.rotateY, Name = nameof(SystemConstants.OptionStatic.rotateY), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.rotateZ, Name = nameof(SystemConstants.OptionStatic.rotateZ), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.minHeight, Name = nameof(SystemConstants.OptionStatic.minHeight), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.maxHeight, Name = nameof(SystemConstants.OptionStatic.maxHeight), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.n, Name = nameof(SystemConstants.OptionStatic.n), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.width, Name = nameof(SystemConstants.OptionStatic.width), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.outlineColor, Name = nameof(SystemConstants.OptionStatic.outlineColor), IsNumber = false },
              new Option() { Id = SystemConstants.OptionStatic.outlineWidth, Name = nameof(SystemConstants.OptionStatic.outlineWidth), IsNumber = true },
              new Option() { Id = SystemConstants.OptionStatic.m, Name = nameof(SystemConstants.OptionStatic.m), IsNumber = true }
              );
        }

        //public static void FaceType_FaceTypeOption_Seeding(this ModelBuilder modelBuilder)
        //{
        //    // Sẽ thêm chức năng tạo cho admin

        //    // Thiết lập các FaceType, FaceTypeOption

        //    //Face 1: mặt cong
        //    modelBuilder.Entity<FaceType>().HasData(
        //      new FaceType()
        //      {
        //          Id = 1,
        //          Name = "Vẽ mặt cong",
        //          Description = "Vẽ mặt phẳng cong bằng cách chia nhỏ ra thành hiều mặt phẳng, làm mịn mặt cong"
        //      });

        //    modelBuilder.Entity<FaceTypeOption>().HasData(
        //        new FaceTypeOption() { Id = 1, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.n },
        //        new FaceTypeOption() { Id = 2, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.minHeight },
        //        new FaceTypeOption() { Id = 3, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.maxHeight },
        //        new FaceTypeOption() { Id = 4, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.color },
        //        new FaceTypeOption() { Id = 5, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.outlineColor },
        //        new FaceTypeOption() { Id = 6, FaceTypeId = 1, OptionId = SystemConstants.OptionStatic.outlineWidth }
        //        );

        //    // Face 2: mặt cong
        //    modelBuilder.Entity<FaceType>().HasData(
        //      new FaceType()
        //      {
        //          Id = 2,
        //          Name = "Vẽ mặt phẳng bánh",
        //          Description = "Vẽ mặt phẳng bánh hoàn hảo"
        //      });

        //    modelBuilder.Entity<FaceTypeOption>().HasData(
        //        new FaceTypeOption() { Id = 7, FaceTypeId = 2, OptionId = SystemConstants.OptionStatic.minHeight },
        //        new FaceTypeOption() { Id = 8, FaceTypeId = 2, OptionId = SystemConstants.OptionStatic.n },
        //        new FaceTypeOption() { Id = 9, FaceTypeId = 2, OptionId = SystemConstants.OptionStatic.color },
        //        new FaceTypeOption() { Id = 10, FaceTypeId = 2, OptionId = SystemConstants.OptionStatic.outlineColor },
        //        new FaceTypeOption() { Id = 11, FaceTypeId = 2, OptionId = SystemConstants.OptionStatic.outlineWidth }
        //        );
        //}
    }
}

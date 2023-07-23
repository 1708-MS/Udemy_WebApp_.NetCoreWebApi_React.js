using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy_WebApp.Domain.Models;

namespace Udemy_WebApp.Infrastructure.ModelConfigurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(Course => Course.CourseId);
            builder.Property(Course => Course.CourseTitle).IsRequired();
            builder.Property(Course => Course.CourseDescription).IsRequired();
            builder.Property(Course => Course.CourseListPrice).HasColumnType("decimal(7, 2)").IsRequired();
            builder.Property(Course => Course.CourseCreatedAt).IsRequired();
            builder.Property(Course => Course.CourseDurationTime).HasColumnName("DurationTime(in Hours)").HasColumnType("decimal(5, 2)");

            // Configuration of the relationship with CourseCategory
            builder.HasOne(Course => Course.CourseCategory)
                .WithMany(CourseCategory => CourseCategory.Courses)
                .HasForeignKey(Course => Course.CourseCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the one-to-many relationship between Course and Level
            builder.HasOne(c => c.Level)
                   .WithMany(l => l.Courses)
                   .HasForeignKey(c => c.LevelId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configure the one-to-many relationship between Course and Language
            builder.HasOne(c => c.Language)
                   .WithMany(l => l.Courses)
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
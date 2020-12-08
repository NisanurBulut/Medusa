using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.DataAccess.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.ToTable("tComment", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Description).HasColumnType("ntext").IsRequired().HasMaxLength(400);
            builder.Property(a => a.AuthorEmail).IsRequired().HasMaxLength(100);
            builder.Property(a => a.AuthorName).IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.SubComments).WithOne(a => a.ParentComment).HasForeignKey(a=>a.ParentCommentId);
        }
    }
}

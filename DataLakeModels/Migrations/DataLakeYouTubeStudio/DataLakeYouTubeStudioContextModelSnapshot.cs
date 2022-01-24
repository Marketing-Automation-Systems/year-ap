﻿// <auto-generated />
using System;
using DataLakeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLakeModels.Migrations.DataLakeYouTubeStudio
{
    [DbContext(typeof(DataLakeYouTubeStudioContext))]
    partial class DataLakeYouTubeStudioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("youtube_studio_v1")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataLakeModels.Models.YouTube.Studio.Video", b =>
                {
                    b.Property<string>("VideoId");

                    b.Property<DateTime>("ValidityStart");

                    b.Property<string>("ChannelId");

                    b.Property<DateTime>("DateMeasure");

                    b.Property<string>("Metric");

                    b.Property<DateTime>("ValidityEnd");

                    b.Property<double>("Value");

                    b.HasKey("VideoId", "ValidityStart");

                    b.ToTable("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}

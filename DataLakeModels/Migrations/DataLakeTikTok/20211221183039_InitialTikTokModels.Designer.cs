﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DataLakeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLakeModels.Migrations.DataLakeTikTok
{
    [DbContext(typeof(DataLakeTikTokContext))]
    [Migration("20211221183039_InitialTikTokModels")]
    partial class InitialTikTokModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tiktok_v1")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarLarge");

                    b.Property<string>("AvatarMedium");

                    b.Property<string>("AvatarThumbnail");

                    b.Property<int>("CommentSetting");

                    b.Property<int>("DuetSetting");

                    b.Property<bool>("FTC");

                    b.Property<string>("Nickname");

                    b.Property<int>("OpenFavorite");

                    b.Property<bool>("PrivateAccount");

                    b.Property<int>("Relation");

                    b.Property<bool>("Secret");

                    b.Property<string>("SecurityUId");

                    b.Property<string>("Signature");

                    b.Property<int>("StitchSetting");

                    b.Property<string>("UniqueId");

                    b.Property<bool>("Verified");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.AuthorStats", b =>
                {
                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("ValidityStart");

                    b.Property<long>("DiggCount");

                    b.Property<DateTime>("EventDate");

                    b.Property<long>("FollowerCount");

                    b.Property<long>("FollowingCount");

                    b.Property<long>("Heart");

                    b.Property<long>("HeartCount");

                    b.Property<DateTime>("ValidityEnd");

                    b.Property<long>("VideoCount");

                    b.HasKey("AuthorId", "ValidityStart");

                    b.ToTable("AuthorStats");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Challenge", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverLarge");

                    b.Property<string>("CoverMedium");

                    b.Property<string>("CoverThumbnail");

                    b.Property<string>("Description");

                    b.Property<bool>("IsCommerce");

                    b.Property<string>("ProfileLarge");

                    b.Property<string>("ProfileMedium");

                    b.Property<string>("ProfileThumbnail");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.EffectSticker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EffectStickers");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Music", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Album");

                    b.Property<string>("AuthorName");

                    b.Property<string>("CoverLarge");

                    b.Property<string>("CoverMedium");

                    b.Property<string>("CoverThumb");

                    b.Property<int>("Duration");

                    b.Property<bool>("Original");

                    b.Property<string>("PlayUrl");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<List<string>>("ChallengeIds");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("Digged");

                    b.Property<int>("DuetDisplay");

                    b.Property<bool>("DuetEnabled");

                    b.Property<string>("DuetInfo");

                    b.Property<List<string>>("EffectStickerIds");

                    b.Property<bool>("ForFriend");

                    b.Property<bool>("IsAd");

                    b.Property<int>("ItemCommentStatus");

                    b.Property<bool>("ItemMute");

                    b.Property<string>("MusicId");

                    b.Property<bool>("OfficialItem");

                    b.Property<bool>("OriginalItem");

                    b.Property<bool>("Private");

                    b.Property<bool>("Secret");

                    b.Property<bool>("ShareEnabled");

                    b.Property<bool>("ShowNotPass");

                    b.Property<int>("StitchDisplay");

                    b.Property<bool>("StitchEnabled");

                    b.Property<List<string>>("TagIds");

                    b.Property<bool>("VL1");

                    b.Property<DateTime>("ValidityEnd");

                    b.Property<DateTime>("ValidityStart");

                    b.Property<string>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MusicId");

                    b.HasIndex("VideoId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.PostStats", b =>
                {
                    b.Property<string>("PostId");

                    b.Property<DateTime>("ValidityStart");

                    b.Property<long>("CommentCount");

                    b.Property<long>("DiggCount");

                    b.Property<DateTime>("EventDate");

                    b.Property<long>("PlayCount");

                    b.Property<long>("ShareCount");

                    b.Property<DateTime>("ValidityEnd");

                    b.HasKey("PostId", "ValidityStart");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Tag", b =>
                {
                    b.Property<string>("HashtagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AweMeId");

                    b.Property<int>("End");

                    b.Property<string>("HashtagName");

                    b.Property<bool>("IsCommerce");

                    b.Property<string>("SecureUId");

                    b.Property<int>("Start");

                    b.Property<int>("SubType");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.Property<string>("UserUniqueId");

                    b.HasKey("HashtagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Video", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BitRate");

                    b.Property<string>("CodecType");

                    b.Property<string>("Cover");

                    b.Property<string>("Definition");

                    b.Property<string>("DownloadAddress");

                    b.Property<int>("Duration");

                    b.Property<string>("DynamicCover");

                    b.Property<string>("EncodedType");

                    b.Property<string>("EncodedUserTag");

                    b.Property<string>("Format");

                    b.Property<int>("Height");

                    b.Property<string>("OriginCover");

                    b.Property<string>("PlayAddress");

                    b.Property<string>("Ratio");

                    b.Property<string>("ReflowCover");

                    b.Property<List<string>>("ShareCover");

                    b.Property<string>("VideoQuality");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.AuthorStats", b =>
                {
                    b.HasOne("DataLakeModels.Models.TikTok.Author", "Author")
                        .WithMany("Stats")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.Post", b =>
                {
                    b.HasOne("DataLakeModels.Models.TikTok.Author", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("DataLakeModels.Models.TikTok.Music", "Music")
                        .WithMany("Posts")
                        .HasForeignKey("MusicId");

                    b.HasOne("DataLakeModels.Models.TikTok.Video", "Video")
                        .WithMany("Posts")
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("DataLakeModels.Models.TikTok.PostStats", b =>
                {
                    b.HasOne("DataLakeModels.Models.TikTok.Post", "Post")
                        .WithMany("Stats")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

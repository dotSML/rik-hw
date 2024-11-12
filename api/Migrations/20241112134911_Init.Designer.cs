﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241112134911_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Event", b =>
                {
                    b.Property<Guid?>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("api.Domain.Models.Attendee", b =>
                {
                    b.Property<Guid?>("AttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("TEXT");

                    b.HasKey("AttendeeId");

                    b.HasIndex("EventId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("api.Domain.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("api.Infrastructure.Entities.AttendeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AttendeeType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EventEntityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventEntityId");

                    b.HasIndex("EventId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Attendees");

                    b.HasDiscriminator<string>("AttendeeType").HasValue("AttendeeEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("api.Infrastructure.Entities.EventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("api.Infrastructure.Entities.PaymentMethodEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("97a4e915-652d-47aa-aab5-441624365509"),
                            Method = "Bank transfer"
                        },
                        new
                        {
                            Id = new Guid("ca066759-b7d1-41af-8f95-980226cef322"),
                            Method = "Cash"
                        });
                });

            modelBuilder.Entity("api.Infrastructure.Entities.LegalEntityAttendeeEntity", b =>
                {
                    b.HasBaseType("api.Infrastructure.Entities.AttendeeEntity");

                    b.Property<int>("AttendeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyRegistrationCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParticipantRequests")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("LegalEntity");
                });

            modelBuilder.Entity("api.Infrastructure.Entities.NaturalPersonAttendeeEntity", b =>
                {
                    b.HasBaseType("api.Infrastructure.Entities.AttendeeEntity");

                    b.Property<string>("PersonalIdCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("NaturalPerson");
                });

            modelBuilder.Entity("api.Domain.Models.Attendee", b =>
                {
                    b.HasOne("Event", "Event")
                        .WithMany("Attendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Domain.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("api.Infrastructure.Entities.AttendeeEntity", b =>
                {
                    b.HasOne("api.Infrastructure.Entities.EventEntity", null)
                        .WithMany("Attendees")
                        .HasForeignKey("EventEntityId");

                    b.HasOne("Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Infrastructure.Entities.PaymentMethodEntity", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("Event", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("api.Infrastructure.Entities.EventEntity", b =>
                {
                    b.Navigation("Attendees");
                });
#pragma warning restore 612, 618
        }
    }
}

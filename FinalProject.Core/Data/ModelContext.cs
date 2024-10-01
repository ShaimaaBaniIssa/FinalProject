using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bankcard> Bankcards { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<Tripschedule> Tripschedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##Finalproject;Password=Test321;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##FINALPROJECT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Bankcard>(entity =>
            {
                entity.ToTable("BANKCARD");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardholdername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDERNAME");

                entity.Property(e => e.Cardnumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cardtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CARDTYPE");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Password).HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CUSTOMER");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ROLE");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("RESERVATION");

                entity.Property(e => e.Reservationid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RESERVATIONID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.RDate)
                    .HasColumnType("DATE")
                    .HasColumnName("R_DATE");

                entity.Property(e => e.Reservationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("RESERVATIONDATE");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Tripscheduleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIPSCHEDULEID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_RESERVATION_USER");

                entity.HasOne(d => d.Tripschedule)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Tripscheduleid)
                    .HasConstraintName("FK_RESERVATION_TRIPSCHEDULE");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("SEAT");

                entity.Property(e => e.Seatid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SEATID");

                entity.Property(e => e.Availability)
                    .HasPrecision(1)
                    .HasColumnName("AVAILABILITY");

                entity.Property(e => e.Seatnumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SEATNUMBER");

                entity.Property(e => e.Trainid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRAINID");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.Trainid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TRAIN_SEAT");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("STATION");

                entity.Property(e => e.Stationid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATIONID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Stationname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATIONNAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Commenttext)
                    .HasColumnType("CLOB")
                    .HasColumnName("COMMENTTEXT");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RATING");

                entity.Property(e => e.Stationid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATIONID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CUSTOMER_TESTIMONIAL");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Stationid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STATION_TESTIMONIAL");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKET");

                entity.Property(e => e.Ticketid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TICKETID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Nationalid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALID");

                entity.Property(e => e.Reservationid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESERVATIONID");

                entity.Property(e => e.Seatid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEATID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Reservationid)
                    .HasConstraintName("FK_TICKET_RESERVATION");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Seatid)
                    .HasConstraintName("FK_TICKET_SEAT");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("TRAIN");

                entity.Property(e => e.Trainid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRAINID");

                entity.Property(e => e.Availability)
                    .HasPrecision(1)
                    .HasColumnName("AVAILABILITY");

                entity.Property(e => e.Numofseats)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMOFSEATS");

                entity.Property(e => e.Trainname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRAINNAME");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIP");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Destlatitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DESTLATITUDE");

                entity.Property(e => e.Destlongitude)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DESTLONGITUDE");

                entity.Property(e => e.Friday)
                    .HasPrecision(1)
                    .HasColumnName("FRIDAY");

                entity.Property(e => e.Monday)
                    .HasPrecision(1)
                    .HasColumnName("MONDAY");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Saturday)
                    .HasPrecision(1)
                    .HasColumnName("SATURDAY");

                entity.Property(e => e.Stationid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATIONID");

                entity.Property(e => e.Sunday)
                    .HasPrecision(1)
                    .HasColumnName("SUNDAY");

                entity.Property(e => e.Thursday)
                    .HasPrecision(1)
                    .HasColumnName("THURSDAY");

                entity.Property(e => e.Tuesday)
                    .HasPrecision(1)
                    .HasColumnName("TUESDAY");

                entity.Property(e => e.Wednesday)
                    .HasPrecision(1)
                    .HasColumnName("WEDNESDAY");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Stationid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STATION");
            });

            modelBuilder.Entity<Tripschedule>(entity =>
            {
                entity.ToTable("TRIPSCHEDULE");

                entity.Property(e => e.Tripscheduleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIPSCHEDULEID");

                entity.Property(e => e.Arrivaltime)
                    .HasPrecision(6)
                    .HasColumnName("ARRIVALTIME");

                entity.Property(e => e.Departuretime)
                    .HasPrecision(6)
                    .HasColumnName("DEPARTURETIME");

                entity.Property(e => e.Trainid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRAINID");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIPID");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Tripschedules)
                    .HasForeignKey(d => d.Trainid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRAIN");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Tripschedules)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TRIP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

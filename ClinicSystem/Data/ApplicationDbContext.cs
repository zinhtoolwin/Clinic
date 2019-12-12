using System;
using System.Collections.Generic;
using System.Text;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VitalSign>()
                  .HasOne<Patient>(v => v.Patient)
                  .WithMany(p => p.VitalSigns)
                  .HasForeignKey(s => s.PatientId);

            builder.Entity<Doctor>()
                .HasOne<Speciality>(s => s.Speciality)
                .WithMany(p => p.Doctors)
                .HasForeignKey(g => g.SpecialityID);

            builder.Entity<Schedule>()
                .HasOne<Doctor>(d => d.Doctor)
                .WithMany(m => m.Schedules)
                .HasForeignKey(s => s.DoctorId);


            //appointment
            builder.Entity<Appointment>()
                .HasOne<Patient>(a => a.Patient)
                .WithMany(b => b.Appointments)
                .HasForeignKey(c => c.PatientId);

            builder.Entity<Appointment>()
                .HasOne<Schedule>(a => a.Schedule)
                .WithMany(b => b.Appointments)
                .HasForeignKey(v => v.ScheduleId);
               





            base.OnModelCreating(builder);

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}

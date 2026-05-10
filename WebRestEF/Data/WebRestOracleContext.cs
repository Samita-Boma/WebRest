using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Models;

namespace WebRest.EF.Data;

public partial class WebRestOracleContext : DbContext
{
    public WebRestOracleContext(DbContextOptions<WebRestOracleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<Course> Course { get; set; }

    public virtual DbSet<Employer> Employer { get; set; }

    public virtual DbSet<Enrollment> Enrollment { get; set; }

    public virtual DbSet<Grade> Grade { get; set; }

    public virtual DbSet<GradeConversion> GradeConversion { get; set; }

    public virtual DbSet<GradeType> GradeType { get; set; }

    public virtual DbSet<GradeTypeWeight> GradeTypeWeight { get; set; }

    public virtual DbSet<Instructor> Instructor { get; set; }

    public virtual DbSet<InstructorAddress> InstructorAddress { get; set; }

    public virtual DbSet<Location> Location { get; set; }

    public virtual DbSet<Section> Section { get; set; }

    public virtual DbSet<SectionLocation> SectionLocation { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    public virtual DbSet<StudentAddress> StudentAddress { get; set; }

    public virtual DbSet<StudentEmployer> StudentEmployer { get; set; }

    public virtual DbSet<Zipcode> Zipcode { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UD_SAMIBOMA")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressGuid).HasName("ADDRESS_PK");

            entity.Property(e => e.AddressGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.St).IsFixedLength();

            entity.HasOne(d => d.Zipcode).WithMany(p => p.Address)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ADDRESS_FK1");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseGuid).HasName("COURSE_PK");

            entity.ToTable("COURSE", tb => tb.HasComment("Information for a course."));

            entity.Property(e => e.CourseGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYS_GUID()");
            entity.Property(e => e.Cost).HasComment("The dollar amount charged for enrollment in this course.");
            entity.Property(e => e.CourseNo).HasComment("The unique ID for a course.");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.Description).HasComment("The full name for this course.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");

            entity.HasOne(d => d.Prerequisite).WithMany(p => p.InversePrerequisite).HasConstraintName("COURSE_FK1");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerGuid).HasName("EMPLOYER_PK");

            entity.Property(e => e.EmployerGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentGuid).HasName("ENROLLMENT_PK");

            entity.ToTable("ENROLLMENT", tb => tb.HasComment("Information for a student registered for a particular section (class)."));

            entity.Property(e => e.EnrollmentGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYS_GUID()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.EnrollDate).HasComment("The date this student registered for this section.");
            entity.Property(e => e.FinalGrade).HasComment("The final grade given to this student for all work in this section (class).");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");

            entity.HasOne(d => d.Section).WithMany(p => p.Enrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_FK1");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_FK2");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeGuid).HasName("GRADE_PK");

            entity.ToTable("GRADE", tb => tb.HasComment("The individual grades a student received for a particular section(class)."));

            entity.Property(e => e.GradeGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.Comments).HasComment("Instructor's comments on this grade.");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.GradeCodeOccurrence).HasComment("The sequence number of one grade type for one section. For example, there could be multiple assignments numbered 1, 2, 3, etc.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.NumericGrade)
                .HasDefaultValueSql("0")
                .HasComment("Numeric grade value, (e.g. 70, 75.)");

            entity.HasOne(d => d.GradeType).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK1");

            entity.HasOne(d => d.Section).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK2");

            entity.HasOne(d => d.Student).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK3");
        });

        modelBuilder.Entity<GradeConversion>(entity =>
        {
            entity.HasKey(e => e.GradeConversionGuid).HasName("GRADE_CONVERSION_PK");

            entity.ToTable("GRADE_CONVERSION", tb => tb.HasComment("Converts a number grade to a letter grade."));

            entity.Property(e => e.GradeConversionGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.GradePoint)
                .HasDefaultValueSql("0")
                .HasComment("The number grade on a scale from 0 (F) to 4 (A).");
            entity.Property(e => e.LetterGrade).HasComment("The unique grade as a letter (A, A-, B, B+, etc.).");
            entity.Property(e => e.MaxGrade).HasComment("The highest grade number which makes this letter grade.");
            entity.Property(e => e.MinGrade).HasComment("The lowest grade number which makes this letter grade.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
        });

        modelBuilder.Entity<GradeType>(entity =>
        {
            entity.HasKey(e => e.GradeTypeGuid).HasName("GRADE_TYPE_PK");

            entity.ToTable("GRADE_TYPE", tb => tb.HasComment("Lookup table of a grade types (code) and its description."));

            entity.Property(e => e.GradeTypeGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.Description).HasComment("The description for this code, i.e. Midterm, Homework.");
            entity.Property(e => e.GradeTypeCode)
                .IsFixedLength()
                .HasComment("The unique code which identifies a category of grade, i.e. MT, HW.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
        });

        modelBuilder.Entity<GradeTypeWeight>(entity =>
        {
            entity.HasKey(e => e.GradeTypeWeightGuid).HasName("GRADE_TYPE_WEIGHT_PK");

            entity.ToTable("GRADE_TYPE_WEIGHT", tb => tb.HasComment("Information on how the final grade for a particular section is computed.  For example, the midterm constitutes 50%, the quiz 10% and the final examination 40% of the final grade."));

            entity.Property(e => e.GradeTypeWeightGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.DropLowest)
                .IsFixedLength()
                .HasComment("Is the lowest grade in this type removed when determining the final grade? (Y/N)");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.NumberPerSection).HasComment("How many of these grade types can be used in this section.  That is, there may be 3 quizzes.");
            entity.Property(e => e.PercentOfFinalGrade).HasComment("The percentage this category of grade contributes to the final grade.");

            entity.HasOne(d => d.GradeType).WithMany(p => p.GradeTypeWeight)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_TYPE_WEIGHT_FK2");

            entity.HasOne(d => d.Section).WithMany(p => p.GradeTypeWeight)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_TYPE_WEIGHT_FK1");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorGuid).HasName("INSTRUCTOR_PK");

            entity.ToTable("INSTRUCTOR", tb => tb.HasComment("Profile information for an instructor."));

            entity.Property(e => e.InstructorGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.FirstName).HasComment("This instructor's first name.");
            entity.Property(e => e.LastName).HasComment("This instructor's last name");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.Phone).HasComment("The phone number for this instructor including area code.");
            entity.Property(e => e.Salutation).HasComment("This instructor's title (Mr., Ms., Dr., Rev., etc.)");
            entity.Property(e => e.StreetAddress).HasComment("This Instructor's street address.");

            entity.HasOne(d => d.Zipcode).WithMany(p => p.Instructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INSTRUCTOR_FK1");
        });

        modelBuilder.Entity<InstructorAddress>(entity =>
        {
            entity.HasKey(e => e.InstructorAddressGuid).HasName("INSTRUCTOR_ADDRESS_PK");

            entity.Property(e => e.InstructorAddressGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.AddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Address).WithMany(p => p.InstructorAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INSTRUCTOR_ADDRESS_FK2");

            entity.HasOne(d => d.Instructor).WithMany(p => p.InstructorAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INSTRUCTOR_ADDRESS_FK1");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationGuid).HasName("LOCATION_PK");

            entity.Property(e => e.LocationGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionGuid).HasName("SECTION_PK");

            entity.ToTable("SECTION", tb => tb.HasComment("Information for an individual section (class) of a particular course."));

            entity.Property(e => e.SectionGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYS_GUID()");
            entity.Property(e => e.Capacity).HasComment("The maximum number of students allowed in this section.");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.InstructorGuid).HasComment("The ID number of the instructor who teaches this section.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.SectionNo).HasComment("The individual section number within this course.");
            entity.Property(e => e.StartDateTime).HasComment("The date and time on which this section meets.");

            entity.HasOne(d => d.Course).WithMany(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_FK1");
        });

        modelBuilder.Entity<SectionLocation>(entity =>
        {
            entity.HasKey(e => e.SectionLocationGuid).HasName("SECTION_LOCATION_PK");

            entity.Property(e => e.SectionLocationGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Location).WithMany(p => p.SectionLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_LOCATION_FK2");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_LOCATION_FK1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentGuid).HasName("STUDENT_PK");

            entity.ToTable("STUDENT", tb => tb.HasComment("Profile information for a student."));

            entity.Property(e => e.StudentGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYS_GUID()");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.FirstName).HasComment("This student's first name.");
            entity.Property(e => e.LastName).HasComment("This student's last name.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.Phone).HasComment("The phone number for this student including area code.");
            entity.Property(e => e.RegistrationDate).HasComment("The date this student registered in the program.");
            entity.Property(e => e.Salutation).HasComment("The student's title (Ms., Mr., Dr., etc.).");
            entity.Property(e => e.StreetAddress).HasComment("The student's street address.");
            entity.Property(e => e.ZipcodeGuid).HasComment("The postal zip code for this student.");

            entity.HasOne(d => d.Zipcode).WithMany(p => p.Student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_FK1");
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.StudentAddressGuid).HasName("STUDENT_ADDRESS_PK");

            entity.Property(e => e.StudentAddressGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid()");
            entity.Property(e => e.AddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Address).WithMany(p => p.StudentAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_ADDRESS_FK1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_ADDRESS_FK2");
        });

        modelBuilder.Entity<StudentEmployer>(entity =>
        {
            entity.HasKey(e => e.StudentEmployerGuid).HasName("STUDENT_EMPLOYER_PK");

            entity.Property(e => e.StudentEmployerGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employer).WithMany(p => p.StudentEmployer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_EMPLOYER_FK1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentEmployer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_EMPLOYER_FK2");
        });

        modelBuilder.Entity<Zipcode>(entity =>
        {
            entity.HasKey(e => e.ZipcodeGuid).HasName("ZIPCODE_PK");

            entity.ToTable("ZIPCODE", tb => tb.HasComment("City, state and zip code information."));

            entity.Property(e => e.ZipcodeGuid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYS_GUID()\n   ");
            entity.Property(e => e.City).HasComment("The city name for this zip code.");
            entity.Property(e => e.CreatedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates user who inserted data.");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates date of insert.");
            entity.Property(e => e.ModifiedBy)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - indicates who made last update.");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAdd()
                .HasComment("Audit column - date of last update.");
            entity.Property(e => e.State).HasComment("The postal abbreviation for the US state.");
            entity.Property(e => e.Zip).HasComment("The zip code number, unique for a city and state.");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

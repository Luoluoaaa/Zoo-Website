using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEnd.Model;

#nullable disable

namespace BackEnd.Data
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

        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<AdmissionTicket> AdmissionTickets { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalEnclosure> AnimalEnclosures { get; set; }
        public virtual DbSet<AnimalShow> AnimalShows { get; set; }
        public virtual DbSet<AnimalTrain> AnimalTrains { get; set; }
        public virtual DbSet<AreaManagement> AreaManagements { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Birth> Births { get; set; }
        public virtual DbSet<ConsumptionItem> ConsumptionItems { get; set; }
        public virtual DbSet<CureInformation> CureInformations { get; set; }
        public virtual DbSet<DailyOpen> DailyOpens { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DisplayArea> DisplayAreas { get; set; }
        public virtual DbSet<DisplayAreaLog> DisplayAreaLogs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<FunctionalDisplayArea> FunctionalDisplayAreas { get; set; }
        public virtual DbSet<FundAccount> FundAccounts { get; set; }
        public virtual DbSet<GettingAroundZoo> GettingAroundZoos { get; set; }
        public virtual DbSet<GettingHere> GettingHeres { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodStore> GoodStores { get; set; }
        public virtual DbSet<OpeningTime> OpeningTimes { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Procurement> Procurements { get; set; }
        public virtual DbSet<ProcurementGood> ProcurementGoods { get; set; }
        public virtual DbSet<PublicService> PublicServices { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<SciencePopularization> SciencePopularizations { get; set; }
        public virtual DbSet<ShowFunctionalDisplayArea> ShowFunctionalDisplayAreas { get; set; }
        public virtual DbSet<ShowInformation> ShowInformations { get; set; }
        public virtual DbSet<ShowTicket> ShowTickets { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<SystemFeedback> SystemFeedbacks { get; set; }
        public virtual DbSet<TicketTtye> TicketTtyes { get; set; }
        public virtual DbSet<TourAccom> TourAccoms { get; set; }
        public virtual DbSet<TourAround> TourArounds { get; set; }
        public virtual DbSet<TourGuide> TourGuides { get; set; }
        public virtual DbSet<TourHere> TourHeres { get; set; }
        public virtual DbSet<TourProj> TourProjs { get; set; }
        public virtual DbSet<TourSciPop> TourSciPops { get; set; }
        public virtual DbSet<TourShowTicket> TourShowTickets { get; set; }
        public virtual DbSet<TourTicket> TourTickets { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<TouristGuide> TouristGuides { get; set; }
        public virtual DbSet<TrainDispalyArea> TrainDispalyAreas { get; set; }
        public virtual DbSet<TrainInformation> TrainInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("USER ID=SYSTEM;password=SJKyszh2021;DATA SOURCE=47.118.78.110:1521/orcl;PERSIST SECURITY INFO=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("ACCOMMODATION_PK");

                entity.ToTable("ACCOMMODATION");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Mark)
                    .HasPrecision(2)
                    .HasColumnName("MARK");

                entity.Property(e => e.PhoneNumeric)
                    .HasPrecision(11)
                    .HasColumnName("PHONE_NUMERIC");

                entity.Property(e => e.Price)
                    .HasPrecision(5)
                    .HasColumnName("PRICE");
            });

            modelBuilder.Entity<AdmissionTicket>(entity =>
            {
                entity.ToTable("ADMISSION_TICKET");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("DATE")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.EnteringDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERING_DATE");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.StartTime)
                    .HasColumnType("DATE")
                    .HasColumnName("START_TIME");

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_TYPE");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("ANIMAL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .HasPrecision(4)
                    .HasColumnName("AGE");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.BodyLength)
                    .HasPrecision(3)
                    .HasColumnName("BODY_LENGTH");

                entity.Property(e => e.BreedSituation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BREED_SITUATION");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("BLOB")
                    .HasColumnName("PHOTO");

                entity.Property(e => e.PhysicalCondition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHYSICAL_CONDITION");

                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SPECIES");

                entity.Property(e => e.Weight)
                    .HasPrecision(5)
                    .HasColumnName("WEIGHT");
            });

            

            modelBuilder.Entity<AnimalEnclosure>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("ANIMAL_ENCLOSURE_PK");

                entity.ToTable("ANIMAL_ENCLOSURE");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");

                entity.Property(e => e.AnimalCapacity)
                    .HasPrecision(5)
                    .HasColumnName("ANIMAL_CAPACITY");

                entity.Property(e => e.CurrentHumidit)
                    .HasPrecision(5)
                    .HasColumnName("CURRENT_HUMIDIT");

                entity.Property(e => e.CurrentSound)
                    .HasPrecision(4)
                    .HasColumnName("CURRENT_SOUND");

                entity.Property(e => e.CurrentTemp)
                    .HasPrecision(3)
                    .HasColumnName("CURRENT_TEMP");

                entity.Property(e => e.SecuirtyLevel)
                    .HasPrecision(2)
                    .HasColumnName("SECUIRTY_LEVEL");

                entity.Property(e => e.VisitMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VISIT_MODE");
            });

            

            modelBuilder.Entity<AnimalShow>(entity =>
            {
                entity.HasKey(e => new { e.ShowId, e.AnimalId })
                    .HasName("ANIMAL_SHOW_PK");

                entity.ToTable("ANIMAL_SHOW");

                entity.Property(e => e.ShowId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_ID");

                entity.Property(e => e.AnimalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");
            });

            modelBuilder.Entity<AnimalTrain>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.TrainTime })
                    .HasName("ANIMAL_TRAIN_PK");

                entity.ToTable("ANIMAL_TRAIN");

                entity.Property(e => e.AnimalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.TrainTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAIN_TIME");
            });



            modelBuilder.Entity<AreaManagement>(entity =>
            {
                entity.HasKey(e => new { e.StaffId, e.AreaId })
                    .HasName("AREA_MANAGEMENT_PK");

                entity.ToTable("AREA_MANAGEMENT");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STAFF_ID");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");

                entity.Property(e => e.ManageWorkType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MANAGE_WORK_TYPE");
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ManagerId, e.AssessmentTime })
                    .HasName("ASSESSMENT_PK");

                entity.ToTable("ASSESSMENT");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MANAGER_ID");

                entity.Property(e => e.AssessmentTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_TIME");

                entity.Property(e => e.AssessmentGrade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_GRADE");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssessmentEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSESSMENT_FK1");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.AssessmentManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSESSMENT_FK2");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.BankAccId)
                    .HasName("BANK_ACCOUNT_PK");

                entity.ToTable("BANK_ACCOUNT");

                entity.Property(e => e.BankAccId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ACC_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STAFF_ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Birth>(entity =>
            {
                entity.ToTable("BIRTH");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ChildrenNum)
                    .HasPrecision(3)
                    .HasColumnName("CHILDREN_NUM");

                entity.Property(e => e.Success)
                    .HasPrecision(1)
                    .HasColumnName("SUCCESS");

                entity.Property(e => e.Time)
                    .HasColumnType("DATE")
                    .HasColumnName("TIME");
            });

            modelBuilder.Entity<ConsumptionItem>(entity =>
            {
                entity.ToTable("CONSUMPTION_ITEMS");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.EventContect)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_CONTECT");

                entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_LOCATION");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_NAME");

                entity.Property(e => e.EventPrice)
                    .HasPrecision(5)
                    .HasColumnName("EVENT_PRICE");
            });

            modelBuilder.Entity<CureInformation>(entity =>
            {
                entity.HasKey(e => e.CureId)
                    .HasName("CURE_INFORMATION_PK");

                entity.ToTable("CURE_INFORMATION");

                entity.Property(e => e.CureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CURE_ID");

                entity.Property(e => e.AnimalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.DateCure)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_CURE");

                entity.Property(e => e.DateIll)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_ILL");

                entity.Property(e => e.DiseaseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISEASE_NAME");

                entity.Property(e => e.Drug)
                    //.IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DRUG");

                entity.Property(e => e.IsCured)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IS_CURED");

                entity.Property(e => e.VeterinaryId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VETERINARY_ID");

                entity.HasOne(d => d.animal)
                    .WithOne(p => p.CureInformation)
                    .HasForeignKey<CureInformation>(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CURE_INFORMATION_FK1");

                entity.HasOne(d => d.Veterinary)
                    .WithMany(p => p.CureInformations)
                    .HasForeignKey(d => d.VeterinaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CURE_INFORMATION_FK2");
            });

            modelBuilder.Entity<DailyOpen>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("DAILY_OPEN_PK");

                entity.ToTable("DAILY_OPEN");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");

                entity.Property(e => e.CloseTime)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSE_TIME");

                entity.Property(e => e.Day)
                    .HasPrecision(1)
                    .HasColumnName("DAY");

                entity.Property(e => e.OpenTime)
                    .HasColumnType("DATE")
                    .HasColumnName("OPEN_TIME");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.Time, e.EmployeeId })
                    .HasName("DELIVERY_PK");

                entity.ToTable("DELIVERY");

                entity.Property(e => e.AnimalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.Time)
                    .HasColumnType("DATE")
                    .HasColumnName("TIME");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_ID");
            });

            modelBuilder.Entity<DisplayArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("DISPLAY_AREA_PK");

                entity.ToTable("DISPLAY_AREA");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");

                entity.Property(e => e.AdditionalFee)
                    .HasPrecision(5)
                    .HasColumnName("ADDITIONAL_FEE");

                entity.Property(e => e.Introduction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INTRODUCTION");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.TouristCapacity)
                    .HasPrecision(5)
                    .HasColumnName("TOURIST_CAPACITY");

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ZONE");
            });

            modelBuilder.Entity<DisplayAreaLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("DISPLAY_AREA_LOG_PK");

                entity.ToTable("DISPLAY_AREA_LOG");

                entity.Property(e => e.LogId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOG_ID");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DETAIL");

                /*entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");*/

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(1)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .HasPrecision(4)
                    .HasColumnName("AGE");

                entity.Property(e => e.EmploymentYear)
                    .HasColumnType("DATE")
                    .HasColumnName("EMPLOYMENT_YEAR");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Park)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARK");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSITION");

                entity.Property(e => e.Wage)
                    .HasPrecision(10)
                    .HasColumnName("WAGE");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("FEED_PK");

                entity.ToTable("FEED");

                entity.Property(e => e.AnimalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.Day)
                    .HasColumnType("DATE")
                    .HasColumnName("DAY");

                entity.Property(e => e.FoodId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOD_ID");

                entity.Property(e => e.KeeperId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KEEPER_ID");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");
            });

            

            modelBuilder.Entity<FunctionalDisplayArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("FUNCTIONAL_DISPLAY_AREA_PK");

                entity.ToTable("FUNCTIONAL_DISPLAY_AREA");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");

                entity.Property(e => e.FunctionInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTION_INFO");
            });

            modelBuilder.Entity<FundAccount>(entity =>
            {
                entity.HasKey(e => e.FundAccId)
                    .HasName("TABLE1_PK");

                entity.ToTable("FUND_ACCOUNT");

                entity.Property(e => e.FundAccId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FUND_ACC_ID");

                entity.Property(e => e.Amount)
                    .HasPrecision(5)
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.BankAccId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ACC_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STAFF_ID");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSACTION_TIME");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.StaffIDNavigation)
                    .WithMany(p => p.FundAccounts)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSESSMENT_FK1");

                entity.HasOne(d => d.BankAccIdNavigation)
                    .WithMany(p => p.FundAccounts)
                    .HasForeignKey(d => d.BankAccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSESSMENT_FK2");
            });

            modelBuilder.Entity<GettingAroundZoo>(entity =>
            {
                entity.ToTable("GETTING_AROUND_ZOO");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.date)
                    .HasColumnType("DATE")
                    .HasColumnName("T_DATE");

                entity.Property(e => e.Price)
                    .HasPrecision(5)
                    .HasColumnName("PRICE");


                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_TYPE");

                entity.Property(e => e.TourId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.VehicleCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEHICLE_CATEGORY");

            });

            modelBuilder.Entity<GettingAroundZooType>(entity =>
            {
                entity.HasKey(e => new { e.TicketType, e.VehicleCategory })
                   .HasName("GETTING_AROUND_ZOO_PK");

                entity.ToTable("GETTING_AROUND_ZOO_TYPE");



                entity.Property(e => e.AgeLimit)
                    .HasPrecision(4)
                    .HasColumnName("AGE_LIMIT");

                entity.Property(e => e.Deposit)
                    .HasPrecision(5)
                    .HasColumnName("DEPOSIT");

                entity.Property(e => e.Price)
                    .HasPrecision(5)
                    .HasColumnName("PRICE");

                entity.Property(e => e.RentalDuration)
                    .HasPrecision(3)
                    .HasColumnName("RENTAL_DURATION");

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_TYPE");

                entity.Property(e => e.VehicleCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEHICLE_CATEGORY");

                entity.Property(e => e.WeightLimit)
                    .HasPrecision(3)
                    .HasColumnName("WEIGHT_LIMIT");
            });

            modelBuilder.Entity<GettingHere>(entity =>
            {
                entity.ToTable("GETTING_HERE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.BoardingLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BOARDING_LOCATION");

                entity.Property(e => e.DepartureInterval)
                    .HasPrecision(5)
                    .HasColumnName("DEPARTURE_INTERVAL");

                entity.Property(e => e.Price)
                    .HasPrecision(5)
                    .HasColumnName("PRICE");

                entity.Property(e => e.TransDuration)
                    .HasPrecision(3)
                    .HasColumnName("TRANS_DURATION");

                entity.Property(e => e.VehicleCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEHICLE_CATEGORY");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("GOODS_PK");

                entity.ToTable("GOODS");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_ID");

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHANNEL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasPrecision(5)
                    .HasColumnName("PRICE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STAFF_ID");

                entity.Property(e => e.StoreCondition)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STORE_CONDITION");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TARGET");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UsageMethod)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USAGE_METHOD");
            });

            modelBuilder.Entity<GoodStore>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ItemId })
                    .HasName("GOOD_STORE_PK");

                entity.ToTable("GOOD_STORE");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STORE_ID");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_ID");

                entity.Property(e => e.ItemCounts)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ITEM_COUNTS");
            });

            modelBuilder.Entity<OpeningTime>(entity =>
            {
                entity.HasKey(e => e.Day)
                    .HasName("OPENING_TIME_PK");

                entity.ToTable("OPENING_TIME");

                entity.Property(e => e.Day)
                    .HasPrecision(1)
                    .HasColumnName("DAY");

                entity.Property(e => e.CloseTime)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSE_TIME");

                entity.Property(e => e.OpenTime)
                    .HasColumnType("DATE")
                    .HasColumnName("OPEN_TIME");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => new { e.MomId, e.ChildId })
                    .HasName("PARENT_PK");

                entity.ToTable("PARENT");

                entity.Property(e => e.MomId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOM_ID");

                entity.Property(e => e.ChildId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHILD_ID");
            });

            modelBuilder.Entity<Procurement>(entity =>
            {
                entity.HasKey(e => e.ProcureId)
                    .HasName("PROCUREMENT_PK");

                entity.ToTable("PROCUREMENT");

                entity.Property(e => e.ProcureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROCURE_ID");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.ProcureDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PROCURE_DATE");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STAFF_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ProcurementGood>(entity =>
            {
                entity.HasKey(e => new { e.ProcureId, e.ItemId })
                    .HasName("PROCUREMENT_GOODS_PK");
                
                entity.ToTable("PROCUREMENT_GOODS");

                entity.Property(e => e.ProcureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROCURE_ID");

                entity.Property(e => e.ItemCount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ITEM_COUNT");

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_ID");
            });


            modelBuilder.Entity<PublicService>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PUBLIC_SERVICE_PK");

                entity.ToTable("PUBLIC_SERVICE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Intro)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("INTRO");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("RECIPE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.FoodList1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOD_LIST1");

                entity.Property(e => e.FoodList2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOD_LIST2");

                entity.Property(e => e.FoodList3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOD_LIST3");

                entity.Property(e => e.FoodList4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOD_LIST4");

                entity.Property(e => e.FoodWeight1)
                    .HasPrecision(5)
                    .HasColumnName("FOOD_WEIGHT1");

                entity.Property(e => e.FoodWeight2)
                    .HasPrecision(5)
                    .HasColumnName("FOOD_WEIGHT2");

                entity.Property(e => e.FoodWeight3)
                    .HasPrecision(5)
                    .HasColumnName("FOOD_WEIGHT3");

                entity.Property(e => e.FoodWeight4)
                    .HasPrecision(5)
                    .HasColumnName("FOOD_WEIGHT4");

                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SPECIES");
            });

           


            modelBuilder.Entity<SciencePopularization>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("SCIENCE_POPULARIZATION_PK");

                entity.ToTable("SCIENCE_POPULARIZATION");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
                /*
                entity.Property(e => e.AverageHeight)
                    .HasPrecision(3)
                    .HasColumnName("AVERAGE_HEIGHT");

                entity.Property(e => e.AverageWeight)
                    .HasPrecision(4)
                    .HasColumnName("AVERAGE_WEIGHT");

                entity.Property(e => e.FavoriteFood)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAVORITE_FOOD");

                entity.Property(e => e.Habitat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HABITAT");

                entity.Property(e => e.ReproductionPattern)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPRODUCTION_PATTERN");

                entity.Property(e => e.SleepingDuration)
                    .HasColumnType("DATE")
                    .HasColumnName("SLEEPING_DURATION");
                */
                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SPECIES");
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");
                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnType("BLOB")
                    .HasColumnName("IMG");
            });

            modelBuilder.Entity<ShowFunctionalDisplayArea>(entity =>
            {
                entity.HasKey(e => new { e.ShowId, e.AreaId })
                    .HasName("SHOW_FUNCTIONAL_DISPLAY_AREA_PK");

                entity.ToTable("SHOW_FUNCTIONAL_DISPLAY_AREA");

                entity.Property(e => e.ShowId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_ID");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");
            });

            modelBuilder.Entity<ShowInformation>(entity =>
            {
                entity.HasKey(e => e.ShowId)
                    .HasName("SHOW_INFORMATION_PK");

                entity.ToTable("SHOW_INFORMATION");

                entity.Property(e => e.ShowId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_ID");

                

                entity.Property(e => e.EndTime)
                    .HasColumnType("DATE")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.PrincipalName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRINCIPAL_NAME");

                entity.Property(e => e.ShowDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SHOW_DATE");

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_NAME");

                entity.Property(e => e.ShowProps)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_PROPS");

                entity.Property(e => e.ShowSite)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_SITE");

                entity.Property(e => e.StartTime)
                    .HasColumnType("DATE")
                    .HasColumnName("START_TIME");

                entity.HasOne(d => d.PrincipalNameNavigation)
                    .WithMany(p => p.ShowInformations)
                    .HasForeignKey(d => d.PrincipalName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SHOW_INFORMATION_FK2");
            });

            

            modelBuilder.Entity<ShowTicket>(entity =>
            {
                entity.ToTable("SHOW_TICKET");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHOW_ID");

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_TYPE");

                entity.Property(e => e.Tourid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOURID");
            });


            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("STORE");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STORE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");
            });

            modelBuilder.Entity<SystemFeedback>(entity =>
            {
                entity.ToTable("SYSTEM_FEEDBACK");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.FeedbackContent)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FEEDBACK_CONTENT");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.TourId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            

            modelBuilder.Entity<TicketTtye>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Type })
                    .HasName("TICKET_TTYE_PK");

                entity.ToTable("TICKET_TTYE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRICE");
            });

            modelBuilder.Entity<TourAccom>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.HotelName })
                    .HasName("TOUR_ACCOM_PK");

                entity.ToTable("TOUR_ACCOM");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOTEL_NAME");

                entity.HasOne(d => d.HotelNameNavigation)
                    .WithMany(p => p.TourAccoms)
                    .HasForeignKey(d => d.HotelName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_ACCOM_FK2");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourAccoms)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_ACCOM_FK1");
            });

            modelBuilder.Entity<TourAround>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.OrderId })
                    .HasName("TOUR_AROUND_PK");

                entity.ToTable("TOUR_AROUND");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_ID");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TourArounds)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_AROUND_FK1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TourArounds)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_AROUND_FK2");
            });

            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.OrderNumber })
                    .HasName("TOUR_GUIDE_PK");

                entity.ToTable("TOUR_GUIDE");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NUMBER");

                entity.HasOne(d => d.OrderNumberNavigation)
                    .WithMany(p => p.TourGuides)
                    .HasForeignKey(d => d.OrderNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_GUIDE_FK2");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourGuides)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_GUIDE_FK1");
            });

            modelBuilder.Entity<TourHere>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.VehicleId })
                    .HasName("TOUR_HERE_PK");

                entity.ToTable("TOUR_HERE");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.VehicleId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEHICLE_ID");

                entity.Property(e => e.VehicleCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEHICLE_CATEGORY");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourHeres)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_HERE_FK1");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.TourHeres)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_HERE_FK2");
            });

            modelBuilder.Entity<TourProj>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.ProjectId })
                    .HasName("TOUR_PROJ_PK");

                entity.ToTable("TOUR_PROJ");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.ProjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB");

                entity.Property(e => e.ParticipationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PARTICIPATION_DATE");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TourProjs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_PROJ_FK2");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourProjs)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_PROJ_FK1");
            });

            modelBuilder.Entity<TourSciPop>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.AnimalCategory })
                    .HasName("TOUR_SCI_POP_PK");

                entity.ToTable("TOUR_SCI_POP");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.AnimalCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_CATEGORY");

                entity.HasOne(d => d.AnimalCategoryNavigation)
                    .WithMany(p => p.TourSciPops)
                    .HasForeignKey(d => d.AnimalCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_SCI_POP_FK2");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourSciPops)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_SCI_POP_FK1");
            });

            modelBuilder.Entity<TourShowTicket>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.TourId })
                    .HasName("TOUR_SHOW_TICKET_PK");

                entity.ToTable("TOUR_SHOW_TICKET");

                entity.Property(e => e.TicketId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_ID");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TourShowTickets)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_SHOW_TICKET_FK1");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourShowTickets)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_SHOW_TICKET_FK2");
            });

            modelBuilder.Entity<TourTicket>(entity =>
            {
                entity.HasKey(e => new { e.TourId, e.TicketId })
                    .HasName("TOUR_TICKET_PK");

                entity.ToTable("TOUR_TICKET");

                entity.Property(e => e.TourId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");

                entity.Property(e => e.TicketId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TICKET_ID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TourTickets)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_TICKET_FK2");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourTickets)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOUR_TICKET_FK1");
            });

            modelBuilder.Entity<Tourist>(entity =>
            {
                entity.ToTable("TOURIST");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .HasPrecision(4)
                    .HasColumnName("AGE");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Mailbox)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MAILBOX");

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NICK_NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.RealName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REAL_NAME");

                entity.Property(e => e.IDcard)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDCARD");
            });

            modelBuilder.Entity<TouristGuide>(entity =>
            {
                entity.ToTable("TOURIST_GUIDE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.GuideId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GUIDE_ID");

                entity.Property(e => e.Type)
                    .HasPrecision(2)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasPrecision(4)
                    .HasColumnName("PRICE");

                entity.Property(e => e.TourId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOUR_ID");
            });

            modelBuilder.Entity<TrainDispalyArea>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.TrainTime, e.AreaId })
                    .HasName("TRAIN_DISPALY_AREA_PK");

                entity.ToTable("TRAIN_DISPALY_AREA");

                entity.Property(e => e.AnimalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.TrainTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAIN_TIME");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREA_ID");
            });

            modelBuilder.Entity<TrainInformation>(entity =>
            {
                entity.ToTable("TRAIN_INFORMATION");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.AnimalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANIMAL_ID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("DATE")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.Props)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROPS");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILL");

                entity.Property(e => e.StartTime)
                    .HasColumnType("DATE")
                    .HasColumnName("START_TIME");

                entity.Property(e => e.TrainDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRAIN_DATE");

                entity.Property(e => e.TrainSite)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAIN_SITE");

                entity.Property(e => e.TrainerId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAINER_ID");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainInformations)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRAIN_INFORMATION_FK1");
            });

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<BackEnd.Model.GettingAroundZooType> GettingAroundZooType { get; set; }
    }
}

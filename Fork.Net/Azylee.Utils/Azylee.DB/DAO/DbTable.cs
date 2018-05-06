//namespace Y.DB.DAO
//{
//    class DbTable : SuperDb
//    {
//        public DbTable()
//            : base()
//        {
//        }

//        #region 数据库表
//        public DbSet<Users> Users { get; set; }
//        public DbSet<RequestAuths> RequestAuths { get; set; }

//        public DbSet<Heartbeats> Heartbeats { get; set; }
//        public DbSet<Photos> Photos { get; set; }
//        public DbSet<SupportHellos> SupportHellos { get; set; }
//        public DbSet<MarxDatas> MarxDatas { get; set; }
//        #endregion


//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            //一对一关系
//            //modelBuilder.Entity<Class1>().HasRequired(p => p.Users).WithOptional(p => p.Class1);
//        }
//    }
//}

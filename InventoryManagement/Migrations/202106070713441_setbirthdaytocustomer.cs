namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setbirthdaytocustomer : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set  BirthDate = 21 May 1997 where Id = 1");
        }
        
        public override void Down()
        {
   
        }
    }
}

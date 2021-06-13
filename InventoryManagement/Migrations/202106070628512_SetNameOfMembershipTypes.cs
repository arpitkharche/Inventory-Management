namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("update MemberShipTypes set MembershipTypeName = 'Pay As You Go' where Id = 1");
            Sql("update MemberShipTypes set MembershipTypeName = 'Monthly' where Id = 2");
            Sql("update MemberShipTypes set MembershipTypeName = 'Quarterly' where Id = 3");
            Sql("update MemberShipTypes set MembershipTypeName = 'Annual' where Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}

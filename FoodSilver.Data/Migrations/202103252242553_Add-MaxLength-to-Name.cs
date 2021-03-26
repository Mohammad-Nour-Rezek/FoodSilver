namespace FoodSilver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxLengthtoName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
    }
}

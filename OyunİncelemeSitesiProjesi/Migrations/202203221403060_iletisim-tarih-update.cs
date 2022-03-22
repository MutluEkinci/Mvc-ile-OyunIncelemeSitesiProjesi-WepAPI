namespace OyunİncelemeSitesiProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisimtarihupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.İletisim", "Tarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.İletisim", "Tarih");
        }
    }
}

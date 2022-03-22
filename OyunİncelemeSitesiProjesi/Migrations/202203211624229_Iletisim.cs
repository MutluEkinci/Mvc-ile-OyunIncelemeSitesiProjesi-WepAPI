namespace OyunİncelemeSitesiProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.İletisim",
                c => new
                    {
                        MesajID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Mail = c.String(),
                        Mesaj = c.String(),
                    })
                .PrimaryKey(t => t.MesajID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.İletisim");
        }
    }
}

namespace Siteware.Prototipo.DAL.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRODUTOS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(nullable: false, maxLength: 150),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PROMOCOES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(nullable: false, maxLength: 150),
                        Parametros = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PROMOCOES");
            DropTable("dbo.PRODUTOS");
        }
    }
}

namespace Siteware.Prototipo.DAL.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_Banco : DbMigration
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
                        PROMOCAO_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PROMOCOES", t => t.PROMOCAO_ID)
                .Index(t => t.PROMOCAO_ID);
            
            CreateTable(
                "dbo.PROMOCOES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(nullable: false, maxLength: 150),
                        TIPO = c.String(nullable: false),
                        BASE_PROPRIEDADE = c.String(nullable: false),
                        BASE_TIPO = c.String(nullable: false),
                        BASE_VALOR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RESULTADO_PROPRIEDADE = c.String(nullable: false),
                        RESULTADO_TIPO = c.String(nullable: false),
                        RESULTADO_VALOR = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTOS", "PROMOCAO_ID", "dbo.PROMOCOES");
            DropIndex("dbo.PRODUTOS", new[] { "PROMOCAO_ID" });
            DropTable("dbo.PROMOCOES");
            DropTable("dbo.PRODUTOS");
        }
    }
}

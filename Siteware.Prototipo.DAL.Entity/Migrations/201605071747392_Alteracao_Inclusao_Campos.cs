namespace Siteware.Prototipo.DAL.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Inclusao_Campos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PROMOCOES", "BASE_PROMOCAO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "TIPO_PROMOCAO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "VALOR_PROMOCAO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PROMOCOES", "BASE_RESULTADO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "TIPO_RESULTADO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "VALOR_RESULTADO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PROMOCOES", "VALOR_RESULTADO");
            DropColumn("dbo.PROMOCOES", "TIPO_RESULTADO");
            DropColumn("dbo.PROMOCOES", "BASE_RESULTADO");
            DropColumn("dbo.PROMOCOES", "VALOR_PROMOCAO");
            DropColumn("dbo.PROMOCOES", "TIPO_PROMOCAO");
            DropColumn("dbo.PROMOCOES", "BASE_PROMOCAO");
        }
    }
}

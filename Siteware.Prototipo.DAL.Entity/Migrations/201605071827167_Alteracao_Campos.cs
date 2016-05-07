namespace Siteware.Prototipo.DAL.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Campos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PROMOCOES", "TIPO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "BASE_PROPRIEDADE", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "BASE_TIPO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "BASE_VALOR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PROMOCOES", "RESULTADO_PROPRIEDADE", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "RESULTADO_TIPO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "RESULTADO_VALOR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.PROMOCOES", "PARAMETRO");
            DropColumn("dbo.PROMOCOES", "BASE_PROMOCAO");
            DropColumn("dbo.PROMOCOES", "TIPO_PROMOCAO");
            DropColumn("dbo.PROMOCOES", "VALOR_PROMOCAO");
            DropColumn("dbo.PROMOCOES", "BASE_RESULTADO");
            DropColumn("dbo.PROMOCOES", "TIPO_RESULTADO");
            DropColumn("dbo.PROMOCOES", "VALOR_RESULTADO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PROMOCOES", "VALOR_RESULTADO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PROMOCOES", "TIPO_RESULTADO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "BASE_RESULTADO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "VALOR_PROMOCAO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PROMOCOES", "TIPO_PROMOCAO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "BASE_PROMOCAO", c => c.String(nullable: false));
            AddColumn("dbo.PROMOCOES", "PARAMETRO", c => c.String(nullable: false));
            DropColumn("dbo.PROMOCOES", "RESULTADO_VALOR");
            DropColumn("dbo.PROMOCOES", "RESULTADO_TIPO");
            DropColumn("dbo.PROMOCOES", "RESULTADO_PROPRIEDADE");
            DropColumn("dbo.PROMOCOES", "BASE_VALOR");
            DropColumn("dbo.PROMOCOES", "BASE_TIPO");
            DropColumn("dbo.PROMOCOES", "BASE_PROPRIEDADE");
            DropColumn("dbo.PROMOCOES", "TIPO");
        }
    }
}

namespace TB181979_desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombres = c.String(nullable: false, maxLength: 100),
                        primerApellido = c.String(nullable: false, maxLength: 100),
                        segundoApellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 8),
                        email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CuentaBancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(),
                        Moneda = c.String(nullable: false, maxLength: 100),
                        TipoCuentaBancariaId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.TipoCuentaBancaria", t => t.TipoCuentaBancariaId)
                .Index(t => t.ClienteId)
                .Index(t => t.TipoCuentaBancariaId);
            
            CreateTable(
                "dbo.TipoCuentaBancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tipo_Transaccion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoTransaccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tipo_Transaccion = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Monto = c.Single(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 100),
                        FechaTransaccion = c.DateTime(nullable: false),
                        FechaAplicación = c.DateTime(nullable: false),
                        CuentaBancariaId = c.Int(),
                        TipoTransaccionId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CuentaBancaria", t => t.CuentaBancariaId)
                .ForeignKey("dbo.TipoTransaccion", t => t.TipoTransaccionId)
                .Index(t => t.CuentaBancariaId)
                .Index(t => t.TipoTransaccionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacciones", "TipoTransaccionId", "dbo.TipoTransaccion");
            DropForeignKey("dbo.Transacciones", "CuentaBancariaId", "dbo.CuentaBancaria");
            DropForeignKey("dbo.CuentaBancaria", "TipoCuentaBancariaId", "dbo.TipoCuentaBancaria");
            DropForeignKey("dbo.CuentaBancaria", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Transacciones", new[] { "TipoTransaccionId" });
            DropIndex("dbo.Transacciones", new[] { "CuentaBancariaId" });
            DropIndex("dbo.CuentaBancaria", new[] { "TipoCuentaBancariaId" });
            DropIndex("dbo.CuentaBancaria", new[] { "ClienteId" });
            DropTable("dbo.Transacciones");
            DropTable("dbo.TipoTransaccion");
            DropTable("dbo.TipoCuentaBancaria");
            DropTable("dbo.CuentaBancaria");
            DropTable("dbo.Cliente");
        }
    }
}

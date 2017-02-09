namespace RetroAlimentacionSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calificacion",
                c => new
                    {
                        Nomina = c.String(nullable: false, maxLength: 12, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 6, unicode: false),
                        Calificacion = c.Double(),
                        IdEstatus = c.Int(),
                    })
                .PrimaryKey(t => new { t.Nomina, t.Sigla })
                .ForeignKey("dbo.ValorCalificacion", t => t.IdEstatus)
                .Index(t => t.IdEstatus);
            
            CreateTable(
                "dbo.ValorCalificacion",
                c => new
                    {
                        IdEstatus = c.Int(nullable: false, identity: true),
                        Estatus = c.String(maxLength: 50, unicode: false),
                        MayorQue = c.Double(),
                        MenorQue = c.Double(),
                    })
                .PrimaryKey(t => t.IdEstatus);
            
            CreateTable(
                "dbo.Componentes",
                c => new
                    {
                        IdComponente = c.Int(nullable: false, identity: true),
                        Compenente = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.IdComponente);
            
            CreateTable(
                "dbo.Respuesta",
                c => new
                    {
                        IdRespuesta = c.Int(nullable: false, identity: true),
                        Respuesta = c.String(maxLength: 50, unicode: false),
                        Valor = c.Double(),
                        IdPregunta = c.Int(),
                        IdComponente = c.Int(),
                    })
                .PrimaryKey(t => t.IdRespuesta)
                .ForeignKey("dbo.Componentes", t => t.IdComponente)
                .ForeignKey("dbo.Preguntas", t => t.IdPregunta)
                .Index(t => t.IdPregunta)
                .Index(t => t.IdComponente);
            
            CreateTable(
                "dbo.Historial",
                c => new
                    {
                        IdConsecutivo = c.Int(nullable: false, identity: true),
                        Nomina = c.String(maxLength: 12, unicode: false),
                        Sigla = c.String(maxLength: 6, unicode: false),
                        IdPregunta = c.Int(),
                        IdRespuesta = c.Int(),
                        Fecha = c.DateTime(),
                        Valor = c.Double(),
                        Comentario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdConsecutivo)
                .ForeignKey("dbo.Preguntas", t => t.IdPregunta)
                .ForeignKey("dbo.Software", t => t.Sigla)
                .ForeignKey("dbo.Respuesta", t => t.IdRespuesta)
                .Index(t => t.Sigla)
                .Index(t => t.IdPregunta)
                .Index(t => t.IdRespuesta);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        IdPregunta = c.Int(nullable: false, identity: true),
                        Pregunta = c.String(unicode: false),
                        Sigla = c.String(maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.IdPregunta)
                .ForeignKey("dbo.Software", t => t.Sigla)
                .Index(t => t.Sigla);
            
            CreateTable(
                "dbo.Software",
                c => new
                    {
                        Sigla = c.String(nullable: false, maxLength: 6, unicode: false),
                        NombreSoftware = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Sigla);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historial", "IdRespuesta", "dbo.Respuesta");
            DropForeignKey("dbo.Preguntas", "Sigla", "dbo.Software");
            DropForeignKey("dbo.Historial", "Sigla", "dbo.Software");
            DropForeignKey("dbo.Respuesta", "IdPregunta", "dbo.Preguntas");
            DropForeignKey("dbo.Historial", "IdPregunta", "dbo.Preguntas");
            DropForeignKey("dbo.Respuesta", "IdComponente", "dbo.Componentes");
            DropForeignKey("dbo.Calificacion", "IdEstatus", "dbo.ValorCalificacion");
            DropIndex("dbo.Preguntas", new[] { "Sigla" });
            DropIndex("dbo.Historial", new[] { "IdRespuesta" });
            DropIndex("dbo.Historial", new[] { "IdPregunta" });
            DropIndex("dbo.Historial", new[] { "Sigla" });
            DropIndex("dbo.Respuesta", new[] { "IdComponente" });
            DropIndex("dbo.Respuesta", new[] { "IdPregunta" });
            DropIndex("dbo.Calificacion", new[] { "IdEstatus" });
            DropTable("dbo.Software");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Historial");
            DropTable("dbo.Respuesta");
            DropTable("dbo.Componentes");
            DropTable("dbo.ValorCalificacion");
            DropTable("dbo.Calificacion");
        }
    }
}

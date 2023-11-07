using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;
using Oqtane.Models;

namespace YogIT.Module.VideoN.Migrations.EntityBuilders
{
    public class VideoNEntityBuilder : AuditableBaseEntityBuilder<VideoNEntityBuilder>
    {
        private const string _entityTableName = "YogITVideoN";
        private readonly PrimaryKey<VideoNEntityBuilder> _primaryKey = new("PK_YogITVideoN", x => x.VideoNId);
        private readonly ForeignKey<VideoNEntityBuilder> _moduleForeignKey = new("FK_YogITVideoN_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public VideoNEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override VideoNEntityBuilder BuildTable(ColumnsBuilder table)
        {
            VideoNId = AddAutoIncrementColumn(table, "VideoNId");
            ModuleId = AddIntegerColumn(table, "ModuleId");
            Title = AddStringColumn(table, "Title", 256);
            Source = AddStringColumn(table, "Source", 2000);
            Poster = AddStringColumn(table, "Poster", 2000);
            Description = AddMaxStringColumn(table, "Description", true);
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> VideoNId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Title { get; set; }
        public OperationBuilder<AddColumnOperation> Source { get; set; }
        public OperationBuilder<AddColumnOperation> Poster { get; set; }
        public OperationBuilder<AddColumnOperation> Description { get; set; }

    }
}

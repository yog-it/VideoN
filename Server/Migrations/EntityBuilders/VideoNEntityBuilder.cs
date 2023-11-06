using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

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
            VideoNId = AddAutoIncrementColumn(table,"VideoNId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Title = AddStringColumn(table,"Title",256);
            Url = AddStringColumn(table,"Url",2000);
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> VideoNId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Title { get; set; }
        public OperationBuilder<AddColumnOperation> Url { get; set; }
    }
}

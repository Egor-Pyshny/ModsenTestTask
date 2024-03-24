using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP MATERIALIZED VIEW CatalogView");
            migrationBuilder.Sql(@"
                CREATE MATERIALIZED VIEW CatalogView AS
                SELECT
                    tbl_event.""id"",
                    ""time"",
                    ""name"",
                    ""country"",
                    ""city"",
                    ""organizer_first_name"",
                    ""organizer_second_name"",
                    string_agg(tbl_images.""path"", ' ') AS pathes
                FROM
                    tbl_event
                JOIN 
                    tbl_images ON tbl_event.""id"" = tbl_images.""event_id""
                GROUP BY
                    tbl_event.id;
    
                CREATE UNIQUE INDEX PK_CatalogView_Id ON CatalogView (id);
                CREATE INDEX IX_CatalogView_Time ON CatalogView (time);
                CREATE INDEX IX_CatalogView_Name ON CatalogView (name);
                CREATE INDEX IX_CatalogView_Country ON CatalogView (country);
                CREATE INDEX IX_CatalogView_City ON CatalogView (city);
                CREATE INDEX IX_CatalogView_OrganizerFirstName ON CatalogView (organizer_first_name);
                CREATE INDEX IX_CatalogView_OrganizerSecondName ON CatalogView (organizer_second_name);
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP MATERIALIZED VIEW CatalogView");
        }
    }
}

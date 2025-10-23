using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetUsers (
                                Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, 
                                PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, 
                                TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount
                                ) VALUES
                                (
                                    '5ba47728-63af-43be-808a-b7dfa2e39a20', 'Test@mail.com', 'TEST@MAIL.COM', 
                                    'Test@mail.com', 'TEST@MAIL.COM', 1, 
                                    'AQAAAAIAAYagAAAAEEKLgj9rCOS6VyLUe7qkNB5KkQfXT5cV90Ck2wPhDpPoycLyqJ2FWxxQMPTZWv8DxA==', 
                                    'NCEEF3E4LQCPVEFXMRL3VWDNLBYPJGGO', '170f3185-6cdc-48d8-97ce-ced06cccc3e3', 
                                    NULL, 0, 0, NULL, 1, 0
                                ),
                                (
                                    'd8945ebb-eb10-43cb-bdf0-17c9bd4e86b5', 'admin@vidly.com', 'ADMIN@VIDLY.COM', 
                                    'admin@vidly.com', 'ADMIN@VIDLY.COM', 1, 
                                    'AQAAAAIAAYagAAAAEC8XUvPgiBzKxO8vnAKzaUGjAw93zHLjGCKkKfY68o5qJESDUokqEo6XmiXNJsmDbQ==', 
                                    'LKOA4SKBSH7LEW55DADXKW5AKUTU22I4', '84b6292e-ae83-4b3b-b9c6-a41bd60bb1d1', 
                                    NULL, 0, 0, NULL, 1, 0
                                ),
                                (
                                    'd8e6250a-f182-42fa-87b2-474db35057c2', 'antoni.kistowski@gmail.com', 'ANTONI.KISTOWSKI@GMAIL.COM', 
                                    'antoni.kistowski@gmail.com', 'ANTONI.KISTOWSKI@GMAIL.COM', 1, 
                                    'AQAAAAIAAYagAAAAELHWrJPlJ66aArFTq5lC7p2hBUak7uqdtXMje5YGnyeVi9L4i+PSWnv+12io0OpY0A==', 
                                    'WCPTRCV5QXPCLYKYMLPIJWVETEAYUULK', '50329c14-7bc2-4f2b-a20e-209e1057950e', 
                                    NULL, 0, 0, NULL, 1, 0
                                );
                                INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES
                                (
                                    '946b92d2-d7ba-4448-8225-50a0cafd330b', 
                                    'CanManageMovies', 
                                    'CANMANAGEMOVIES', 
                                    NULL
                                );
                                INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES
                                (
                                    'd8945ebb-eb10-43cb-bdf0-17c9bd4e86b5', 
                                    '946b92d2-d7ba-4448-8225-50a0cafd330b'
                                );
    
                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

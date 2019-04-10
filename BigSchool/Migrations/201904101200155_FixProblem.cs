namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProblem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            DropColumn("dbo.Courses", "LecturerId");
            RenameColumn(table: "dbo.Courses", name: "Lecture_Id", newName: "LecturerId");
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Courses", "IsCanceled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LecturerId");
            AddForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "IsCanceled");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Followings");
            RenameColumn(table: "dbo.Courses", name: "LecturerId", newName: "Lecture_Id");
            AddColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false));
            CreateIndex("dbo.Courses", "Lecture_Id");
            AddForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

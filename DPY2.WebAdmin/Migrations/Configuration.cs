namespace DPY2.WebAdmin.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DPY2.WebAdmin.EntityFramework.Contexts.DpyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DPY2.WebAdmin.EntityFramework.Contexts.DpyContext context)
        {
            Skill skill1 = new Skill { Id = 1, Name = "C#", Text = "Studied C# for four years, first in XNA and then in ASP.NET", BlockId = 2 };
            Skill skill2 = new Skill { Id = 2, Name = "Javascript", Text = "Studied using Javascript for almost three years. Works mostly with AngularJS", BlockId = 2 };
            Skill skill3 = new Skill { Id = 3, Name = "ASP.NET", Text = "Very comfortable with ASP.NET", BlockId = 2 };

            Project project1 = new Project { Id = 1, Name = "DPY Project", Text = "A project to create a web based service/application to handle CV's", ImageFileName = "test.jpeg", BlockId = 3 };
            Project project2 = new Project { Id = 2, Name = "Web shop", Text = "A custom web shop for buying floral arrangements", ImageFileName = "test.jpeg", BlockId = 3 };
            Project project3 = new Project { Id = 3, Name = "Community forum", Text = "A simple online bulletin board where one might discuss various topics", ImageFileName = "test.jpeg", BlockId = 3 };

            Block block1 = new Block { Id = 1, Name = "Profile", Text = "I've done some stuff and seen some shit", PageIndex = 1, PageId = 1 };
            Block block2 = new Block { Id = 2, Name = "Skills", PageIndex = 2, PageId = 1, Skills = new List<Skill>() };
            Block block3 = new Block { Id = 3, Name = "Projects", PageIndex = 1, PageId = 2, Projects = new List<Project>() };

            Page page1 = new Page { Id = 1, Name = "CV", Blocks = new List<Block>() };
            Page page2 = new Page { Id = 2, Name = "Portfolio", Blocks = new List<Block>() };

            block2.Skills.AddRange(new[] { skill1, skill2, skill3 });
            block3.Projects.AddRange(new[] { project1, project2, project3 });

            page1.Blocks.Add(block1);
            page1.Blocks.Add(block2);
            page2.Blocks.Add(block3);

            context.Skills.AddOrUpdate(
                skill1, skill2, skill3
            );

            context.Projects.AddOrUpdate(
                project1, project2, project3
            );

            context.Blocks.AddOrUpdate(
                block1, block2, block3
            );

            context.Pages.AddOrUpdate(
                page1, page2
            );
        }
    }
}

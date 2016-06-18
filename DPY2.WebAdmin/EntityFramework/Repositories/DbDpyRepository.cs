using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DPY2.WebAdmin.Models.EntityModels;
using DPY2.WebAdmin.EntityFramework.Contexts;
using DPY2.WebAdmin.Models.ViewModels;
using DPY2.WebAdmin.Models.DTOModels;
using DPY2.WebAdmin.Helpers;

namespace DPY2.WebAdmin.EntityFramework.Repositories
{
    public class DbDpyRepository : IDpyRepository
    {
        DpyContext db = new DpyContext();

        /* ---------------------------------------------
                            PAGES
        --------------------------------------------- */

        #region Pages
        public IEnumerable<string> GetPageNames()
        {
            return db.Pages.Select(p => p.Name).ToArray();
        }

        public IEnumerable<PageMeta> GetPagesMeta()
        {
            return db.Pages.Select(p => new PageMeta
            {
                Id = p.Id,
                Name = p.Name
            }).ToArray();
        }

        public IEnumerable<Page> GetPages()
        {
            return db.Pages.ToArray();
        }

        public Page GetPage(int id)
        {
            return db.Pages.Include(p => p.Blocks).SingleOrDefault(p => p.Id == id);
        }

        public Page GetPage(string name)
        {
            var page = db.Pages.Include(p => p.Blocks).SingleOrDefault(p => String.Equals(p.Name.ToLower(), name.ToLower()));
            page.Blocks = page.Blocks.OrderBy(b => b.PageIndex).ToList();
            return page;
        }

        public void CreatePage(NewPage model)
        {
            db.Pages.Add(new Page
            {
                Name = model.Name
            });

            db.SaveChanges();
        }

        public void UpdatePage(Page page)
        {
            db.Pages.Attach(page);
            var pageEntry = db.Entry(page);
            pageEntry.State = EntityState.Modified;

            foreach (var block in page.Blocks)
            {
                db.Blocks.Attach(block);
                var blockEntry = db.Entry(block);
                blockEntry.State = EntityState.Modified;

                foreach (var skill in block.Skills)
                {
                    db.Skills.Attach(skill);
                    var skillEntry = db.Entry(skill);
                    skillEntry.State = EntityState.Modified;
                }

                foreach (var project in block.Projects)
                {
                    db.Projects.Attach(project);
                    var projectEntry = db.Entry(project);
                    projectEntry.State = EntityState.Modified;
                }
            }

            db.SaveChanges();
        }

        public bool DeletePage(int id)
        {
            var page = db.Pages.SingleOrDefault(p => p.Id == id);

            if (page == null)
                return false;

            db.Pages.Remove(page);
            db.SaveChanges();

            return true;
        }
        #endregion

        /* ---------------------------------------------
                            BLOCKS
        --------------------------------------------- */

        public IEnumerable<Block> GetBlocks()
        {
            return db.Blocks.Include(b => b.Skills).Include(b => b.Projects).ToArray();
        }

        public Block CreateBlock(int pageId)
        {
            var page = db.Pages.SingleOrDefault(p => p.Id == pageId);

            if (page != null)
            {
                var block = new Block
                {
                    Name = "New block",
                    Text = "Block text",
                    PageId = page.Id,
                    PageIndex = page.Blocks.OrderBy(b => b.PageIndex).Last().PageIndex + 1
                };

                page.Blocks.Add(block);
                db.SaveChanges();

                return block;
            }

            return null;
        }

        public bool DeleteBlock(int id)
        {
            var block = db.Blocks.SingleOrDefault(b => b.Id == id);

            if (block == null)
                return false;

            var page = db.Pages.Single(p => p.Id == block.PageId);
            page.Blocks.Remove(block);
            db.Blocks.Remove(block);
            db.SaveChanges();

            return true;
        }


        /* ---------------------------------------------
                           PROJECTS
        --------------------------------------------- */

        #region Projects
        public IEnumerable<Project> GetProjects()
        {
            return db.Projects.Include(p => p.Block).ToArray();
        }

        public IEnumerable<EditProject> GetProjectsDTO()
        {
            return db.Projects.Select(p => new EditProject
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Text,
                ImageURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Uploads/Images/",
                ImageFileName = p.ImageFileName
            }).ToArray();
        }

        public IEnumerable<ProjectVM> GetProjectsVM()
        {
            return db.Projects.Select(p => new ProjectVM
            {
                Id = p.Id,
                Name = p.Name,
                Text = p.Text,
                ImageURI = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Uploads/Images/" + p.ImageFileName
            }).ToArray();
        }

        public Project GetProject(int id)
        {
            return db.Projects.SingleOrDefault(p => p.Id == id);
        }

        public EditProject GetProjectDTO(int id)
        {
            var em = db.Projects.SingleOrDefault(p => p.Id == id);

            if (em != null)
            {
                var vm = new EditProject
                {
                    Id = em.Id,
                    Name = em.Name,
                    Description = em.Text,
                    ImageURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Uploads/Images/",
                    ImageFileName = em.ImageFileName
                };

                return vm;
            }

            return null;
        }

        public ProjectVM GetProjectVM(int id)
        {
            var em = db.Projects.SingleOrDefault(p => p.Id == id);

            if (em != null)
            {
                var vm = new ProjectVM
                {
                    Id = em.Id,
                    Name = em.Name,
                    Text = em.Text,
                    ImageURI = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Uploads/Images/" + em.ImageFileName
                };

                return vm;
            }

            return null;
        }

        public bool CreateProject(NewProject project)
        {
            string fileName = Utils.SaveBase64Image(project.Image);

            var em = new Project
            {
                Name = project.Name,
                Text = project.Description,
                ImageFileName = fileName
            };

            db.Projects.Add(em);
            db.SaveChanges();

            return true;
        }

        public void UpdateProject(Project project)
        {
            db.Projects.Attach(project);
            var entry = db.Entry(project);
            entry.Property(p => p.Name).IsModified = true;
            entry.Property(p => p.Text).IsModified = true;
            db.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = db.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
        }
        #endregion

        /* ---------------------------------------------
                            SKILLS
        --------------------------------------------- */

        #region Skills
        public IEnumerable<Skill> GetSkills()
        {
            return db.Skills.ToArray();
        }

        public Skill GetSkill(int id)
        {
            return db.Skills.SingleOrDefault(s => s.Id == id);
        }

        public void CreateSkill(Skill skill)
        {
            db.Skills.Add(skill);
            db.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            db.Skills.Attach(skill);
            var entity = db.Entry(skill);
            entity.Property(s => s.Name).IsModified = true;
            entity.Property(s => s.Text).IsModified = true;
            db.SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            var entity = db.Skills.SingleOrDefault(s => s.Id == id);

            if (entity != null)
            {
                db.Skills.Remove(entity);
                db.SaveChanges();
            }
        }
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
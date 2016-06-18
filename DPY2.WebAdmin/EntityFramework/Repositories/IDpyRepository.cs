using DPY2.WebAdmin.Models.ViewModels;
using DPY2.WebAdmin.Models.DTOModels;
using DPY2.WebAdmin.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace DPY2.WebAdmin.EntityFramework.Repositories
{
    public interface IDpyRepository : IDisposable
    {
        /* ---------------------------------------------
                            PAGES
        --------------------------------------------- */

        IEnumerable<string> GetPageNames();
        IEnumerable<PageMeta> GetPagesMeta();
        IEnumerable<Page> GetPages();
        Page GetPage(int id);
        Page GetPage(string name);
        void CreatePage(NewPage model);
        void UpdatePage(Page page);
        bool DeletePage(int id);


        /* ---------------------------------------------
                            BLOCKS
        --------------------------------------------- */

        IEnumerable<Block> GetBlocks();
        Block CreateBlock(int pageId);
        bool DeleteBlock(int id);


        /* ---------------------------------------------
                           PROJECTS
        --------------------------------------------- */

        IEnumerable<Project> GetProjects();
        IEnumerable<EditProject> GetProjectsDTO();
        IEnumerable<ProjectVM> GetProjectsVM();
        Project GetProject(int id);
        EditProject GetProjectDTO(int id);
        ProjectVM GetProjectVM(int id);
        bool CreateProject(NewProject project);
        void UpdateProject(Project project);
        void DeleteProject(int id);


        /* ---------------------------------------------
                            SKILLS
        --------------------------------------------- */

        IEnumerable<Skill> GetSkills();
        Skill GetSkill(int id);
        void CreateSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
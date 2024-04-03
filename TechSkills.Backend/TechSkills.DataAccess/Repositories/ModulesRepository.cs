namespace TechSkills.DataAccess.Repositories
{
    public class ModulesRepository
    {
        private readonly TechSkillsDbContext _context;

        public ModulesRepository(TechSkillsDbContext context)
        {
            _context = context;
        }

    }
}

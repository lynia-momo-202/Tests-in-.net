using Core;

namespace BusinessLayer
{
    public class MyLogic
    {
        private readonly IRepository _repo;

        public MyLogic(IRepository repo)
        {
            _repo = repo;
        }

        public void SaveSomeData()
        {
            _repo.Save();
        }
    }
}

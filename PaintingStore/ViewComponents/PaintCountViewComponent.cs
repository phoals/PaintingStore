using Microsoft.AspNetCore.Mvc;
using PaintingStore.Services;

namespace PaintingStore.ViewComponents
{
    public class PaintCountViewComponent : ViewComponent
    {
        private readonly IPaintingRepository _paintingRepository;

        public PaintCountViewComponent(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        public IViewComponentResult Invoke()
        {
            var result = _paintingRepository.PaintingCountByGenre();

            return View(result);
        }
    }
}

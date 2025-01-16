using AutoMapper;
using DashBoard.DAL.DBContext;
using DashBoard.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.PL.Controllers
{
    public class OffersController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;



        public OffersController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
            var offers = await _context.Offers.ToListAsync();

            var offerDto = _mapper.Map<OffersDto>(offers);

            return View(offerDto);
        }
    }
}

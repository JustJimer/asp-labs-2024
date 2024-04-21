using Microsoft.AspNetCore.Mvc;

namespace LR3_Chupyna_ASP_402
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalcService _calcService;

        public CalculatorController(CalcService calcService)
        {
            _calcService = calcService;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            var result = _calcService.Add(a, b);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            var result = _calcService.Subtract(a, b);
            return Ok(result);
        }

        [HttpGet("product")]
        public IActionResult Product(int a, int b)
        {
            var result = _calcService.Product(a, b);
            return Ok(result);
        }

        [HttpGet("square")]
        public IActionResult Square(int a)
        {
            var result = _calcService.Square(a);
            return Ok(result);
        }
    }
}

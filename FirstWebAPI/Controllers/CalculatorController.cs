using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/Add?x=5&y=3
        [HttpGet("Calculator/Add")]
        public int Add(int x ,int y)
        {
            return x + y;
        }
        //api/calculator/Add?x=5&y=3
        [HttpGet("Calculator/Sum")]
        public int Sum(int x, int y)
        {
            return x + y;
        }
        //api/calculator/Subtract?x=5&y=3
        [HttpPost("Calculator/Subtract")]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        //api/calculator/Multiply?x=5&y=3
        [HttpPut("/Multiply")]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/calculator/Divide?x=5&y=3
        [HttpDelete("Calculator/Divide")]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}

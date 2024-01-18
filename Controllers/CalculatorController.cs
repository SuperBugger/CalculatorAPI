using System;
using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Models;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpPost("evaluate-expression")]
        public IActionResult EvaluateExpression([FromBody] CalculatorRequest request)
        {
            try
            {
                double result = EvaluateExpressionInternal(request.Values, request.Operators);
                return Ok(new CalculatorResponse { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new CalculatorResponse { ErrorMessage = ex.Message });
            }
        }

        private double EvaluateExpressionInternal(double[] values, char[] operators)
        {
            if (values.Length != operators.Length + 1)
            {
                throw new ArgumentException("Invalid number of values or operators");
            }

            double result = values[0];

            for (int i = 0; i < operators.Length; i++)
            {
                double nextValue = values[i + 1];

                switch (operators[i])
                {
                    case '+':
                        result += nextValue;
                        break;
                    case '-':
                        result -= nextValue;
                        break;
                    case '*':
                        result *= nextValue;
                        break;
                    case '/':
                        result /= nextValue;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported operator: {operators[i]}");
                }
            }

            return result;
        }
    }
}

using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SmallFarm.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            string? resultValue = result.FirstValue?.Trim();

            if (result != ValueProviderResult.None 
                && !string.IsNullOrEmpty(resultValue))
            {
                decimal converted = 0m;
                bool succeeded = false;

                try
                {
                    resultValue = resultValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    resultValue = resultValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    converted = Convert.ToDecimal(resultValue, CultureInfo.CurrentCulture);
                    succeeded = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (succeeded)
                {
                    bindingContext.Result = ModelBindingResult.Success(converted);
                }
            }

            return Task.CompletedTask;
        }
    }
}

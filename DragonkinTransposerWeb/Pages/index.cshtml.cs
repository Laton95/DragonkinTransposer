using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonkinTransposerWeb.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class indexModel : PageModel
    {
        public byte[] Image { get; set; }

        public string Input { get; set; }

        public void OnGet()
        {
            string input = this.Request.Query["Input"];

            if (input == null || input.Length == 0)
            {
                input = string.Empty;
            }

            Input = input;

            Image = ConvertToByteArray(DragonkinTransposer.Transposer.Transpose(input));
        }

        public static byte[] ConvertToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public RedirectToActionResult OnPost()
        {
            return this.RedirectToAction("", new { Input = Request.Form["input"]});
        }
    }
}
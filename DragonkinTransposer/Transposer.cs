using DragonkinTransposer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DragonkinTransposer
{
    public class Transposer
    {
        public static Bitmap Transpose(string toTranspose)
        {
            if (toTranspose == null || toTranspose.Length == 0) 
            {
                toTranspose = " ";
            }

            List<Bitmap> characters = new List<Bitmap>();

            foreach (char character in toTranspose)
            {
                characters.Add(GetDragonkinCharacter(character));
            }

            Bitmap output = new Bitmap(characters.Sum(i => i.Width), 173);
            output.MakeTransparent();

            int x = 0;

            foreach (Bitmap character in characters)
            {
                using (Graphics g = Graphics.FromImage(output))
                {
                    g.DrawImage(character, new Rectangle(x, 0, character.Width, character.Height));
                    x += character.Width;
                }
            }

            return output;
        }

        private static Bitmap GetDragonkinCharacter(char character)
        {
            character = char.ToUpper(character);

            if ("BCD".Contains(character))
            {
                return Resources.BCD;
            }
            else if ("FGH".Contains(character))
            {
                return Resources.FGH;
            }
            else if ("JKL".Contains(character))
            {
                return Resources.JKL;
            }
            else if ("MNP".Contains(character))
            {
                return Resources.MNP;
            }
            else if ("QRS".Contains(character))
            {
                return Resources.QRS;
            }
            else if ("TVW".Contains(character))
            {
                return Resources.TVW;
            }
            else if ("XYZ".Contains(character))
            {
                return Resources.XYZ;
            }
            else if ("AEIOU".Contains(character))
            {
                return Resources.AEIOU;
            }

            return Resources.space;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography_Tutorial
{
    public static class Steganography
    {
        public enum EmbedTextState
        {
            EmbedText,
            FillingWithEightZeros,
        }

        public static void EmbedTextInCoverImage(Bitmap coverImage, string secretMessage)
        {
            //Aktueller Status, ob das Ende der versteckten Nachricht erreicht ist
            EmbedTextState embedTextState = EmbedTextState.EmbedText;

            //Anzahl der schon gefüllten 0
            int filledZeros = 0;

            //Index vom BitArray
            int secretMessageBitArrayIndex = 0;

            BitArray secretMessageBitArray = SecretMessageToBitArray(secretMessage);

            for (int row = 0; row < coverImage.Height; row++)
            {
                for (int col = 0; col < coverImage.Width; col++)
                {
                    //Niederwertigsten Bit bereinigen
                    GetClearedLSBFromPixel(coverImage, row, col, out int pixelColorR, out int pixelColorG, out int pixelColorB);

                    //Iterieren über die drei Grundfarben
                    for (int colorIndex = 0; colorIndex < 3; colorIndex++)
                    {
                        bool secretMessageBit = false;
                        //Überprüfen ob Ende vom BitArray erreicht ist
                        if (secretMessageBitArray.Length > secretMessageBitArrayIndex && embedTextState == EmbedTextState.EmbedText)
                        {
                            //Aus dem BitArray den nächsten Bit holen
                            secretMessageBit = secretMessageBitArray.Get(secretMessageBitArrayIndex);
                        }
                        else
                        {
                            embedTextState = EmbedTextState.FillingWithEightZeros;
                        }

                        //Konvertieren des Bits in ein Integer
                        int secretMessageBitInt = secretMessageBit ? 1 : 0;

                        //Modifizieren des niedrigwertigsten Bits
                        switch (colorIndex)
                        {
                            case 0:
                                pixelColorR = pixelColorR + secretMessageBitInt;
                                break;
                            case 1:
                                pixelColorG = pixelColorG + secretMessageBitInt;
                                break;
                            case 2:
                                pixelColorB = pixelColorB + secretMessageBitInt;
                                //Überschreiben des Pixels mit den neuen Werten
                                coverImage.SetPixel(col, row, Color.FromArgb(pixelColorR, pixelColorG, pixelColorB));
                                break;
                        }
                        //Erhöhen vom Bit Array Index
                        secretMessageBitArrayIndex++;

                        //Zählen der 0 
                        if (embedTextState == EmbedTextState.FillingWithEightZeros)
                            filledZeros++;

                        //Abbruchbedingung falls acht 0 erreicht sind
                        if (filledZeros >= 8)
                            return;
                    }
                }
            }
        }

        private static void GetClearedLSBFromPixel(Bitmap coverImage, int row, int col, out int pixelColorR, out int pixelColorG, out int pixelColorB)
        {
            //Auswählen des aktuellen Pixels
            var pixel = coverImage.GetPixel(col, row);
            //Löschen der niedrigwertigsten Bits der Grundfarben
            pixelColorR = pixel.R - pixel.R % 2;
            pixelColorG = pixel.G - pixel.G % 2;
            pixelColorB = pixel.B - pixel.B % 2;
        }

        private static BitArray SecretMessageToBitArray(string secretMessage)
        {
            //Umwandeln der versteckten Nachricht in ein Bit Array
            byte[] secretMessageBytes = Encoding.ASCII.GetBytes(secretMessage);

            //Umwandeln des Byte Arrays in ein Bit Array, damit 
            BitArray secretMessageBitArray = new BitArray(secretMessageBytes);
            return secretMessageBitArray;
        }

        public static string ExtractTextFromCoverImage(string sourcePath)
        {
            string secretMessage = string.Empty;
            int byteInt = 1;
            int secretLetterInt = 0;

            using (Bitmap img = new Bitmap(sourcePath))
            {
                for (int row = 0; row < img.Height; row++)
                {
                    for (int col = 0; col < img.Width; col++)
                    {
                        //Auswählen des aktuellen Pixels
                        var pixel = img.GetPixel(col, row);

                        for (int colorIndex = 0; colorIndex < 3; colorIndex++)
                        {
                            //Holen des niedrigwertigsten Bits der Grundfarben
                            int leastSignificantBit = 0;
                            switch (colorIndex)
                            {
                                case 0:
                                    leastSignificantBit = pixel.R % 2;
                                    break;
                                case 1:
                                    leastSignificantBit = pixel.G % 2;
                                    break;
                                case 2:
                                    leastSignificantBit = pixel.B % 2;
                                    break;
                            }

                            //Addieren der Int Werte von den einzelnen Bits
                            if (leastSignificantBit == 1)
                                secretLetterInt += byteInt;

                            //Wert von 1 bis 256 doppeln, damit aus den einzelnen Bits ein Buchstabe entsteht
                            byteInt = byteInt * 2;

                            //Buchstabe hinzufügen, wenn 8 Bit erreicht sind
                            if (byteInt == 256)
                            {
                                //Abbruch wenn acht 0 erreicht sind
                                if (secretLetterInt == 0)
                                    return secretMessage;

                                //Konvertieren des Integer Wertes in ein Zeichen
                                var secretMessageChar = Convert.ToChar(secretLetterInt);
                                //Hinzufügen des Zeichens zur versteckten Nachricht
                                secretMessage += secretMessageChar;

                                //Zurücksetzen der Variablen, da ein neuer Buchstabe angefangen hat
                                secretLetterInt = 0;
                                byteInt = 1;
                            }
                        }

                    }
                }
                return secretMessage;
            }
        }
    }
}

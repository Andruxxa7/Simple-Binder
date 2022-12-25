using System;
using System.Windows.Forms;
using WindowsInput.Native;
using System.Windows.Input;
using mrousavy;
using WindowsInput;

namespace SimpleBinder
{
    public partial class ActiveBind
    {
        private Keys ConvertFromStringToKey(string str)
        {
            Keys result = Keys.Clear;
            if (str.Length == 1)
            {
                switch (str)
                {
                    #region Letters(Qwerty and йцукен)

                    case "Q" or "Й":
                        result = Keys.Q;
                        break;
                    case "W" or "Ц":
                        result = Keys.W;
                        break;
                    case "E" or "У":
                        result = Keys.E;
                        break;
                    case "R" or "К":
                        result = Keys.R;
                        break;
                    case "T" or "Е":
                        result = Keys.T;
                        break;
                    case "Y" or "Н":
                        result = Keys.Y;
                        break;
                    case "U" or "Г":
                        result = Keys.U;
                        break;
                    case "I" or "Ш":
                        result = Keys.I;
                        break;
                    case "O" or "Щ":
                        result = Keys.O;
                        break;
                    case "P" or "З":
                        result = Keys.P;
                        break;
                    case "[" or "Х":
                        result = (Keys)char.ToUpper('[');
                        break;
                    case "]" or "Ъ":
                        result = (Keys)char.ToUpper(']');
                        break;
                    case "A" or "Ф":
                        result = Keys.A;
                        break;
                    case "S" or "Ы":
                        result = Keys.S;
                        break;
                    case "D" or "В":
                        result = Keys.D;
                        break;
                    case "F" or "А":
                        result = Keys.F;
                        break;
                    case "G" or "П":
                        result = Keys.G;
                        break;
                    case "H" or "Р":
                        result = Keys.H;
                        break;
                    case "J" or "О":
                        result = Keys.J;
                        break;
                    case "K" or "Л":
                        result = Keys.K;
                        break;
                    case "L" or "Д":
                        result = Keys.L;
                        break;
                    case ";" or "Ж":
                        result = (Keys)char.ToUpper('.');
                        break;
                    case "'" or "Э":
                        result = (Keys)char.ToUpper('\'');
                        break;
                    case "\\":
                        result = (Keys)char.ToUpper('\\');
                        break;
                    case "Z" or "Я":
                        result = Keys.Z;
                        break;
                    case "X" or "Ч":
                        result = Keys.X;
                        break;
                    case "C" or "С":
                        result = Keys.C;
                        break;
                    case "V" or "М":
                        result = Keys.V;
                        break;
                    case "B" or "И":
                        result = Keys.B;
                        break;
                    case "N" or "Т":
                        result = Keys.N;
                        break;
                    case "M" or "Ь":
                        result = Keys.M;
                        break;
                    case "," or "Б":
                        result = (Keys)char.ToUpper(',');
                        break;
                    case "." or "Ю":
                        result = (Keys)char.ToUpper('.');
                        break;
                    case "/" or ".":
                        result = (Keys)char.ToUpper('/');
                        break;

                    #endregion

                    #region Digits

                    case "1":
                        result = (Keys)'1';
                        break;

                    case "2":
                        result = (Keys)'2';
                        break;

                    case "3":
                        result = (Keys)'3';
                        break;

                    case "4":
                        result = (Keys)'4';
                        break;

                    case "5":
                        result = (Keys)'5';
                        break;

                    case "6":
                        result = (Keys)'6';
                        break;

                    case "7":
                        result = (Keys)'7';
                        break;

                    case "8":
                        result = (Keys)'8';
                        break;

                    case "9":
                        result = (Keys)'9';
                        break;

                    case "=":
                        result = (Keys)'=';
                        break;

                    case "-":
                        result = (Keys)'-';
                        break;

                    #endregion
                }
            }
            else
            {
                #region Modifiers

                result = str switch
                {
                    "Control" => Keys.Control,
                    "Alt" => Keys.Alt,
                    "Win" => Keys.LWin,
                    "Shift" => Keys.Shift,
                    _ => result
                };

                #endregion
            }

            return result;
        }

        private Keys[] ConvertFromStringToKeys()
        {
            
            var arrayOfKeyStrings = keys.Replace(" + ", " ").Split(' ');
            var result = new Keys[arrayOfKeyStrings.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = ConvertFromStringToKey(arrayOfKeyStrings[i]);
            }
            return result;
        }

    }
}
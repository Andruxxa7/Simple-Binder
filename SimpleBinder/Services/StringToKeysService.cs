using System.Windows.Input;
using ModifierKeys = NonInvasiveKeyboardHookLibrary.ModifierKeys;

namespace SimpleBinder
{
    public partial class ActiveBind
    {
        private object ConvertFromStringToKey(string str)
        {
            object result = Key.Clear;
            if (str.Length == 1)
            {
                switch (str)
                {
                    #region Letters(Qwerty and йцукен)

                    case "Q" or "Й":
                        result = Key.Q;
                        break;
                    case "W" or "Ц":
                        result = Key.W;
                        break;
                    case "E" or "У":
                        result = Key.E;
                        break;
                    case "R" or "К":
                        result = Key.R;
                        break;
                    case "T" or "Е":
                        result = Key.T;
                        break;
                    case "Y" or "Н":
                        result = Key.Y;
                        break;
                    case "U" or "Г":
                        result = Key.U;
                        break;
                    case "I" or "Ш":
                        result = Key.I;
                        break;
                    case "O" or "Щ":
                        result = Key.O;
                        break;
                    case "P" or "З":
                        result = Key.P;
                        break;
                    case "[" or "Х":
                        result = (Key)char.ToUpper('[');
                        break;
                    case "]" or "Ъ":
                        result = (Key)char.ToUpper(']');
                        break;
                    case "A" or "Ф":
                        result = Key.A;
                        break;
                    case "S" or "Ы":
                        result = Key.S;
                        break;
                    case "D" or "В":
                        result = Key.D;
                        break;
                    case "F" or "А":
                        result = Key.F;
                        break;
                    case "G" or "П":
                        result = Key.G;
                        break;
                    case "H" or "Р":
                        result = Key.H;
                        break;
                    case "J" or "О":
                        result = Key.J;
                        break;
                    case "K" or "Л":
                        result = Key.K;
                        break;
                    case "L" or "Д":
                        result = Key.L;
                        break;
                    case ";" or "Ж":
                        result = (Key)char.ToUpper('.');
                        break;
                    case "'" or "Э":
                        result = (Key)char.ToUpper('\'');
                        break;
                    case "\\":
                        result = (Key)char.ToUpper('\\');
                        break;
                    case "Z" or "Я":
                        result = Key.Z;
                        break;
                    case "X" or "Ч":
                        result = Key.X;
                        break;
                    case "C" or "С":
                        result = Key.C;
                        break;
                    case "V" or "М":
                        result = Key.V;
                        break;
                    case "B" or "И":
                        result = Key.B;
                        break;
                    case "N" or "Т":
                        result = Key.N;
                        break;
                    case "M" or "Ь":
                        result = Key.M;
                        break;
                    case "," or "Б":
                        result = (Key)char.ToUpper(',');
                        break;
                    case "." or "Ю":
                        result = (Key)char.ToUpper('.');
                        break;
                    case "/" or ".":
                        result = (Key)char.ToUpper('/');
                        break;  

                    #endregion

                    #region Digits

                    case "1":
                        result = (Key)'1';
                        break;

                    case "2":
                        result = (Key)'2';
                        break;

                    case "3":
                        result = (Key)'3';
                        break;

                    case "4":
                        result = (Key)'4';
                        break;

                    case "5":
                        result = (Key)'5';
                        break;

                    case "6":
                        result = (Key)'6';
                        break;

                    case "7":
                        result = (Key)'7';
                        break;

                    case "8":
                        result = (Key)'8';
                        break;

                    case "9":
                        result = (Key)'9';
                        break;

                    case "=":
                        result = (Key)'=';
                        break;

                    case "-":
                        result = (Key)'-';
                        break;

                    #endregion
                }
            }
            else
            {
                #region Modifiers

                result = str switch
                {
                    "Control" => ModifierKeys.Control,
                    "Alt" => ModifierKeys.Alt,
                    "Win" => ModifierKeys.WindowsKey,
                    "Shift" => ModifierKeys.Shift,
                    _ => result
                };

                #endregion
            }

            return result;
        }

        private object[] ConvertFromStringToKeys()
        {
            
            var arrayOfKeyStrings = keys.Replace(" + ", " ").Split(' ');
            var result = new object[arrayOfKeyStrings.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = ConvertFromStringToKey(arrayOfKeyStrings[i]);
            }
            return result;
        }

    }
}
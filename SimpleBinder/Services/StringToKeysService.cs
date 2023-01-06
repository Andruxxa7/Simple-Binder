using ModifierKeys = NonInvasiveKeyboardHookLibrary.ModifierKeys;

namespace SimpleBinder;

public partial class ActiveBind
{
    private static object ConvertFromStringToKey(string str)
    {
        object result = Key.None;
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
                    result = Key.Oem4;
                    break;
                case "]" or "Ъ":
                    result = Key.Oem6;
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
                    result = Key.Oem1;
                    break;
                case "'" or "Э":
                    result = Key.Oem7;
                    break;
                case "\\":
                    result = Key.Oem5;
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
                    result = Key.OemComma;
                    break;
                case "." or "Ю":
                    result = Key.OemPeriod;
                    break;
                case "/" or ".":
                    result = Key.Oem2;
                    break;  
                case "`" or "Ё":
                    result = Key.Oem3;
                    break;  
                #endregion

                #region Digits
 
                case "1":
                    result = Key.D1;
                    break;

                case "2":
                    result = Key.D2;
                    break;

                case "3":
                    result = Key.D3;
                    break;

                case "4":
                    result = Key.D4;
                    break;

                case "5":
                    result = Key.D5;
                    break;

                case "6":
                    result = Key.D6;
                    break;

                case "7":
                    result = Key.D7;
                    break;

                case "8":
                    result = Key.D8;
                    break;

                case "9":
                    result = Key.D9;
                    break;

                case "0":
                    result = Key.D0;
                    break;
                case "=":
                    result = Key.OemPlus;
                    break;

                case "-":
                    result = Key.OemMinus;
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
                _=>Key.None
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